using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using wholesaleStore.Core.Interfaces;
using wholesaleStore.Core.Models;
using wholesaleStore.Core.Services;
using wholesaleStore.Models;

namespace wholesaleStore.Controllers
{
    public class UserController : Controller
    {
        private readonly IUsersService _usersService;
        private readonly IGoodsService _goodsService;
        private readonly IOrdersService _ordersService;
        private readonly IUsersService _userService;
        private readonly ICartService _cartService;

        public UserController(IUsersService usersService, IGoodsService goodsService, IOrdersService ordersService, IUsersService userService, ICartService cartService)
        {
            _usersService = usersService;
            _goodsService = goodsService;
            _ordersService = ordersService;
            _userService = userService;
            _cartService = cartService;
        }

        [Route("LoginUser")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("LoginUser")]
        public async Task<IActionResult> Login(string login, string password)
        {
            var user = await _usersService.GetAllUsers();
            var foundUser = user.FirstOrDefault(u => u.Login == login && u.Password == password);
            if (foundUser != null)
            {
                HttpContext.Session.SetInt32("UserId", foundUser.Id);
                return RedirectToAction("Products");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid login or password!";
                return View();
            }
        }


        [HttpGet]
        [Route("RegisterUser")]
        public IActionResult Register()
        {
            var model = new UserRegisterModel();
            return View(model);
        }


        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> Register(UserRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Phone = model.Phone,
                    Login=model.Login,
                    Password = model.Password, 
                    Birthday = model.Birthday,
                    DateTime = DateTime.Now,
                    DateActivity = DateTime.Now
                };

                var result = await _userService.AddUser(user);
                if (result != null)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", "Не вдалося зареєструвати користувача.");
                }
            }
            return View(model);
        }


        [Route("Goods")]
        [HttpGet]
        public async Task<IActionResult> Products()
        {
            var products = await _goodsService.GetAllGoods();
            return View(products);
        }




        [HttpGet]
        [Route("HistoryOrder")]
        public async Task<IActionResult> OrderHistory()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId.HasValue)
            {
                var orders = (await _ordersService.GetAllOrders()).Where(u=>u.user.Id== userId.Value).ToList();
                return View(orders);
            }
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> AddToCart(int productId)
        {
            var user = await _userService.GetUserById(HttpContext.Session.GetInt32("UserId").Value); 
            var product = await _cartService.GetProductById(productId);

            if (user != null && product != null)
            {
                var cartItem = new CartItem
                {
                    User = user,
                    Product = product,
                    Quantity = 1,
                    DateAdded = DateTime.Now
                };

                await _cartService.AddToCart(cartItem); 
            }

            return RedirectToAction("Products");
        }


        [Route("Cart")]
        public async Task<IActionResult> Cart()
        {
            var user = await _userService.GetUserById(HttpContext.Session.GetInt32("UserId").Value); 
            var cartItems = (await _cartService.GetCartItems(user)).ToList();

            return View(cartItems);
        }


        public async Task<IActionResult> ConfirmOrder()
        {
            var user = await _userService.GetUserById(HttpContext.Session.GetInt32("UserId").Value); 
            List<CartItem> cartItems = (await _cartService.GetCartItems(user)).ToList();
            List<Goods> goods = new List<Goods>();
            foreach (var cartItem in cartItems)
            {
                goods.Add(cartItem.Product);
             }

            var order = new Orders
            {
                user = user,
                DateOrder = DateTime.Now,
                Goods = goods,
                Cost = cartItems.Sum(ci => ci.Product.Cost * ci.Quantity) 
            };

            await _cartService.AddOrder(order); 


             await _cartService.ClearCart(user);

            return RedirectToAction("OrderHistory");
        }
    }

}

using Microsoft.AspNetCore.Mvc;
using wholesaleStore.Core.Interfaces;
using wholesaleStore.Core.Models;
using wholesaleStore.Models;

namespace wholesaleStore.Controllers
{
    public class EnterpriceController : Controller
    {
        private readonly IFieldActivityService _fieldActivityService;
        private readonly IAddressesService _addressesService;
        private readonly IEnterpriceService _enterpriceService;
        private readonly IAdministratorService _administratorService;

        public EnterpriceController(IFieldActivityService fieldActivityService,
            IAddressesService addressesService,
            IEnterpriceService enterpriceService,
            IAdministratorService administratorService)
        {
            _fieldActivityService = fieldActivityService;
            _addressesService = addressesService;
            _enterpriceService = enterpriceService;
            _administratorService = administratorService;
        }

        [Route("CreateEnterprice")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateEnterprice")]
        public async Task<IActionResult> Create(EnterpriceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var fieldActivity = new FieldActivity
                {
                    Name = model.FieldActivityName,
                    Description = model.FieldActivityDescription
                };
                await _fieldActivityService.AddFieldActivity(fieldActivity);

                var address = new Addresses
                {
                    Country = model.Country,
                    Region = model.Region,
                    Street = model.Street,
                    NumberStreet = model.NumberStreet
                };
                await _addressesService.AddAddress(address);

                var enterprice = new Enterprice
                {
                    Title = model.EnterpriceTitle,
                    DateCreate = model.DateCreate,
                    Email = model.Email,
                    Phone = model.Phone,
                    FieldActivity = fieldActivity,
                    Addresses = address
                };
                var createdEnterprice = await _enterpriceService.AddEnterprice(enterprice);

                var administrator = new Administrator
                {
                    Name = model.AdministratorName,
                    Surname = model.AdministratorSurname,
                    Phone = model.AdministratorPhone,
                    Login = model.AdministratorLogin,
                    Password = model.AdministratorPassword,
                    Enterprice = createdEnterprice
                };
                await _administratorService.AddAdministrator(administrator);

                return RedirectToAction("Index"); 
            }

            return View(model);
        }

        [Route("IndexEnterprice")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var enterprices = await _enterpriceService.GetAllEnterprices();
            return View(enterprices);
        }

        [Route("DetailEnterprice")]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var enterprice = await _enterpriceService.GetEnterpriceById(id);
            if (enterprice == null)
            {
                return NotFound();
            }

            return View(enterprice);
        }
    }
}

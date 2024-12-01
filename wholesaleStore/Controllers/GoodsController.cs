using Microsoft.AspNetCore.Mvc;
using wholesaleStore.Core.Interfaces;
using wholesaleStore.Core.Models;
using wholesaleStore.Models;

namespace wholesaleStore.Controllers
{
    public class GoodsController : Controller
    {
        private readonly IGoodsService _goodsService;
        private readonly IEnterpriceService _enterpriceService;

        public GoodsController(IGoodsService goodsService, IEnterpriceService enterpriceService)
        {
            _goodsService = goodsService;
            _enterpriceService = enterpriceService;
        }

        [HttpGet]
        [Route("ListGoods")]
        public async Task<IActionResult> Index()
        {
            var goods = await _goodsService.GetAllGoods();
            return View(goods);
        }

        [Route("CreateGood")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateGood")]
        public async Task<IActionResult> Create(CreateGoodsRequest goods)
        {
            if (ModelState.IsValid)
            {
                Enterprice enterprice = await _enterpriceService.GetEnterpriceById(HttpContext.Session.GetInt32("EnterpriceId").Value);
                Goods newGood = new Goods
                {
                    Title = goods.Title,
                    Numbers = goods.Numbers,
                    Maker = goods.Maker,
                    Description = goods.Description,
                    Cost = goods.Cost,
                    Enterprice = enterprice,
                };
                await _goodsService.AddGood(newGood);
                return RedirectToAction(nameof(Index));
            }
            return View(goods);
        }

        [HttpGet]
        [Route("EditGood")]
        public async Task<IActionResult> Edit(int id)
        {
            var goods = await _goodsService.GetGoodById(id);
            if (goods == null)
            {
                return NotFound();
            }

            var editRequest = new GoodsEditRequest
            {
                Title = goods.Title,
                Maker = goods.Maker,
                Description = goods.Description,
                Cost = goods.Cost,
                Numbers = goods.Numbers
            };

            return View(editRequest); 
        }

        [Route("EditGood")]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, GoodsEditRequest request)
        {
            if (ModelState.IsValid)
            {
                var goods = await _goodsService.GetGoodById(id);
                if (goods == null)
                {
                    return NotFound();
                }

                goods.Title = request.Title;
                goods.Maker = request.Maker;
                goods.Description = request.Description;
                goods.Cost = request.Cost;
                goods.Numbers = request.Numbers;

                await _goodsService.UpdateGood(goods); 
                return RedirectToAction(nameof(Index));
            }

            return View(request); 
        }

        [Route("DeleteGood")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var goods = await _goodsService.GetGoodById(id);
            if (goods == null)
            {
                return NotFound();
            }

            return View(goods); 
        }


        [HttpPost]
        [Route("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var goods = await _goodsService.GetGoodById(id);
            if (goods == null)
            {
                return NotFound();
            }

            await _goodsService.DeleteGood(id); 
            return RedirectToAction(nameof(Index)); 
        }

        [Route("DetailsGood")]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var goods = await _goodsService.GetGoodById(id);
            if (goods == null)
            {
                return NotFound();
            }
            return View(goods);
        }
    }
}

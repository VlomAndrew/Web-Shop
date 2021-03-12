using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web_Shop.Extentions;
using Web_Shop.Models;

namespace Web_Shop.Controllers
{
    public class GoodsController : Controller
    {
        private GoodsContext db;
        

        public GoodsController(GoodsContext context)
        {
            db = context;
            
        }

        public ShopCart GetCart()
        {
            ShopCart cart = (ShopCart)HttpContext.Items["cart"];
            if (cart == null)
            {
                cart = new ShopCart();
                HttpContext.Items["cart"] = cart;
            }
            return cart;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Goods = db.Goods.ToList();
            return View(ViewBag);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create(Item item)
        {
            db.Goods.Add(item);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Buy(int? id)
        {
            if (id != null)
            {

                var item = db.Goods.FirstOrDefault(c => c.Id == id);
                ViewBag.Item = item;
                return View(ViewBag);
            }

            return NotFound(404);
        }

        [HttpPost]
        public IActionResult Buy()
        {
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult DealayPage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddToCart(int? id)
        {
            var item = db.Goods.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                ItemToBuy prod = new ItemToBuy{Item = item,Quantity = 1};
                var cart = GetCart();
                    cart.Add(prod);
                    HttpContext.Items["cart"] = cart;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CartIndex()
        {
            var items = GetCart().Items;
            ViewBag.Items = items;
            return View();
        }
    }
}

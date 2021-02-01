using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web_Shop.Models;

namespace Web_Shop.Controllers
{
    public class GoodsController : Controller
    {
        private GoodsContext db;

        public GoodsController(IGoodsContext context)
        {
            db = (GoodsContext) context;
        }
        public IActionResult Index()
        {
            ViewBag.Goods = db.Goods.ToList();
            return View(ViewBag);
        }
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

    }
}

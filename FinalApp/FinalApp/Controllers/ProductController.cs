using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalApp.Data;
using FinalApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalApp.Controllers
{
    public class ProductController : Controller
    {
        public ApplicationContext _context { get; set; }
        public ProductController(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();
            return View(await _context.Products.AsNoTracking().OrderBy(a => a.ExpirationDate).ToListAsync());
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<Category> NewCategory = new List<Category>();
            foreach (var c in _context.Categories)
            {
                NewCategory.Add(c);
            }
            ViewData["NewCategory"] = NewCategory;

            return View();
        }


        [Route("Edit/{id:Guid}")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<Category> NewCategory = new List<Category>();
            foreach (var c in _context.Categories)
            {
                NewCategory.Add(c);
            }
            ViewData["NewCategory"] = NewCategory;

            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(new ProductViewModel(product));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Product product)
        {
            try
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Delete(Product product)
        {
            var c = await _context.Products.FindAsync(product.ProductId);
            _context.Products.Remove(c);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", _context.Products);
        }


        [HttpPost]
        [Route("Edit/{id:Guid}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, [Bind("ProductId,Category,CategoryId,ProductName,PurchaseDate,ExpirationDate")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }
            _context.Update(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", _context.Products);
        }

    }
}
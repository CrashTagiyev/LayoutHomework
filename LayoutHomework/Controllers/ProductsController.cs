using LayoutHomework.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LayoutHomework.Controllers
{
	public class ProductsController : Controller
	{
		private ProductsDb _context { get; set; }
		public ProductsController(ProductsDb context)
		{
			_context = context;

		}

		public IActionResult Index()
		{
			List<Products> products = _context.Products.ToList();
			return View(products);
		}

		

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateProduct(Products newProduct)
		{
			Console.WriteLine("Hi");
			Console.WriteLine(newProduct.Name);
			_context.Products.Add(newProduct);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult Delete(int Id)
		{
			Products? deletingProduct = _context.Products.FirstOrDefault(x => x.Id == Id);
			if (deletingProduct != null)
			{
				_context.Products.Remove(deletingProduct);
				_context.SaveChanges();
			}
			return RedirectToAction("Index");
		}


        public IActionResult GetById(int id)
        {
            Products? product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                return View("ProductById", product);
            }
            return View("Product404");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}

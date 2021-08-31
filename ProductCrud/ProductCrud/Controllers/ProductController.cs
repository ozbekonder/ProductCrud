using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCrud.Models;
using ProductCrud.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCrud.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository productRepository = new ProductRepository();
        // GET: ProductController
        public ActionResult Index()
        {
            var list=productRepository.GetAllActiveProducts();
            return View(list);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View(new ProductCreateModel());
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreateModel model)
        {
            try
            {
                productRepository.CreateProduct(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View(productRepository.GetProduct(id));
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductEditModel model)
        {
            try
            {
                productRepository.EditProduct(model);
                return RedirectToAction("Index", "Product");
            }
            catch
            {
                return RedirectToAction("Index", "Product");
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            productRepository.DeleteProduct(id);
            return RedirectToAction("Index", "Product");
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

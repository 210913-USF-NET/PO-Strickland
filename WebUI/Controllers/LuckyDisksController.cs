using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreBL;
using Models;

namespace WebUI.Controllers
{

    public class LuckyDisksController : Controller
    {
        private IBL _bl;
        // GET: LuckyDisksController
        public LuckyDisksController(IBL bl)
        {
            _bl = bl;
        }
        public ActionResult Index()
        {
            List<Product> allProd = _bl.GetAllProducts();
            
            return View(allProd);
        }

        // GET: LuckyDisksController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LuckyDisksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                //the data in my form is valid
                if (ModelState.IsValid) //this tells us if there are any errors persisting
                {
                    _bl.AddProduct(product);
                    return RedirectToAction(nameof(Index));
                }
                //if the 'IF' statement is not valid or not true, then have the user try again
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: LuckyDisksController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LuckyDisksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: LuckyDisksController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LuckyDisksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View();
            }
        }
    }
}

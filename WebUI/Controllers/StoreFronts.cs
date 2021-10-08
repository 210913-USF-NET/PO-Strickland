using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreBL;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class StoreFronts : Controller
    {
        private IBL _bl;
        public StoreFronts(IBL bl)
        {
            _bl = bl;
        }
        // GET: StoreFronts
        public ActionResult Index()
        {
            //List<StoreFronts> stores = _bl.GetAllStoreFronts();
            List<StoreFrontsVM> allStores = _bl.GetAllStoreFronts().Select(r => new StoreFrontsVM(r)).ToList();
            return View(allStores);
        }

        // GET: StoreFronts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StoreFronts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoreFronts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StoreFrontsVM storefront)
        {
            try
            {
                //the data in my form is valid
                if (ModelState.IsValid) //this tells us if there are any errors persisting
                {
                    _bl.AddStoreFront(storefront.ToModel());
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

        // GET: StoreFronts/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new StoreFrontsVM(_bl.GetOneStoreById(id)));
        }

        // POST: StoreFronts/Edit/5
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

        // GET: StoreFronts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StoreFronts/Delete/5
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

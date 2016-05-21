using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bitaka.Models;

namespace Bitaka.Controllers
{
    public class AllProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /AllProducts/
        public ActionResult Index(string searchString, string sortOrder, string cat)
        {
            var products = from m in db.Products
                         select m;

            // ViewBag
            ViewBag.searchString = searchString;
            ViewBag.cat = cat;
            ViewBag.Price = sortOrder == "price" ? "price_desc" : "price";
            ViewBag.Date = sortOrder == "date" ? "date_desc" : "date";

            // Search
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => (s.Name.Contains(searchString) && s.Description.Contains(searchString)) || (s.Name.Contains(searchString) || s.Description.Contains(searchString)));
                //return View(products.ToList());
            }

            // Sort
            switch (sortOrder)
            {
                case "price":
                    products = products.OrderBy(m => m.Price);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(m => m.Price);
                    break;
                case "date":
                    products = products.OrderBy(m => m.Created);
                    break;
                case "date_desc":
                    products = products.OrderByDescending(m => m.Created);
                    break;
                default:
                    products = products.OrderBy(m => m.Created);
                    break;
            }

            // Cat
            if (cat != null && cat != "all")
            {
                products = products.Where(s => s.Category.Contains(cat));
            }
 


            return View(products.ToList());
        }

        

        // GET: /AllProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: /AllProducts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /AllProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,Name,Price,Description,Category,Used,Created,Image")] Products products)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(products);
        }

        // GET: /AllProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: /AllProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,Name,Price,Description,Category,Used,Created,Image")] Products products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(products);
        }

        // GET: /AllProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: /AllProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

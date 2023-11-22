using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Test2.Models;

namespace Test2.Controllers
{
    public class DeviceModelsController : Controller
    {
        private Model1 db = new Model1();

        // GET: DeviceModels
        public ActionResult Index()
        {
            var deviceModels = db.DeviceModels.Include(d => d.Brand).Include(d => d.OpSystem);
            return View(deviceModels.ToList());
        }

        // GET: DeviceModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceModel deviceModel = db.DeviceModels.Find(id);
            if (deviceModel == null)
            {
                return HttpNotFound();
            }
            return View(deviceModel);
        }

        // GET: DeviceModels/Create
        public ActionResult Create()
        {
            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName");
            ViewBag.OpSystemID = new SelectList(db.OpSystems, "OpSystemID", "OpSystemName");
            return View();
        }

        // POST: DeviceModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModelID,ModelName,BrandID,Price,RAM,StorageCapacity,OpSystemID")] DeviceModel deviceModel)
        {
            if (ModelState.IsValid)
            {
                db.DeviceModels.Add(deviceModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName", deviceModel.BrandID);
            ViewBag.OpSystemID = new SelectList(db.OpSystems, "OpSystemID", "OpSystemName", deviceModel.OpSystemID);
            return View(deviceModel);
        }

        // GET: DeviceModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceModel deviceModel = db.DeviceModels.Find(id);
            if (deviceModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName", deviceModel.BrandID);
            ViewBag.OpSystemID = new SelectList(db.OpSystems, "OpSystemID", "OpSystemName", deviceModel.OpSystemID);
            return View(deviceModel);
        }

        // POST: DeviceModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModelID,ModelName,BrandID,Price,RAM,StorageCapacity,OpSystemID")] DeviceModel deviceModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deviceModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName", deviceModel.BrandID);
            ViewBag.OpSystemID = new SelectList(db.OpSystems, "OpSystemID", "OpSystemName", deviceModel.OpSystemID);
            return View(deviceModel);
        }

        // GET: DeviceModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceModel deviceModel = db.DeviceModels.Find(id);
            if (deviceModel == null)
            {
                return HttpNotFound();
            }
            return View(deviceModel);
        }

        // POST: DeviceModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeviceModel deviceModel = db.DeviceModels.Find(id);
            db.DeviceModels.Remove(deviceModel);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HMS.BAL;
using HMS.BAL.Models;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Controllers
{
    [CustomAuthenticationFilter]
    [CustomAuthorize("Admin")]
    public class StaffController : Controller
    {      

        StaffService _staffService = new StaffService();
        // GET: Staff
        public ActionResult Index()
        {
            return View(_staffService.GetListing());
        }

        // GET: Staff/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffModel staffModel = _staffService.GetById(id??0);
            if (staffModel == null)
            {
                return HttpNotFound();
            }
            return View(staffModel);
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            return View(new StaffModel());
        }

        // POST: Staff/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,PhoneNumber,Address,Salary,Category")] StaffModel staffModel)
        {
            if (ModelState.IsValid)
            {
                _staffService.Add(staffModel);
                
                return RedirectToAction("Index");
            }

            return View(staffModel);
        }

        // GET: Staff/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffModel staffModel = _staffService.GetById(id??0);
            if (staffModel == null)
            {
                return HttpNotFound();
            }
            return View(staffModel);
        }

        // POST: Staff/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,PhoneNumber,Address,Salary,Category")] StaffModel staffModel)
        {
            if (ModelState.IsValid)
            {
                _staffService.Update(staffModel);
                return RedirectToAction("Index");
            }
            return View(staffModel);
        }

        // GET: Staff/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffModel staffModel = _staffService.GetById(id??0);
            if (staffModel == null)
            {
                return HttpNotFound();
            }
            return View(staffModel);
        }

        // POST: Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _staffService.Delete(id);
            return RedirectToAction("Index");
        }

       
    }
}

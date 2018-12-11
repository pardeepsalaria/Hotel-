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
    public class RoomController : Controller
    {
        RoomService _roomService = new RoomService();

        // GET: Room
        public ActionResult Index()
        {
            return View(_roomService.GetListing());
        }

        // GET: Room/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomModel roomModel = _roomService.GetById(id??0);
            if (roomModel == null)
            {
                return HttpNotFound();
            }
            return View(roomModel);
        }

        // GET: Room/Create
        public ActionResult Create()
        {
            return View(new RoomModel());
        }

        // POST: Room/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RoomNumber,RoomType,TV,HotWater,Towel,IsAvailable,Price")] RoomModel roomModel)
        {
            if (ModelState.IsValid)
            {
                _roomService.Add(roomModel);
                return RedirectToAction("Index");
            }

            return View(roomModel);
        }

        // GET: Room/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomModel roomModel = _roomService.GetById(id??0);
            if (roomModel == null)
            {
                return HttpNotFound();
            }
            return View(roomModel);
        }

        // POST: Room/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RoomNumber,RoomType,TV,HotWater,Towel,IsAvailable,Price")] RoomModel roomModel)
        {
            if (ModelState.IsValid)
            {
                _roomService.Update(roomModel);
                return RedirectToAction("Index");
            }
            return View(roomModel);
        }

        // GET: Room/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomModel roomModel = _roomService.GetById(id??0);
            if (roomModel == null)
            {
                return HttpNotFound();
            }
            return View(roomModel);
        }

        // POST: Room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _roomService.Delete(id);
            return RedirectToAction("Index");
        }

       
    }
}

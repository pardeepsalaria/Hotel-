using HMS.BAL;
using HMS.BAL.Models;
using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HotelManagementSystem.Controllers
{
    [CustomAuthenticationFilter]
    [CustomAuthorize("User")]
    public class BookingController : Controller
    {
        BookingService _service = new BookingService();
        // GET: Booking
        public ActionResult Index()
        {
            
            return View(_service.RoomList());
        }

        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingModel BookingroomModel = _service.GetBookingByRoomId(id ?? 0);
            if (BookingroomModel == null)
            {
                return HttpNotFound();
            }
            return View(BookingroomModel);
            
            
        }

        public ActionResult Edit(int RoomId)
        {
            BookingModel booking = new BookingModel();

            RoomService serv = new RoomService();
            var room=serv.GetById(RoomId);
            booking.fromDate = DateTime.Now;
            booking.To = DateTime.Now;
            booking.RoomNumber = room.RoomNumber;


            return View(booking);

        }

        [HttpPost]
        public ActionResult Edit(BookingModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.fromDate > model.To)
            {
                ModelState.AddModelError("", "From date must be less then to date!");
                return View(model);
            }
            if (model.fromDate < DateTime.Now)
            {
                ModelState.AddModelError("", "From date must be greater then today date!");
                return View(model);
            }

            model.UserId = 1;
            _service.BookRoom(model);

            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult Cancel(int roomId)
        {
            _service.CancelBooking(roomId);

            return Json(true, JsonRequestBehavior.AllowGet);

        }
        
    }
}
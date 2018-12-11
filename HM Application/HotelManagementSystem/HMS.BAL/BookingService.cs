using HMS.BAL.Models;
using HMS.DAL;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HMS.BAL
{
    public class BookingService
    {

        public List<RoomModel> RoomList()
        {
            RoomService obj = new RoomService();
            return obj.GetListing();
        }


        public void BookRoom(BookingModel model)
        {

            using (HMSEntities dbContext = new HMSEntities())
            {
                tbl_RoomBooking entity = new tbl_RoomBooking();
                entity.FromDate = model.fromDate.Value;
                entity.ToDate = model.To.Value;
                entity.RoomId = model.RoomId;
                entity.UserId = model.UserId;
                dbContext.tbl_RoomBooking.Add(entity);
                dbContext.SaveChanges();

                //updateing room status
              var room=  dbContext.tbl_Room.Where(x => x.Id == model.RoomId).FirstOrDefault();
                room.IsAvailable = false;
                dbContext.Entry(room).State = EntityState.Modified;
                dbContext.SaveChanges();

            }
        }

        public void CancelBooking(int RoomId)
        {

            using (HMSEntities dbContext = new HMSEntities())
            {
                var booking=dbContext.tbl_RoomBooking.Where(x => x.RoomId == RoomId).FirstOrDefault();
                if (booking != null)
                {
                    dbContext.tbl_RoomBooking.Remove(booking);
                }
                var room = dbContext.tbl_Room.Where(x => x.Id == RoomId).FirstOrDefault();
                if (room != null)
                {
                    room.IsAvailable = true;
                    dbContext.Entry(room).State = EntityState.Modified;
                }
                dbContext.SaveChanges();
            }
        }

        public BookingModel GetBookingByRoomId(int RoomId)
        {
            BookingModel model = new BookingModel();
            using (HMSEntities dbContext = new HMSEntities())
            {
                var result=  (from p in dbContext.tbl_RoomBooking
                                   join r in dbContext.tbl_Room on p.RoomId equals r.Id
                                   where p.RoomId==RoomId
                                   select new BookingModel
                                   {
                                       To=p.ToDate,
                                       Id=r.Id,
                                       HotWater=r.HotWater,
                                       fromDate=p.FromDate,
                                       IsAvailable=r.IsAvailable,
                                       Price=r.Price,
                                       RoomNumber=r.RoomNumber

                                   }).FirstOrDefault();
                return result;
            }
        }
    }
}

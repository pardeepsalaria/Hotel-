using HMS.BAL.Models;
using HMS.DAL;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace HMS.BAL
{
    public class RoomService
    {

        public void Add(RoomModel model)
        {
            using (HMSEntities dbContext = new HMSEntities())
            {
                tbl_Room entity = new tbl_Room();
                entity.HotWater = model.HotWater;
                entity.IsAvailable = model.IsAvailable;
                entity.RoomNumber = model.RoomNumber;
                entity.RoomType = model.RoomType;
                entity.Towel = model.Towel;
                entity.TV = model.TV;
                entity.Price = model.Price;

                dbContext.tbl_Room.Add(entity);
                dbContext.SaveChanges();
            }


        }

        public void Update(RoomModel model)
        {
            using (HMSEntities dbContext = new HMSEntities())
            {
                var entity = dbContext.tbl_Room.Where(x => !x.IsDeleted && x.Id == model.Id).FirstOrDefault();
                entity.HotWater = model.HotWater;
                entity.IsAvailable = model.IsAvailable;
                entity.RoomNumber = model.RoomNumber;
                entity.RoomType = model.RoomType;
                entity.Towel = model.Towel;
                entity.TV = model.TV;
                entity.Price = model.Price;
                dbContext.Entry(entity).State = EntityState.Modified;
                dbContext.SaveChanges();
            }


        }

        public RoomModel GetById(int Id)
        {

            RoomModel model = null;
            using (HMSEntities dbContext = new HMSEntities())
            {
                var entity = dbContext.tbl_Room.Where(x => x.Id == Id && !x.IsDeleted).FirstOrDefault();
                if (entity != null)
                {
                    model = new RoomModel();
                    model.HotWater = entity.HotWater;
                    model.IsAvailable = entity.IsAvailable;
                    model.RoomNumber = entity.RoomNumber;
                    model.RoomType = entity.RoomType;
                    model.Towel = entity.Towel;
                    model.TV = entity.TV;
                    model.Id = entity.Id;
                    model.Price = entity.Price;
                }

            }
            return model;

        }

        public List<RoomModel> GetListing()
        {
            using (HMSEntities dbContext = new HMSEntities())
            {
                return (from p in dbContext.tbl_Room
                        where !p.IsDeleted
                        select new RoomModel
                        {
                            Id = p.Id,
                            HotWater = p.HotWater,
                            IsAvailable = p.IsAvailable,
                            RoomNumber = p.RoomNumber,
                            RoomType = p.RoomType,
                            Towel = p.Towel,
                            TV = p.TV,
                            Price = p.Price,
                        }).ToList();
            }

        }


        public void Delete(int Id)
        {
            using (HMSEntities dbContext = new HMSEntities())
            {
                var entity = dbContext.tbl_Room.Where(x => !x.IsDeleted && x.Id == Id).FirstOrDefault();

                if (entity != null)
                {
                    entity.IsDeleted = true;
                    dbContext.Entry(entity).State = EntityState.Modified;
                    dbContext.SaveChanges();

                }

                
            }


        }

    }
}

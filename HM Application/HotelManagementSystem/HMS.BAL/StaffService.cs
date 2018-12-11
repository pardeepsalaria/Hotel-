using HMS.BAL.Models;
using HMS.DAL;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace HMS.BAL
{
    public class StaffService
    {
       
        public void Add(StaffModel model)
        {
            using (HMSEntities dbContext = new HMSEntities())
            {
                tbl_Staff entity = new tbl_Staff();
                entity.Address = model.Address;
                entity.Category = model.Category;
                entity.Name = model.Name;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Salary = model.Salary;

                dbContext.tbl_Staff.Add(entity);
                dbContext.SaveChanges();
            }


        }

        public void Update(StaffModel model)
        {
            using (HMSEntities dbContext = new HMSEntities())
            {
                var entity = dbContext.tbl_Staff.Where(x => !x.IsDeleted && x.Id == model.Id).FirstOrDefault();
                entity.Address = model.Address;
                entity.Category = model.Category;
                entity.Name = model.Name;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Salary = model.Salary;
                dbContext.Entry(entity).State = EntityState.Modified;
                dbContext.SaveChanges();
            }


        }

        public StaffModel GetById(int Id)
        {
            
                StaffModel model = null;
            using (HMSEntities dbContext = new HMSEntities())
            {
                var entity = dbContext.tbl_Staff.Where(x => x.Id == Id).FirstOrDefault();
                if (entity != null)
                {
                    model = new StaffModel();
                    model.Category = entity.Category ?? 0;
                    model.Address = entity.Address;
                    model.Id = entity.Id;
                    model.Name = entity.Name;
                    model.PhoneNumber = entity.PhoneNumber;
                    model.Salary = entity.Salary ?? 0;
                    model.IsDeleted = entity.IsDeleted;
                }

            }
            return model;

        }

        public List<StaffModel> GetListing()
        {
            using (HMSEntities dbContext = new HMSEntities())
            {
                return (from p in dbContext.tbl_Staff
                        where !p.IsDeleted
                        select new StaffModel
                        {
                            Category = p.Category ?? 0,
                            Address = p.Address,
                            Id = p.Id,
                            Name = p.Name,
                            PhoneNumber = p.PhoneNumber,
                            Salary = p.Salary ?? 0,
                            IsDeleted = p.IsDeleted,
                        }).ToList();
            }
            
        }


        public void Delete(int Id)
        {
            using (HMSEntities dbContext = new HMSEntities())
            {
                var entity = dbContext.tbl_Staff.Where(x => !x.IsDeleted && x.Id == Id).FirstOrDefault();

                if (entity != null)
                {
                    entity.IsDeleted = true;

                }

                dbContext.Entry(entity).State = EntityState.Modified;
                dbContext.SaveChanges();
            }


        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using HMS.DAL;

namespace HMS.BAL.Models
{
    public class StaffModel
    {    

        public int Id { get; set; }
        public string  Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }
        public int Category { get; set; }
        public bool IsDeleted { get; set; }

        public List<StaffType> StaffTypes {
            get {
                using (HMSEntities dbContext = new HMSEntities())
                {
                   return dbContext.tbl_StaffCategory.Select(x=>new StaffType {Id=x.Id,Name=x.Name }).ToList();
                }
                
            }
            
        }
        public string CategoryName
        {
            get
            {
                using (HMSEntities dbContext = new HMSEntities())
                {
                    var category1 = dbContext.tbl_StaffCategory.Where(x => x.Id == Category).FirstOrDefault();
                   if (category1 != null)
                    {
                        return category1.Name;
                    }
                    else
                    {
                        return string.Empty;
                    }
                       
                }

            }

        }
    }
}
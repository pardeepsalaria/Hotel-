using HMS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BAL.Models
{
   public class RoomModel
    {
        public int Id { get; set; }
        [Display(Name = "Room Number")]
        public string RoomNumber { get; set; }
        
        [Display(Name = "AC/non-AC")]
        public int RoomType { get; set; }
        public bool TV { get; set; }
        public bool HotWater { get; set; }
        public bool Towel { get; set; }
        [Required]
        [Display(Name = "Tariff Per Day ($)")]
        public int? Price { get; set; }
        [Display(Name = "Is Room Available?")]
        public bool IsAvailable { get; set; }

        public List<RoomTypeModel> RoomTypes
        {
            get
            {
                using (HMSEntities dbContext = new HMSEntities())
                {
                    return dbContext.tbl_RoomType.Select(x => new RoomTypeModel { Id = x.Id, Name = x.Name }).ToList();
                }

            }

        }

        public string RoomTypeName
        {
            get
            {
                using (HMSEntities dbContext = new HMSEntities())
                {
                    var category1 = dbContext.tbl_RoomType.Where(x => x.Id == RoomType).FirstOrDefault();
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

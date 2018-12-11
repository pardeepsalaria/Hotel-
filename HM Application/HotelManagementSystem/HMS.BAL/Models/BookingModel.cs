using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BAL.Models
{
   public class BookingModel
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public int RoomType { get; set; }
        public bool TV { get; set; }
        public bool HotWater { get; set; }
        public bool Towel { get; set; }
        public bool IsAvailable { get; set; }
        [Display(Name = "From Date")]
        [DataType(DataType.Date)]
        [RequiredAttribute]
        public DateTime? fromDate { get; set; }
        [Display(Name = "To Date")]
        [RequiredAttribute]
        [DataType(DataType.Date)]
        //[DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? To { get; set; }

        public int? Price { get; set; }

        public int RoomId { get; set; }
        public int UserId { get; set; }

    }
}

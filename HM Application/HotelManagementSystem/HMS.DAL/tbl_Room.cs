//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HMS.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Room
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Room()
        {
            this.tbl_RoomBooking = new HashSet<tbl_RoomBooking>();
        }
    
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public int RoomType { get; set; }
        public bool TV { get; set; }
        public bool HotWater { get; set; }
        public bool Towel { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAvailable { get; set; }
        public Nullable<int> Price { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_RoomBooking> tbl_RoomBooking { get; set; }
    }
}
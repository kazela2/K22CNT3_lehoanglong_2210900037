//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace K22CNT3_lehoanglong_2210900037.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class thamgia
    {
        public int tg_id { get; set; }
        public int user_id { get; set; }
        public int ev_id { get; set; }
        public Nullable<System.DateTime> ngaythamgia { get; set; }
    
        public virtual Sukien Sukien { get; set; }
        public virtual User User { get; set; }
    }
}

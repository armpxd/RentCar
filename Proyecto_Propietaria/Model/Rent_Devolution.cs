//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto_Propietaria.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rent_Devolution
    {
        public int Rent_id { get; set; }
        public int Employee_id { get; set; }
        public int Car_id { get; set; }
        public int Client_id { get; set; }
        public System.DateTime date_rent { get; set; }
        public Nullable<System.DateTime> date_devolution { get; set; }
        public int Cost { get; set; }
        public int days { get; set; }
        public string Comment { get; set; }
        public bool State { get; set; }
    
        public virtual Car Car { get; set; }
        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
    }
}

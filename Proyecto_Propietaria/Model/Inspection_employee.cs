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
    
    public partial class Inspection_employee
    {
        public int inspection_employee_id { get; set; }
        public int Employee_id { get; set; }
        public int Inspection_id { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Inspection Inspection { get; set; }
    }
}

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
    
    public partial class Car
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Car()
        {
            this.Inspection = new HashSet<Inspection>();
            this.Rent_Devolution = new HashSet<Rent_Devolution>();
        }
    
        public int Car_id { get; set; }
        public string Description { get; set; }
        public string Chassis { get; set; }
        public string license_plate { get; set; }
        public int Type_car_id { get; set; }
        public int Brand_id { get; set; }
        public string Fuel_id { get; set; }
        public bool State { get; set; }
    
        public virtual Brand Brand { get; set; }
        public virtual Type_car Type_car { get; set; }
        public virtual Type_fuel Type_fuel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inspection> Inspection { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rent_Devolution> Rent_Devolution { get; set; }
    }
}
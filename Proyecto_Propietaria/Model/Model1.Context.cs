﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RentCarEntities : DbContext
    {
        public RentCarEntities()
            : base("name=RentCarEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Inspection> Inspection { get; set; }
        public virtual DbSet<Inspection_employee> Inspection_employee { get; set; }
        public virtual DbSet<Model_car> Model_car { get; set; }
        public virtual DbSet<Rent_Devolution> Rent_Devolution { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Type_car> Type_car { get; set; }
        public virtual DbSet<Type_fuel> Type_fuel { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}

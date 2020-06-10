﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Propietaria.Model;
using Proyecto_Propietaria.Mantenimiento.Marca;
using Proyecto_Propietaria.Renta;

namespace Proyecto_Propietaria
{
    public partial class Renta_main : Form
    {
        int employee;
        public Renta_main()
        {
            InitializeComponent();
        }

        public Renta_main(int employee)
        {
            this.employee = employee;
            InitializeComponent();
        }

        private void Brand_main_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void reload()
        {
            using (RentCarEntities db = new RentCarEntities())
            {
                var car = db.Car.Where(x => x.State == true).Select(
                  x => new
                  {
                      Id = x.Car_id,
                      Descripcion = x.Description,
                      Chasis = x.Chassis,
                      Placa = x.license_plate,
                      Vehiculo = x.Type_car.Description,
                      Marca = x.Brand.Description,
                      Tipo_Combustible = x.Type_fuel.Description,
                      Estado = x.State ? "Activo": "Desactivado"
                  }).ToList();

                dataGridView1.DataSource = car;
            }
        }

        private int? GetId()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int? id = GetId();

            Inspeccionar inspeccionar = new Inspeccionar(id, employee);
            inspeccionar.ShowDialog();
            reload();

        }
    }
}
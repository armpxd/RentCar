using System;
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
    public partial class Devolucion_main : Form
    {
        int employee;
        public Devolucion_main()
        {
            InitializeComponent();
        }

        public Devolucion_main(int employee)
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
                var renta = db.Rent_Devolution.Where(x => x.State == true).Select(
                  x => new
                  {
                      Id = x.Rent_id,
                      Cliente = x.Client.Name,
                      vehiculo = x.Car.Description,
                      Chasis = x.Car.Chassis,
                      Placa = x.Car.license_plate,
                      Empleado = x.Employee.Name,
                      Tipo_Combustible = x.Car.Type_fuel.Description,
                      Estado = x.State ? "Activo" : "Desactivado"
                  }).ToList();

                dataGridView1.DataSource = renta;
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
            Devolucion devolucion = new Devolucion(id);
            devolucion.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                reload();
            }
             using (RentCarEntities db = new RentCarEntities())
            {
                var renta = db.Rent_Devolution.Where(x => (x.State == true) && (x.Client.Name.Contains(textBox1.Text) || x.Car.Description.Contains(textBox1.Text)
                                                       || x.Car.Chassis.Contains(textBox1.Text) || x.Car.license_plate.Contains(textBox1.Text)
                                                       || x.Employee.Name.Contains(textBox1.Text) 
                    )).Select(
                          x => new
                          {
                              Id = x.Rent_id,
                              Cliente = x.Client.Name,
                              vehiculo = x.Car.Description,
                              Chasis = x.Car.Chassis,
                              Placa = x.Car.license_plate,
                              Empleado = x.Employee.Name,
                              Tipo_Combustible = x.Car.Type_fuel.Description,
                              Estado = x.State ? "Activo" : "Desactivado"
                          }).ToList();

                dataGridView1.DataSource = renta;
            }
        }
    }
}

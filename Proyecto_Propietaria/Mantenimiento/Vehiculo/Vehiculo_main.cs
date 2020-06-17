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

namespace Proyecto_Propietaria
{
    public partial class Vehiculo_main : Form
    {
        public Vehiculo_main()
        {
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
                var car = db.Car.Select(
                    x => new
                    {
                        Id = x.Car_id,
                        Description = x.Description,
                        Chasis = x.Chassis,
                        Placa = x.license_plate,
                        Tipo_de_Vehiculo = x.Type_car.Description,
                        Marca = x.Brand.Description,
                        Combustible = x.Type_fuel.Description,
                        Estado = x.State? "Activo" : "Inactivo"
                    }).ToList();

                dataGridView2.DataSource = car;
            }
        }

        private int? GetId()
        {
            try
            {
                return int.Parse(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            int? id = GetId();

            if (id != null)
            {
                Vehiculo_crear_editar editar = new Vehiculo_crear_editar(id);
                editar.ShowDialog();
                reload();
            }
        }

        private void Crear_Click(object sender, EventArgs e)
        {
            Vehiculo_crear_editar crear = new Vehiculo_crear_editar();
            crear.ShowDialog();
            reload();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int? id = GetId();

            DialogResult dialogResult = MessageBox.Show("Desactivar el registro", "Desea desactivar el registro?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                using (RentCarEntities db = new RentCarEntities())
                {
                    var target = db.Car.FirstOrDefault(x => x.Car_id == id);

                    target.State = false;
                    db.SaveChanges();
                    MessageBox.Show("Se a desactivado correctamente");
                    reload();

                }
            }
            else if (dialogResult == DialogResult.No)
            {
                this.Close();
            }
            

            }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                reload();
            }

            using (RentCarEntities db = new RentCarEntities())
            {
                var car = db.Car.Where(x => x.Description.Contains(textBox1.Text) || x.Type_car.Description.Contains(textBox1.Text)
                                        || x.Chassis.Contains(textBox1.Text) || x.license_plate.Contains(textBox1.Text) 
                                        || x.Brand.Description.Contains(textBox1.Text))
                    .Select(
                        x => new
                        {
                            Id = x.Car_id,
                            Description = x.Description,
                            Chasis = x.Chassis,
                            Placa = x.license_plate,
                            Tipo_de_Vehiculo = x.Type_car.Description,
                            Marca = x.Brand.Description,
                            Combustible = x.Type_fuel.Description,
                            Estado = x.State ? "Activo" : "Inactivo"
                        }).ToList();

                dataGridView2.DataSource = car;
            }
        }
    }
}

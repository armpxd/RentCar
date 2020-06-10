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

namespace Proyecto_Propietaria.Mantenimiento.Marca
{
    public partial class Vehiculo_crear_editar : Form
    {
        public int? id;
        public Vehiculo_crear_editar()
        {
            InitializeComponent();
            using (RentCarEntities db = new RentCarEntities())
            {
                comboFuel.DataSource = (db.Type_fuel.Select(x => x.Description).ToList());
                comboMarca.DataSource = (db.Brand.Select(x => x.Description).ToList());
                combovehiculo.DataSource = (db.Type_car.Select(x => x.Description).ToList());
            }
        }
        public Vehiculo_crear_editar(int? id = null)
        {
            InitializeComponent();
            this.id = id;
            if (id !=null)
            {
                loadData();
            }
        }

        private void loadData()
        {
            using (RentCarEntities db = new RentCarEntities())
            {
                var target = db.Car.FirstOrDefault(x => x.Car_id == id);
                comboFuel.DataSource = (db.Type_fuel.Select(x => x.Description).ToList());
                comboMarca.DataSource = (db.Brand.Select(x => x.Description).ToList());
                combovehiculo.DataSource = (db.Type_car.Select(x => x.Description).ToList());
                textBoxDescription.Text = target.Description.Trim();
                textBoxChasis.Text = target.Chassis.Trim();
                textBoxPlaca.Text = target.license_plate.Trim();
                checkBox1.Checked = target.State ? checkBox1.Checked = true : checkBox1.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (RentCarEntities db = new RentCarEntities())
            {
                var target = db.Car.FirstOrDefault(x => x.Car_id == id);

                var vehiculo = combovehiculo.SelectedItem;
                var combustible = comboFuel.SelectedItem;
                var marca = comboMarca.SelectedItem;

                if (target == null)
                {
                    Car car = new Car();
                   

                    car.Description = textBoxDescription.Text.Trim();
                    car.Chassis = textBoxChasis.Text.Trim();
                    car.license_plate = textBoxPlaca.Text.Trim();
                    car.Type_car_id = db.Type_car.FirstOrDefault(x => x.Description == vehiculo).Type_car_id;
                    car.Brand_id = db.Brand.FirstOrDefault(x => x.Description == marca).Brand_id;
                    car.Fuel_id = db.Type_fuel.FirstOrDefault(x => x.Description == combustible).Fuel_id;
                    car.State = checkBox1.Checked ? true : false;
                    db.Car.Add(car);
                    MessageBox.Show("Se ha creo correctamente");
                }
                else
                {
                    target.Description = textBoxDescription.Text.Trim();
                    target.Chassis = textBoxChasis.Text.Trim();
                    target.license_plate = textBoxPlaca.Text.Trim();
                    target.Type_car_id = db.Type_car.FirstOrDefault(x => x.Description == vehiculo).Type_car_id;
                    target.Brand_id = db.Brand.FirstOrDefault(x => x.Description == marca).Brand_id;
                    target.Fuel_id = db.Type_fuel.FirstOrDefault(x => x.Description == combustible).Fuel_id;
                    target.State = checkBox1.Checked ? true : false;
                    MessageBox.Show("Se ha modificado correctamente");
                }
                db.SaveChanges();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Modelo_crear_editar_Load(object sender, EventArgs e)
        {

        }
    }
}

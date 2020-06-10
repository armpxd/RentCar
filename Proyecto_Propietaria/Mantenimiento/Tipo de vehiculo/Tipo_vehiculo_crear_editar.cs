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
    public partial class Tipo_vehiculo_crear_editar : Form
    {
        public int? id;
        public Tipo_vehiculo_crear_editar()
        {
            InitializeComponent();
        }
        public Tipo_vehiculo_crear_editar(int? id = null)
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
                var target = db.Type_car.FirstOrDefault(x => x.Type_car_id == id);
                textBox1.Text = target.Description.Trim();
                checkBox1.Checked = target.State ? checkBox1.Checked = true : checkBox1.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (RentCarEntities db = new RentCarEntities())
            {
                var target = db.Type_car.FirstOrDefault(x => x.Type_car_id == id);

                if (target == null)
                {
                    Type_car car = new Type_car();
                    car.Description = textBox1.Text.Trim();
                    car.State = checkBox1.Checked ? true : false;
                    db.Type_car.Add(car);
                    MessageBox.Show("Se ha creo correctamente");
                }
                else
                {
                    target.Description = textBox1.Text.Trim();
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
    }
}

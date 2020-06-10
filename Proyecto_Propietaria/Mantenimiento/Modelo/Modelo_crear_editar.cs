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
    public partial class Modelo_crear_editar : Form
    {
        public int? id;
        public Modelo_crear_editar()
        {
            InitializeComponent();
            using (RentCarEntities db = new RentCarEntities())
            {
                comboBox1.DataSource = (db.Brand.Select(x => x.Description).ToList());
            }
        }
        public Modelo_crear_editar(int? id = null)
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
                var target = db.Model_car.FirstOrDefault(x => x.Model_id == id);
                comboBox1.DataSource = (db.Brand.Select(x => x.Description).ToList());
                textBox1.Text = target.Description.TrimEnd();
                checkBox1.Checked = target.State ? checkBox1.Checked = true : checkBox1.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (RentCarEntities db = new RentCarEntities())
            {
                var target = db.Model_car.FirstOrDefault(x => x.Model_id == id);
                var y = comboBox1.SelectedItem;

                if (target == null)
                {
                    Model_car Modelo = new Model_car();
                    Modelo.Description = textBox1.Text.TrimEnd();
                    Modelo.Brand_id = db.Brand.FirstOrDefault(x => x.Description == y).Brand_id;
                    Modelo.State = checkBox1.Checked ? true : false;
                    db.Model_car.Add(Modelo);
                    MessageBox.Show("Se ha creo correctamente");
                }
                else
                {
                    target.Description = textBox1.Text.TrimEnd();
                    target.Brand_id = db.Brand.FirstOrDefault(x => x.Description == y).Brand_id;
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

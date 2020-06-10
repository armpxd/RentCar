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
    public partial class Empleado_crear_editar : Form
    {
        public int? id;
        public Empleado_crear_editar()
        {
            InitializeComponent();
        }
        public Empleado_crear_editar(int? id = null)
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
                var target = db.Employee.FirstOrDefault(x => x.Employee_id == id);
                textBox1.Text = target.Name.Trim();
                textBoxCedula.Text = target.Identification_card.Trim();
                numericUpDown1.Text = target.working_hours.Trim();
                numericUpDown2.Text = target.Comission_percentaje.ToString();
                dateTimePicker1.Value = target.date_admission;
                checkBox1.Checked = target.State ? checkBox1.Checked = true : checkBox1.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (RentCarEntities db = new RentCarEntities())
            {
                var target = db.Employee.FirstOrDefault(x => x.Employee_id == id);

                if (target == null)
                {
                    Employee empleado = new Employee();
                    empleado.Name = textBox1.Text.Trim();
                    empleado.Identification_card = textBoxCedula.Text.Trim();
                    empleado.working_hours = numericUpDown1.Text.Trim();
                    empleado.Comission_percentaje = numericUpDown2.Value;
                    empleado.date_admission = dateTimePicker1.Value;
                    empleado.State = checkBox1.Checked ? true : false;

                    db.Employee.Add(empleado);
                    MessageBox.Show("Se ha creo correctamente");
                }
                else
                {
                    target.Name = textBox1.Text.Trim();
                    target.Identification_card = textBoxCedula.Text.Trim();
                    target.working_hours = numericUpDown1.Text.Trim();
                    target.Comission_percentaje = numericUpDown2.Value;
                    target.date_admission = dateTimePicker1.Value;
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

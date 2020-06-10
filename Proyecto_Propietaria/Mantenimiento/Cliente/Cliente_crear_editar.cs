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
    public partial class Cliente_crear_editar : Form
    {
        public int? id;
        public Cliente_crear_editar()
        {
            InitializeComponent();
        }
        public Cliente_crear_editar(int? id = null)
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
                var target = db.Client.FirstOrDefault(x => x.Client_id == id);
                target.Person_type = target.Person_type.Trim();
                textBox1.Text = target.Name.Trim(); 
                textBoxCedula.Text = target.Identification_card.Trim();
                numericUpDown1.Value = target.credit_limit;
                textBoxTarjetaCR.Text = target.credit_card.Trim();
                comboBox1.Text = target.Person_type;
                checkBox1.Checked = target.State ? checkBox1.Checked = true : checkBox1.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (RentCarEntities db = new RentCarEntities())
            {
                var target = db.Client.FirstOrDefault(x => x.Client_id == id);

                if (target == null)
                {
                    Client cliente = new Client();
                    cliente.Name = textBox1.Text.Trim();
                    cliente.Identification_card = textBoxCedula.Text.Trim();
                    cliente.credit_card = textBoxTarjetaCR.Text.Trim();
                    cliente.credit_limit = (int)numericUpDown1.Value;
                    cliente.State = checkBox1.Checked ? true : false;
                    cliente.Person_type = comboBox1.SelectedItem.ToString();
                    db.Client.Add(cliente);
                    MessageBox.Show("Se ha creo correctamente");
                }
                else
                {
                    target.Name = textBox1.Text.Trim();
                    target.Identification_card = textBoxCedula.Text.Trim();
                    target.credit_card = textBoxTarjetaCR.Text.Trim();
                    target.credit_limit = (int)numericUpDown1.Value;
                    target.State = checkBox1.Checked ? true : false;
                    target.Person_type = comboBox1.SelectedItem.ToString();
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

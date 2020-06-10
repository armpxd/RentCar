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
using Proyecto_Propietaria.Utilitys;

namespace Proyecto_Propietaria.Mantenimiento.Marca
{
    public partial class Usuario_crear_editar : Form
    {
        public int? id;
        public Usuario_crear_editar()
        {
            InitializeComponent();
            using (RentCarEntities db = new RentCarEntities())
            {
                comboBox1.DataSource = (db.Employee.Select(x => x.Name).ToList());
            }
        }
        public Usuario_crear_editar(int? id = null)
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
                var target = db.User.FirstOrDefault(x => x.User_id == id);
                textBoxUser.Text = target.UserName.Trim();
                textBoxPass.Text = Utility.DesEncrypt(target.Password.Trim());
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (RentCarEntities db = new RentCarEntities())
            {
                var target = db.User.FirstOrDefault(x => x.User_id == id);

                if (target == null)
                {

                    var select = comboBox1.SelectedItem.ToString();
                    User usuario = new User();
                    usuario.UserName = textBoxUser.Text.Trim();
                    usuario.Password = Utility.Encrypt(textBoxPass.Text.Trim());
                    usuario.CreateDate = dateTimePicker1.Value;
                    usuario.Employee_id = db.Employee.FirstOrDefault(x => x.Name == select).Employee_id;
                  
                    usuario.state = checkBox1.Checked ? true : false;
                    db.User.Add(usuario);
                    MessageBox.Show("Se ha creo correctamente");
                }
                else
                {
                    //target.Name = textBoxUser.Text.Trim();
                    //target.Identification_card = textBoxPass.Text.Trim();
                    //target.credit_card = textBoxTarjetaCR.Text.Trim();
                    //target.credit_limit = (int)numericUpDown1.Value;
                    //target.State = checkBox1.Checked ? true : false;
                    //target.Person_type = comboBox1.SelectedItem.ToString();
                    //MessageBox.Show("Se ha modificado correctamente");
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

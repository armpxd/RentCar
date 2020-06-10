using Proyecto_Propietaria.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Propietaria.Utilitys;

namespace Proyecto_Propietaria.Login
{
    public partial class UserLogin : Form
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
   
            using (RentCarEntities db = new RentCarEntities())
            {
                var user = db.User.FirstOrDefault(x => x.UserName == textUser.Text.ToLower());

                if (textUser.Text == "" || textPass.Text == "")
                {
                    MessageBox.Show("Debe rellenar los campos");
                }
                else if (user != null)
                {
                    if (Utility.DesEncrypt(user.Password) == textPass.Text)
                    {
                        Form1 inicio = new Form1(user.Employee_id);
                        this.Visible = false;
                        inicio.ShowDialog();
                        
                    }
                    else
                    {
                        MessageBox.Show("Contraseña o Usuario Incorrecto");
                    }
                }
                else
                {
                    MessageBox.Show("Contraseña o Usuario Incorrecto");
                }
            }
                
        }
    }
}

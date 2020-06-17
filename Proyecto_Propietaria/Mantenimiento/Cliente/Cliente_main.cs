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
    public partial class Cliente_main : Form
    {
        public Cliente_main()
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
                var cliente = db.Client.Select(
                  x => new
                  {
                      Id = x.Client_id,
                      Nombre = x.Name,
                      Cedula = x.Identification_card,
                      Tarjeta = x.credit_card,
                      Limite = x.credit_limit,
                      Tipo = x.Person_type.Trim(),
                      Estado = x.State ? "Activo": "Desactivado"
                  }).ToList();

                dataGridView1.DataSource = cliente;
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
        private void button2_Click(object sender, EventArgs e)
        {
            int? id = GetId();

            if (id != null)
            {
                Cliente_crear_editar editar = new Cliente_crear_editar(id);
                editar.ShowDialog();
                reload();
            }
        }

        private void Crear_Click(object sender, EventArgs e)
        {
            Cliente_crear_editar crear = new Cliente_crear_editar();

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
                    var target = db.Client.FirstOrDefault(x => x.Client_id == id);

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
                var cliente = db.Client.Where(x => x.Name.Contains(textBox1.Text) || x.Identification_card.Contains(textBox1.Text)).Select(
                  x => new
                  {
                      Id = x.Client_id,
                      Nombre = x.Name,
                      Cedula = x.Identification_card,
                      Tarjeta = x.credit_card,
                      Limite = x.credit_limit,
                      Tipo = x.Person_type.Trim(),
                      Estado = x.State ? "Activo" : "Desactivado"
                  }).ToList();

                dataGridView1.DataSource = cliente;
            }
        }
    }
}

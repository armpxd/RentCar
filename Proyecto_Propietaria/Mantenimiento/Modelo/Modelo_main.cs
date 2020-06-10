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
    public partial class Modelo_main : Form
    {
        public Modelo_main()
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
                var modelo = db.Model_car.Select(
                    x => new
                    {
                        Id = x.Model_id,
                        Marca = x.Brand.Description,
                        Descripcion = x.Description,
                        Estado = x.State? "Activo" : "Inactivo"
                    }).ToList();

                dataGridView2.DataSource = modelo;
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
                Modelo_crear_editar editar = new Modelo_crear_editar(id);
                editar.ShowDialog();
                reload();
            }
        }

        private void Crear_Click(object sender, EventArgs e)
        {
            Modelo_crear_editar crear = new Modelo_crear_editar();
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
                    var target = db.Model_car.FirstOrDefault(x => x.Model_id == id);

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
    }
}

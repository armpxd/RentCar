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
    public partial class Empleado_main : Form
    {
        public Empleado_main()
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
                var empleado = db.Employee.Select(
                  x => new
                  {
                      Id = x.Employee_id,
                      Nombre = x.Name,
                      Cedula = x.Identification_card,
                      Horas_trabajadas = x.working_hours,
                      Comision = x.Comission_percentaje,
                      Fecha_Admision = x.date_admission,
                      Estado = x.State ? "Activo": "Desactivado"
                  }).ToList();

                dataGridView1.DataSource = empleado;
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
                Empleado_crear_editar editar = new Empleado_crear_editar(id);
                editar.ShowDialog();
                reload();
            }
        }

        private void Crear_Click(object sender, EventArgs e)
        {
            Empleado_crear_editar crear = new Empleado_crear_editar();

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
                    var target = db.Employee.FirstOrDefault(x => x.Employee_id == id);

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

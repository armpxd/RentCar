using Proyecto_Propietaria.Model;
using Proyecto_Propietaria.Utilitys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Propietaria.Report
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
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
        private void button1_Click(object sender, EventArgs e)
        {
            using (RentCarEntities db = new RentCarEntities())
            {
                var data = db.Rent_Devolution.Where(x => x.date_rent >= dateTimePicker1.Value && x.date_rent <= dateTimePicker2.Value).Select(
                    x => new
                    {
                        Id = x.Rent_id,
                        Empleado = x.Employee.Name,
                        Vehiculo = x.Car.Description,
                        Cliente = x.Client.Name,
                        Fecha_renta = x.date_rent,
                        Fecha_devolucion = x.date_devolution,
                        Costo_diario = x.Cost,
                        Dias = x.days,
                    }).ToList();

                dataGridView1.DataSource = data;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int? id = GetId();

            DialogResult dialogResult = MessageBox.Show("Desea generar el reporte individual?", "Confirmar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                using (RentCarEntities db = new RentCarEntities())
                {
                    var target = db.Rent_Devolution.FirstOrDefault(x => x.Rent_id == id);
                    Utility.ReportIndividual(target);
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Desea generar el reporte en el rango de fecha ?", "Confirmar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                using (RentCarEntities db = new RentCarEntities())
                {
                    var data = db.Rent_Devolution.Where(x => x.date_rent >= dateTimePicker1.Value && x.date_rent <= dateTimePicker2.Value).ToList();
                    Utility.ReportGrupal(data);
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                this.Close();
            }
        }
    }
}

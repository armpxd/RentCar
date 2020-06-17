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

namespace Proyecto_Propietaria.Renta
{
    public partial class Inspeccionar : Form
    {
        public Inspeccionar()
        {
            InitializeComponent();
        }
        private int? id;
        int? employee;
        public Inspeccionar( int? id = null, int? employe = null)
        {
            InitializeComponent();
            this.id = id;
            this.employee = employe;
            using (RentCarEntities db = new RentCarEntities())
            {
                comboCliente.DataSource = db.Client.Select(x => x.Name).ToList();
            }

        }

        private void numericPerDay_ValueChanged_1(object sender, EventArgs e)
        {
            numericResult.Value = numericDayRent.Value * numericPerDay.Value;
        }

        private void numericDayRent_ValueChanged_1(object sender, EventArgs e)
        {
            numericResult.Value = numericDayRent.Value * numericPerDay.Value;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Esta seguro de confirmar la renta?", "Confirmar renta", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                using (RentCarEntities db = new RentCarEntities())
                {
                    Rent_Devolution renta = new Rent_Devolution();
                    Inspection inspection = new Inspection();
                    var carro = db.Car.FirstOrDefault(x => x.Car_id == id);
                    
                    inspection.state_rubber1 = checkg1.Checked ? true : false;
                    inspection.state_rubber2 = checkg2.Checked ? true : false;
                    inspection.state_rubber3 = checkg3.Checked ? true : false;
                    inspection.state_rubber4 = checkg4.Checked ? true : false;
                    inspection.replacement_rubber = checkgr.Checked ? true : false;
                    inspection.is_dent = checkralladura.Checked ? true : false;
                    inspection.is_gat = checkGato.Checked ? true : false;
                    inspection.is_broken_glass = checkVidrios.Checked ? true : false;
                    inspection.comment = textBoxComentario.Text;
                    inspection.Car_id = carro.Car_id;
                    inspection.Fuel_level = comboCombustible.Text;
                    inspection.Employee_id = (int)employee;
                    inspection.Client_id = db.Client.FirstOrDefault(x=>x.Name == comboCliente.Text).Client_id;

                    db.Inspection.Add(inspection);
                    db.SaveChanges();

                    var last_inspection = db.Inspection.OrderByDescending(x => x.Inspection_id).First();
                    renta.date_rent = dateTimePicker1.Value;
                    renta.Cost = (int)numericPerDay.Value;
                    renta.days = (int)numericDayRent.Value;
                    renta.Employee_id = (int)employee;
                    renta.Car_id = carro.Car_id;
                    renta.Client_id = db.Client.FirstOrDefault(x => x.Name == comboCliente.Text).Client_id;
                    renta.inspection = last_inspection.Inspection_id;
                    renta.State = true;
                    db.Rent_Devolution.Add(renta);
                    carro.State = false;
                    db.SaveChanges();

                    MessageBox.Show("Renta realizada!");
                    this.Close();

                }
            }
            else if (dialogResult == DialogResult.No)
            {
                this.Close();
            }
        }
    }
}

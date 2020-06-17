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
    public partial class Devolucion : Form
    {
        public Devolucion()
        {
            InitializeComponent();
        }
        private int? id;
        int? employee;
        public Devolucion( int? id = null, int? employe = null)
        {
            InitializeComponent();
            this.id = id;
            this.employee = employe;
            using (RentCarEntities db = new RentCarEntities())
            {
                var renta = db.Rent_Devolution.FirstOrDefault(x => x.Rent_id == id);
                var inspection = db.Inspection.FirstOrDefault(x => x.Inspection_id == renta.inspection);

                checkg1.Checked = inspection.state_rubber1 ? checkg1.Checked = true : checkg1.Checked = false;
                checkg2.Checked = inspection.state_rubber2 ? checkg2.Checked = true : checkg2.Checked = false;
                checkg3.Checked = inspection.state_rubber3 ? checkg3.Checked = true : checkg3.Checked = false;
                checkg4.Checked = inspection.state_rubber4 ? checkg4.Checked = true : checkg4.Checked = false;
                checkgr.Checked = inspection.replacement_rubber ? checkgr.Checked = true : checkgr.Checked = false;
                checkralladura.Checked = inspection.is_dent ? checkralladura.Checked = true : checkralladura.Checked = false;
                checkGato.Checked = inspection.is_gat ? checkGato.Checked = true : checkGato.Checked = false;
                checkVidrios.Checked = inspection.is_broken_glass ? checkVidrios.Checked = true : checkVidrios.Checked = false;
                comboCombustible.Text = inspection.Fuel_level;
                textBoxComentario.Text = inspection.comment;
                dateTimePicker1.Value = renta.date_rent;
                numericPerDay.Value = renta.Cost;
                numericDayRent.Value = renta.days;
                numericResult.Value = renta.Cost * renta.days;
                comboCliente.Text = renta.Client.Name;
            }

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Esta seguro de confirmar la renta?", "Confirmar renta", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                using (RentCarEntities db = new RentCarEntities())
                {
                    var renta = db.Rent_Devolution.FirstOrDefault(x => x.Rent_id == id);

                    renta.date_devolution = dateTimePicker2.Value;
                    renta.Comment_devolution = textdevolucion.Text;
                    renta.State = false;
                    renta.Car.State = true;
                    db.SaveChanges();
                    MessageBox.Show("Devolucion realizada!");
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

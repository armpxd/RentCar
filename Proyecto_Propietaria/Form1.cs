using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Propietaria.Login;
namespace Proyecto_Propietaria
{
    public partial class Form1 : Form
    {
        int employee;
        public Form1()
        {

            InitializeComponent();
        }
        
        public Form1( int employee)
        {
            UserLogin login = new UserLogin();
            login.Close();
            this.employee = employee;
            InitializeComponent();
        }

        private void modeloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modelo_main modelo = new Modelo_main();
            modelo.ShowDialog();
        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Brand_main brand = new Brand_main();
            brand.ShowDialog();
        }

        private void combustibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            combustible_main combustible = new combustible_main();
            combustible.ShowDialog();
        }

        private void tipoDeVehiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tipo_vehiculo_main tipo_vehiculo = new Tipo_vehiculo_main();
            tipo_vehiculo.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cliente_main cliente = new Cliente_main();
            cliente.ShowDialog();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Empleado_main empleado = new Empleado_main();
            empleado.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void vehiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vehiculo_main vehiculo = new Vehiculo_main();
            vehiculo.ShowDialog();
        }

        private void rentarVehiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Renta_main renta = new Renta_main(employee);
            renta.ShowDialog();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuario_main usuario = new Usuario_main();
            usuario.ShowDialog();
        }

        private void devolucionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Devolucion_main devolucion = new Devolucion_main();
            devolucion.Show();
        }
    }
}

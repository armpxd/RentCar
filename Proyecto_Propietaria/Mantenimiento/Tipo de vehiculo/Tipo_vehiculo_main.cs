﻿using System;
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
    public partial class Tipo_vehiculo_main : Form
    {
        public Tipo_vehiculo_main()
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
                var carro = db.Type_car.Select(
                  x => new
                  {
                      Id = x.Type_car_id,
                      Descripcion = x.Description,
                      Estado = x.State ? "Activo": "Desactivado"
                  }).ToList();

                dataGridView1.DataSource = carro;
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
                Tipo_vehiculo_crear_editar editar = new Tipo_vehiculo_crear_editar(id);
                editar.ShowDialog();
                reload();
            }
        }

        private void Crear_Click(object sender, EventArgs e)
        {
            Tipo_vehiculo_crear_editar crear = new Tipo_vehiculo_crear_editar();

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
                    var target = db.Type_car.FirstOrDefault(x => x.Type_car_id == id);

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
                var carro = db.Type_car.Where(x => x.Description.Contains(textBox1.Text)).Select(
                  x => new
                  {
                      Id = x.Type_car_id,
                      Descripcion = x.Description,
                      Estado = x.State ? "Activo" : "Desactivado"
                  }).ToList();

                dataGridView1.DataSource = carro;
            }
        }
    }
}

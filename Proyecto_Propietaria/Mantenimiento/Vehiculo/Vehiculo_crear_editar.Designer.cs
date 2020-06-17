namespace Proyecto_Propietaria.Mantenimiento.Marca
{
    partial class Vehiculo_crear_editar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.combovehiculo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxChasis = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPlaca = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboMarca = new System.Windows.Forms.ComboBox();
            this.Galon = new System.Windows.Forms.Label();
            this.comboFuel = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(141, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vehiculo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descripcion";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(195, 311);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(18, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(195, 85);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(273, 22);
            this.textBoxDescription.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Estado";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(96, 350);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 35);
            this.button1.TabIndex = 5;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(245, 350);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 35);
            this.button2.TabIndex = 6;
            this.button2.Text = "Cerrar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // combovehiculo
            // 
            this.combovehiculo.Cursor = System.Windows.Forms.Cursors.No;
            this.combovehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combovehiculo.FormattingEnabled = true;
            this.combovehiculo.Location = new System.Drawing.Point(195, 197);
            this.combovehiculo.Name = "combovehiculo";
            this.combovehiculo.Size = new System.Drawing.Size(273, 24);
            this.combovehiculo.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tipo de Vehiculo";
            // 
            // textBoxChasis
            // 
            this.textBoxChasis.Location = new System.Drawing.Point(195, 126);
            this.textBoxChasis.Name = "textBoxChasis";
            this.textBoxChasis.Size = new System.Drawing.Size(273, 22);
            this.textBoxChasis.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(63, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Chasis";
            // 
            // textBoxPlaca
            // 
            this.textBoxPlaca.Location = new System.Drawing.Point(195, 161);
            this.textBoxPlaca.Name = "textBoxPlaca";
            this.textBoxPlaca.Size = new System.Drawing.Size(273, 22);
            this.textBoxPlaca.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Placa";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(67, 239);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Marca";
            // 
            // comboMarca
            // 
            this.comboMarca.Cursor = System.Windows.Forms.Cursors.No;
            this.comboMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMarca.FormattingEnabled = true;
            this.comboMarca.Location = new System.Drawing.Point(195, 239);
            this.comboMarca.Name = "comboMarca";
            this.comboMarca.Size = new System.Drawing.Size(273, 24);
            this.comboMarca.TabIndex = 13;
            // 
            // Galon
            // 
            this.Galon.AutoSize = true;
            this.Galon.Location = new System.Drawing.Point(63, 278);
            this.Galon.Name = "Galon";
            this.Galon.Size = new System.Drawing.Size(57, 17);
            this.Galon.TabIndex = 16;
            this.Galon.Text = "Tanque";
            // 
            // comboFuel
            // 
            this.comboFuel.Cursor = System.Windows.Forms.Cursors.No;
            this.comboFuel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFuel.FormattingEnabled = true;
            this.comboFuel.Location = new System.Drawing.Point(195, 275);
            this.comboFuel.Name = "comboFuel";
            this.comboFuel.Size = new System.Drawing.Size(273, 24);
            this.comboFuel.TabIndex = 15;
            // 
            // Vehiculo_crear_editar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 406);
            this.Controls.Add(this.Galon);
            this.Controls.Add(this.comboFuel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboMarca);
            this.Controls.Add(this.textBoxPlaca);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxChasis);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.combovehiculo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Vehiculo_crear_editar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Modelo_crear_editar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox combovehiculo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxChasis;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPlaca;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboMarca;
        private System.Windows.Forms.Label Galon;
        private System.Windows.Forms.ComboBox comboFuel;
    }
}
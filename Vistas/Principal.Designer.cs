namespace MNayaReservaHotel.Vistas
{
    partial class Principal
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelBienvenida = new System.Windows.Forms.Label();
            this.btnVerEmpleado = new System.Windows.Forms.Button();
            this.btnVerSalon = new System.Windows.Forms.Button();
            this.btnVerHabitacion = new System.Windows.Forms.Button();
            this.btnEmpleado = new System.Windows.Forms.Button();
            this.btnReservaSalon = new System.Windows.Forms.Button();
            this.btnReservaHabitacion = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.labelBienvenida);
            this.panel1.Controls.Add(this.btnVerEmpleado);
            this.panel1.Controls.Add(this.btnVerSalon);
            this.panel1.Controls.Add(this.btnVerHabitacion);
            this.panel1.Controls.Add(this.btnEmpleado);
            this.panel1.Controls.Add(this.btnReservaSalon);
            this.panel1.Controls.Add(this.btnReservaHabitacion);
            this.panel1.Location = new System.Drawing.Point(0, 46);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 303);
            this.panel1.TabIndex = 0;
            // 
            // labelBienvenida
            // 
            this.labelBienvenida.AutoSize = true;
            this.labelBienvenida.ForeColor = System.Drawing.Color.White;
            this.labelBienvenida.Location = new System.Drawing.Point(81, 34);
            this.labelBienvenida.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBienvenida.Name = "labelBienvenida";
            this.labelBienvenida.Size = new System.Drawing.Size(0, 16);
            this.labelBienvenida.TabIndex = 6;
            // 
            // btnVerEmpleado
            // 
            this.btnVerEmpleado.BackColor = System.Drawing.Color.IndianRed;
            this.btnVerEmpleado.ForeColor = System.Drawing.Color.White;
            this.btnVerEmpleado.Location = new System.Drawing.Point(799, 188);
            this.btnVerEmpleado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnVerEmpleado.Name = "btnVerEmpleado";
            this.btnVerEmpleado.Size = new System.Drawing.Size(301, 90);
            this.btnVerEmpleado.TabIndex = 5;
            this.btnVerEmpleado.Text = "Listado de empleados";
            this.btnVerEmpleado.UseVisualStyleBackColor = false;
            this.btnVerEmpleado.Click += new System.EventHandler(this.btnVerEmpleado_Click);
            // 
            // btnVerSalon
            // 
            this.btnVerSalon.BackColor = System.Drawing.Color.IndianRed;
            this.btnVerSalon.ForeColor = System.Drawing.Color.White;
            this.btnVerSalon.Location = new System.Drawing.Point(433, 188);
            this.btnVerSalon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnVerSalon.Name = "btnVerSalon";
            this.btnVerSalon.Size = new System.Drawing.Size(301, 90);
            this.btnVerSalon.TabIndex = 4;
            this.btnVerSalon.Text = "Ver reservas de salones";
            this.btnVerSalon.UseVisualStyleBackColor = false;
            this.btnVerSalon.Click += new System.EventHandler(this.btnVerSalon_Click);
            // 
            // btnVerHabitacion
            // 
            this.btnVerHabitacion.BackColor = System.Drawing.Color.IndianRed;
            this.btnVerHabitacion.ForeColor = System.Drawing.Color.White;
            this.btnVerHabitacion.Location = new System.Drawing.Point(73, 188);
            this.btnVerHabitacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnVerHabitacion.Name = "btnVerHabitacion";
            this.btnVerHabitacion.Size = new System.Drawing.Size(301, 90);
            this.btnVerHabitacion.TabIndex = 3;
            this.btnVerHabitacion.Text = "Ver reservas de habitaciones";
            this.btnVerHabitacion.UseVisualStyleBackColor = false;
            this.btnVerHabitacion.Click += new System.EventHandler(this.btnVerHabitacion_Click);
            // 
            // btnEmpleado
            // 
            this.btnEmpleado.BackColor = System.Drawing.Color.IndianRed;
            this.btnEmpleado.ForeColor = System.Drawing.Color.White;
            this.btnEmpleado.Location = new System.Drawing.Point(799, 78);
            this.btnEmpleado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEmpleado.Name = "btnEmpleado";
            this.btnEmpleado.Size = new System.Drawing.Size(301, 90);
            this.btnEmpleado.TabIndex = 2;
            this.btnEmpleado.Text = "Alta de empleados";
            this.btnEmpleado.UseVisualStyleBackColor = false;
            this.btnEmpleado.Click += new System.EventHandler(this.btnEmpleado_Click);
            // 
            // btnReservaSalon
            // 
            this.btnReservaSalon.BackColor = System.Drawing.Color.IndianRed;
            this.btnReservaSalon.ForeColor = System.Drawing.Color.White;
            this.btnReservaSalon.Location = new System.Drawing.Point(433, 78);
            this.btnReservaSalon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReservaSalon.Name = "btnReservaSalon";
            this.btnReservaSalon.Size = new System.Drawing.Size(301, 90);
            this.btnReservaSalon.TabIndex = 1;
            this.btnReservaSalon.Text = "Reserva de salones";
            this.btnReservaSalon.UseVisualStyleBackColor = false;
            this.btnReservaSalon.Click += new System.EventHandler(this.btnReservaSalon_Click);
            // 
            // btnReservaHabitacion
            // 
            this.btnReservaHabitacion.BackColor = System.Drawing.Color.IndianRed;
            this.btnReservaHabitacion.ForeColor = System.Drawing.Color.White;
            this.btnReservaHabitacion.Location = new System.Drawing.Point(73, 78);
            this.btnReservaHabitacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReservaHabitacion.Name = "btnReservaHabitacion";
            this.btnReservaHabitacion.Size = new System.Drawing.Size(301, 90);
            this.btnReservaHabitacion.TabIndex = 0;
            this.btnReservaHabitacion.Text = "Reserva de habitaciones";
            this.btnReservaHabitacion.UseVisualStyleBackColor = false;
            this.btnReservaHabitacion.Click += new System.EventHandler(this.btnReservaHabitacion_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MNayaReservaHotel.Properties.Resources.hotel1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1182, 718);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1200, 765);
            this.MinimumSize = new System.Drawing.Size(1200, 765);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Principal_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnVerEmpleado;
        private System.Windows.Forms.Button btnVerSalon;
        private System.Windows.Forms.Button btnVerHabitacion;
        private System.Windows.Forms.Button btnEmpleado;
        private System.Windows.Forms.Button btnReservaSalon;
        private System.Windows.Forms.Button btnReservaHabitacion;
        private System.Windows.Forms.Label labelBienvenida;
    }
}
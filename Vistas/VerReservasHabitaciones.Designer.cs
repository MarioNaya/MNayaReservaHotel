namespace MNayaReservaHotel.Vistas
{
    partial class VerReservasHabitaciones
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.campoFecha = new System.Windows.Forms.DateTimePicker();
            this.btnActuales = new System.Windows.Forms.Button();
            this.btnHistorico = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tabla = new System.Windows.Forms.DataGridView();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1316, 94);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(64, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(381, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Reservas de habitaciones";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MNayaReservaHotel.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(821, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 146);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Filtrar por fecha";
            // 
            // campoFecha
            // 
            this.campoFecha.Location = new System.Drawing.Point(207, 141);
            this.campoFecha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.campoFecha.Name = "campoFecha";
            this.campoFecha.Size = new System.Drawing.Size(172, 22);
            this.campoFecha.TabIndex = 2;
            this.campoFecha.ValueChanged += new System.EventHandler(this.campoFecha_ValueChanged);
            // 
            // btnActuales
            // 
            this.btnActuales.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnActuales.Location = new System.Drawing.Point(613, 140);
            this.btnActuales.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnActuales.Name = "btnActuales";
            this.btnActuales.Size = new System.Drawing.Size(142, 28);
            this.btnActuales.TabIndex = 3;
            this.btnActuales.Text = "Reservas actuales";
            this.btnActuales.UseVisualStyleBackColor = true;
            this.btnActuales.Click += new System.EventHandler(this.btnActuales_Click);
            // 
            // btnHistorico
            // 
            this.btnHistorico.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnHistorico.Location = new System.Drawing.Point(773, 140);
            this.btnHistorico.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHistorico.Name = "btnHistorico";
            this.btnHistorico.Size = new System.Drawing.Size(137, 28);
            this.btnHistorico.TabIndex = 4;
            this.btnHistorico.Text = "Histórico reservas";
            this.btnHistorico.UseVisualStyleBackColor = true;
            this.btnHistorico.Click += new System.EventHandler(this.btnHistorico_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DarkOrange;
            this.label3.Location = new System.Drawing.Point(63, 204);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Reservas actuales";
            // 
            // tabla
            // 
            this.tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla.Location = new System.Drawing.Point(70, 248);
            this.tabla.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabla.Name = "tabla";
            this.tabla.RowHeadersWidth = 51;
            this.tabla.Size = new System.Drawing.Size(840, 238);
            this.tabla.TabIndex = 6;
            // 
            // btnMostrar
            // 
            this.btnMostrar.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnMostrar.Location = new System.Drawing.Point(411, 143);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(75, 23);
            this.btnMostrar.TabIndex = 7;
            this.btnMostrar.Text = "Mostrar";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // VerReservasHabitaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(982, 603);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.tabla);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnHistorico);
            this.Controls.Add(this.btnActuales);
            this.Controls.Add(this.campoFecha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 650);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "VerReservasHabitaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Listado de reservas de habitaciones";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker campoFecha;
        private System.Windows.Forms.Button btnActuales;
        private System.Windows.Forms.Button btnHistorico;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView tabla;
        private System.Windows.Forms.Button btnMostrar;
    }
}
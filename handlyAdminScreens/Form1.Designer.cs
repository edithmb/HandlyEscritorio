namespace handlyAdminScreens
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelDenuncias = new System.Windows.Forms.Panel();
            this.btnDenunciasResueltas = new System.Windows.Forms.Button();
            this.btnDenunciasPorRevisar = new System.Windows.Forms.Button();
            this.panelIdentidad = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.btnCuentasInactivas = new System.Windows.Forms.Button();
            this.btnCuentasPorRevisar = new System.Windows.Forms.Button();
            this.btnCuentasActivas = new System.Windows.Forms.Button();
            this.panelCuentas = new System.Windows.Forms.Panel();
            this.btnIdentidad = new System.Windows.Forms.Button();
            this.btnDenuncias = new System.Windows.Forms.Button();
            this.btnCuentas = new System.Windows.Forms.Button();
            this.panelDenuncias.SuspendLayout();
            this.panelIdentidad.SuspendLayout();
            this.panelCuentas.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDenuncias
            // 
            this.panelDenuncias.Controls.Add(this.btnDenunciasResueltas);
            this.panelDenuncias.Controls.Add(this.btnDenunciasPorRevisar);
            this.panelDenuncias.Location = new System.Drawing.Point(0, 23);
            this.panelDenuncias.Name = "panelDenuncias";
            this.panelDenuncias.Size = new System.Drawing.Size(77, 100);
            this.panelDenuncias.TabIndex = 0;
            this.panelDenuncias.Visible = false;
            this.panelDenuncias.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDenuncias_Paint);
            // 
            // btnDenunciasResueltas
            // 
            this.btnDenunciasResueltas.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDenunciasResueltas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDenunciasResueltas.Location = new System.Drawing.Point(0, 23);
            this.btnDenunciasResueltas.Name = "btnDenunciasResueltas";
            this.btnDenunciasResueltas.Size = new System.Drawing.Size(75, 23);
            this.btnDenunciasResueltas.TabIndex = 1;
            this.btnDenunciasResueltas.Text = "Resueltas";
            this.btnDenunciasResueltas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDenunciasResueltas.UseVisualStyleBackColor = false;
            this.btnDenunciasResueltas.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnDenunciasPorRevisar
            // 
            this.btnDenunciasPorRevisar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDenunciasPorRevisar.CausesValidation = false;
            this.btnDenunciasPorRevisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDenunciasPorRevisar.Location = new System.Drawing.Point(0, 0);
            this.btnDenunciasPorRevisar.Name = "btnDenunciasPorRevisar";
            this.btnDenunciasPorRevisar.Size = new System.Drawing.Size(75, 23);
            this.btnDenunciasPorRevisar.TabIndex = 0;
            this.btnDenunciasPorRevisar.Text = "Por revisar";
            this.btnDenunciasPorRevisar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDenunciasPorRevisar.UseVisualStyleBackColor = false;
            this.btnDenunciasPorRevisar.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelIdentidad
            // 
            this.panelIdentidad.Controls.Add(this.button5);
            this.panelIdentidad.Controls.Add(this.button6);
            this.panelIdentidad.Location = new System.Drawing.Point(100, 23);
            this.panelIdentidad.Name = "panelIdentidad";
            this.panelIdentidad.Size = new System.Drawing.Size(77, 100);
            this.panelIdentidad.TabIndex = 2;
            this.panelIdentidad.Visible = false;
            this.panelIdentidad.Paint += new System.Windows.Forms.PaintEventHandler(this.panelIdentidad_Paint);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(0, 23);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 1;
            this.button5.Text = "Resueltas";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button6.CausesValidation = false;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(0, 0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 0;
            this.button6.Text = "Por revisar";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // btnCuentasInactivas
            // 
            this.btnCuentasInactivas.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCuentasInactivas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCuentasInactivas.Location = new System.Drawing.Point(0, 23);
            this.btnCuentasInactivas.Name = "btnCuentasInactivas";
            this.btnCuentasInactivas.Size = new System.Drawing.Size(75, 23);
            this.btnCuentasInactivas.TabIndex = 1;
            this.btnCuentasInactivas.Text = "Inactivas";
            this.btnCuentasInactivas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCuentasInactivas.UseVisualStyleBackColor = false;
            this.btnCuentasInactivas.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnCuentasPorRevisar
            // 
            this.btnCuentasPorRevisar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCuentasPorRevisar.CausesValidation = false;
            this.btnCuentasPorRevisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCuentasPorRevisar.Location = new System.Drawing.Point(0, 0);
            this.btnCuentasPorRevisar.Name = "btnCuentasPorRevisar";
            this.btnCuentasPorRevisar.Size = new System.Drawing.Size(75, 23);
            this.btnCuentasPorRevisar.TabIndex = 0;
            this.btnCuentasPorRevisar.Text = "Por revisar";
            this.btnCuentasPorRevisar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCuentasPorRevisar.UseVisualStyleBackColor = false;
            // 
            // btnCuentasActivas
            // 
            this.btnCuentasActivas.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCuentasActivas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCuentasActivas.Location = new System.Drawing.Point(0, 46);
            this.btnCuentasActivas.Name = "btnCuentasActivas";
            this.btnCuentasActivas.Size = new System.Drawing.Size(75, 23);
            this.btnCuentasActivas.TabIndex = 2;
            this.btnCuentasActivas.Text = "Activas";
            this.btnCuentasActivas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCuentasActivas.UseVisualStyleBackColor = false;
            this.btnCuentasActivas.Click += new System.EventHandler(this.btnCuentasActivas_Click);
            // 
            // panelCuentas
            // 
            this.panelCuentas.Controls.Add(this.btnCuentasPorRevisar);
            this.panelCuentas.Controls.Add(this.btnCuentasActivas);
            this.panelCuentas.Controls.Add(this.btnCuentasInactivas);
            this.panelCuentas.Location = new System.Drawing.Point(200, 23);
            this.panelCuentas.Name = "panelCuentas";
            this.panelCuentas.Size = new System.Drawing.Size(80, 100);
            this.panelCuentas.TabIndex = 4;
            this.panelCuentas.Visible = false;
            this.panelCuentas.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCuentas_Paint_1);
            // 
            // btnIdentidad
            // 
            this.btnIdentidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIdentidad.Location = new System.Drawing.Point(100, 1);
            this.btnIdentidad.Name = "btnIdentidad";
            this.btnIdentidad.Size = new System.Drawing.Size(100, 23);
            this.btnIdentidad.TabIndex = 5;
            this.btnIdentidad.Text = "IDENTIDADES";
            this.btnIdentidad.UseVisualStyleBackColor = true;
            this.btnIdentidad.Click += new System.EventHandler(this.btnIdentidad_Click_1);
            // 
            // btnDenuncias
            // 
            this.btnDenuncias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDenuncias.Location = new System.Drawing.Point(1, 1);
            this.btnDenuncias.Name = "btnDenuncias";
            this.btnDenuncias.Size = new System.Drawing.Size(100, 23);
            this.btnDenuncias.TabIndex = 6;
            this.btnDenuncias.Text = "DENUNCIAS";
            this.btnDenuncias.UseVisualStyleBackColor = true;
            this.btnDenuncias.Click += new System.EventHandler(this.btnDenuncias_Click);
            // 
            // btnCuentas
            // 
            this.btnCuentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCuentas.Location = new System.Drawing.Point(200, 1);
            this.btnCuentas.Name = "btnCuentas";
            this.btnCuentas.Size = new System.Drawing.Size(100, 23);
            this.btnCuentas.TabIndex = 7;
            this.btnCuentas.Text = "CUENTAS";
            this.btnCuentas.UseVisualStyleBackColor = true;
            this.btnCuentas.Click += new System.EventHandler(this.btnCuentas_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCuentas);
            this.Controls.Add(this.btnDenuncias);
            this.Controls.Add(this.btnIdentidad);
            this.Controls.Add(this.panelCuentas);
            this.Controls.Add(this.panelIdentidad);
            this.Controls.Add(this.panelDenuncias);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelDenuncias.ResumeLayout(false);
            this.panelIdentidad.ResumeLayout(false);
            this.panelCuentas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDenuncias;
        private System.Windows.Forms.Button btnDenunciasPorRevisar;
        private System.Windows.Forms.Button btnDenunciasResueltas;
        private System.Windows.Forms.Panel panelIdentidad;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnCuentasInactivas;
        private System.Windows.Forms.Button btnCuentasPorRevisar;
        public System.Windows.Forms.Button btnCuentasActivas;
        private System.Windows.Forms.Panel panelCuentas;
        private System.Windows.Forms.Button btnIdentidad;
        private System.Windows.Forms.Button btnDenuncias;
        private System.Windows.Forms.Button btnCuentas;
    }
}


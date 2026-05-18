namespace handlyAdminScreens
{
    partial class NavigationButtons
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavigationButtons));
            this.btnDenunciasResueltas = new System.Windows.Forms.Button();
            this.btnIdentidad = new System.Windows.Forms.Button();
            this.btnDenuncias = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnInicio = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnTransacciones = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDenunciasResueltas
            // 
            this.btnDenunciasResueltas.Location = new System.Drawing.Point(0, 0);
            this.btnDenunciasResueltas.Name = "btnDenunciasResueltas";
            this.btnDenunciasResueltas.Size = new System.Drawing.Size(75, 23);
            this.btnDenunciasResueltas.TabIndex = 0;
            // 
            // btnIdentidad
            // 
            this.btnIdentidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIdentidad.Location = new System.Drawing.Point(572, 0);
            this.btnIdentidad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnIdentidad.Name = "btnIdentidad";
            this.btnIdentidad.Size = new System.Drawing.Size(300, 35);
            this.btnIdentidad.TabIndex = 5;
            this.btnIdentidad.Text = "VERIFICACIÓN DE IDENTIDADES";
            this.btnIdentidad.UseVisualStyleBackColor = true;
            this.btnIdentidad.Click += new System.EventHandler(this.btnIdentidad_Click_1);
            // 
            // btnDenuncias
            // 
            this.btnDenuncias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDenuncias.Location = new System.Drawing.Point(99, 0);
            this.btnDenuncias.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDenuncias.Name = "btnDenuncias";
            this.btnDenuncias.Size = new System.Drawing.Size(150, 35);
            this.btnDenuncias.TabIndex = 6;
            this.btnDenuncias.Text = "DENUNCIAS";
            this.btnDenuncias.UseVisualStyleBackColor = true;
            this.btnDenuncias.Click += new System.EventHandler(this.btnDenuncias_Click);
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.Location = new System.Drawing.Point(0, 35);
            this.panelMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1200, 661);
            this.panelMain.TabIndex = 8;
            this.panelMain.Visible = false;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // btnInicio
            // 
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Location = new System.Drawing.Point(0, 0);
            this.btnInicio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(100, 35);
            this.btnInicio.TabIndex = 9;
            this.btnInicio.Text = "INICIO";
            this.btnInicio.UseVisualStyleBackColor = true;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Location = new System.Drawing.Point(247, 0);
            this.btnUsuarios.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(150, 35);
            this.btnUsuarios.TabIndex = 10;
            this.btnUsuarios.Text = "USUARIOS";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnTransacciones
            // 
            this.btnTransacciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransacciones.Location = new System.Drawing.Point(395, 0);
            this.btnTransacciones.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTransacciones.Name = "btnTransacciones";
            this.btnTransacciones.Size = new System.Drawing.Size(180, 35);
            this.btnTransacciones.TabIndex = 11;
            this.btnTransacciones.Text = "TRANSACCIONES";
            this.btnTransacciones.UseVisualStyleBackColor = true;
            this.btnTransacciones.Click += new System.EventHandler(this.btnTransacciones_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Location = new System.Drawing.Point(1042, 0);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(158, 35);
            this.btnLogout.TabIndex = 12;
            this.btnLogout.Text = "CERRAR SESIÓN";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // NavigationButtons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnTransacciones);
            this.Controls.Add(this.btnUsuarios);
            this.Controls.Add(this.btnInicio);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.btnDenuncias);
            this.Controls.Add(this.btnIdentidad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "NavigationButtons";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnDenunciasResueltas;
        private System.Windows.Forms.Button btnIdentidad;
        private System.Windows.Forms.Button btnDenuncias;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnTransacciones;
        private System.Windows.Forms.Button btnLogout;
    }
}


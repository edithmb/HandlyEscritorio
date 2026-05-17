namespace handlyAdminScreens.Views
{
    partial class VerificacionIdentidades
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.gridVerify = new System.Windows.Forms.DataGridView();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnViewImages = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridVerify)).BeginInit();
            this.SuspendLayout();
            // 
            // gridVerify
            // 
            this.gridVerify.AllowUserToAddRows = false;
            this.gridVerify.AllowUserToDeleteRows = false;
            this.gridVerify.AllowUserToOrderColumns = true;
            this.gridVerify.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridVerify.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridVerify.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridVerify.Location = new System.Drawing.Point(23, 71);
            this.gridVerify.Name = "gridVerify";
            this.gridVerify.ReadOnly = true;
            this.gridVerify.RowHeadersVisible = false;
            this.gridVerify.RowHeadersWidth = 62;
            this.gridVerify.RowTemplate.Height = 28;
            this.gridVerify.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridVerify.Size = new System.Drawing.Size(1090, 312);
            this.gridVerify.TabIndex = 0;
            this.gridVerify.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridVerify_CellDoubleClick);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(30, 27);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(63, 20);
            this.lblBuscar.TabIndex = 1;
            this.lblBuscar.Text = "Buscar:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(99, 24);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(229, 26);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(128)))), ((int)(((byte)(226)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(620, 20);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(150, 35);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Actualizar datos";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnViewImages
            // 
            this.btnViewImages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(224)))), ((int)(((byte)(232)))));
            this.btnViewImages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewImages.Location = new System.Drawing.Point(800, 20);
            this.btnViewImages.Name = "btnViewImages";
            this.btnViewImages.Size = new System.Drawing.Size(180, 35);
            this.btnViewImages.TabIndex = 4;
            this.btnViewImages.Text = "Ver imágenes";
            this.btnViewImages.UseVisualStyleBackColor = false;
            this.btnViewImages.Click += new System.EventHandler(this.btnViewImages_Click);
            // 
            // VerificacionIdentidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 450);
            this.Controls.Add(this.btnViewImages);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.gridVerify);
            this.Name = "VerificacionIdentidades";
            this.Text = "Verificación de identidades";
            this.Load += new System.EventHandler(this.VerificacionIdentidades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridVerify)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridVerify;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnViewImages;
    }
}

namespace handlyAdminScreens.Views
{
    partial class Transacciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Transacciones));
            this.gridTransactions = new System.Windows.Forms.DataGridView();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnDeleteFilter = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnViewImages = new System.Windows.Forms.Button();
            this.txtSearchTransaction = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // gridTransactions
            // 
            this.gridTransactions.AllowUserToAddRows = false;
            this.gridTransactions.AllowUserToDeleteRows = false;
            this.gridTransactions.AllowUserToOrderColumns = true;
            this.gridTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTransactions.Location = new System.Drawing.Point(23, 71);
            this.gridTransactions.Name = "gridTransactions";
            this.gridTransactions.ReadOnly = true;
            this.gridTransactions.RowHeadersVisible = false;
            this.gridTransactions.RowHeadersWidth = 62;
            this.gridTransactions.RowTemplate.Height = 28;
            this.gridTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTransactions.Size = new System.Drawing.Size(1090, 312);
            this.gridTransactions.TabIndex = 0;
            this.gridTransactions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTransactions_CellDoubleClick);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(30, 27);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(63, 20);
            this.lblBuscar.TabIndex = 3;
            this.lblBuscar.Text = "Buscar:";
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.Navy;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(368, 20);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 35);
            this.btnFilter.TabIndex = 5;
            this.btnFilter.Text = "Filtrar";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnDeleteFilter
            // 
            this.btnDeleteFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDeleteFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteFilter.ForeColor = System.Drawing.Color.White;
            this.btnDeleteFilter.Location = new System.Drawing.Point(476, 20);
            this.btnDeleteFilter.Name = "btnDeleteFilter";
            this.btnDeleteFilter.Size = new System.Drawing.Size(109, 35);
            this.btnDeleteFilter.TabIndex = 6;
            this.btnDeleteFilter.Text = "Borrar filtro";
            this.btnDeleteFilter.UseVisualStyleBackColor = false;
            this.btnDeleteFilter.Click += new System.EventHandler(this.btnDeleteFilter_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.Location = new System.Drawing.Point(963, 20);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(150, 35);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Actualizar datos";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnViewImages
            // 
            this.btnViewImages.BackColor = System.Drawing.Color.DarkGreen;
            this.btnViewImages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewImages.ForeColor = System.Drawing.Color.White;
            this.btnViewImages.Location = new System.Drawing.Point(774, 20);
            this.btnViewImages.Name = "btnViewImages";
            this.btnViewImages.Size = new System.Drawing.Size(170, 35);
            this.btnViewImages.TabIndex = 9;
            this.btnViewImages.Text = "Ver imágenes";
            this.btnViewImages.UseVisualStyleBackColor = false;
            this.btnViewImages.Click += new System.EventHandler(this.btnViewImages_Click);
            // 
            // txtSearchTransaction
            // 
            this.txtSearchTransaction.Location = new System.Drawing.Point(99, 24);
            this.txtSearchTransaction.Name = "txtSearchTransaction";
            this.txtSearchTransaction.Size = new System.Drawing.Size(229, 26);
            this.txtSearchTransaction.TabIndex = 7;
            this.txtSearchTransaction.TextChanged += new System.EventHandler(this.txtSearchTransaction_TextChanged);
            // 
            // Transacciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 450);
            this.Controls.Add(this.txtSearchTransaction);
            this.Controls.Add(this.btnViewImages);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDeleteFilter);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.gridTransactions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Transacciones";
            this.Text = "Transacciones";
            this.Load += new System.EventHandler(this.Transacciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridTransactions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridTransactions;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnDeleteFilter;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnViewImages;
        private System.Windows.Forms.TextBox txtSearchTransaction;
    }
}
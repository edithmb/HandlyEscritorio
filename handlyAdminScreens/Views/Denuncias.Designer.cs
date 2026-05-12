namespace handlyAdminScreens.Views
{
    partial class Denuncias
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
            this.gridReports = new System.Windows.Forms.DataGridView();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnDeleteFilter = new System.Windows.Forms.Button();
            this.txtSearchReport = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridReports)).BeginInit();
            this.SuspendLayout();
            //
            // gridReports
            //
            this.gridReports.AllowUserToAddRows = false;
            this.gridReports.AllowUserToDeleteRows = false;
            this.gridReports.AllowUserToOrderColumns = true;
            this.gridReports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridReports.Location = new System.Drawing.Point(23, 71);
            this.gridReports.Name = "gridReports";
            this.gridReports.ReadOnly = true;
            this.gridReports.RowHeadersVisible = false;
            this.gridReports.RowHeadersWidth = 62;
            this.gridReports.RowTemplate.Height = 28;
            this.gridReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridReports.Size = new System.Drawing.Size(1090, 312);
            this.gridReports.TabIndex = 0;
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
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(224)))), ((int)(((byte)(232)))));
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.btnDeleteFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDeleteFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteFilter.Location = new System.Drawing.Point(476, 20);
            this.btnDeleteFilter.Name = "btnDeleteFilter";
            this.btnDeleteFilter.Size = new System.Drawing.Size(109, 35);
            this.btnDeleteFilter.TabIndex = 6;
            this.btnDeleteFilter.Text = "Borrar filtro";
            this.btnDeleteFilter.UseVisualStyleBackColor = false;
            this.btnDeleteFilter.Click += new System.EventHandler(this.btnDeleteFilter_Click);
            //
            // txtSearchReport
            //
            this.txtSearchReport.Location = new System.Drawing.Point(99, 24);
            this.txtSearchReport.Name = "txtSearchReport";
            this.txtSearchReport.Size = new System.Drawing.Size(229, 26);
            this.txtSearchReport.TabIndex = 7;
            this.txtSearchReport.TextChanged += new System.EventHandler(this.txtSearchReport_TextChanged);
            //
            // Denuncias
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 450);
            this.Controls.Add(this.txtSearchReport);
            this.Controls.Add(this.btnDeleteFilter);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.gridReports);
            this.Name = "Denuncias";
            this.Text = "Denuncias";
            this.Load += new System.EventHandler(this.Denuncias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridReports)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridReports;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnDeleteFilter;
        private System.Windows.Forms.TextBox txtSearchReport;
    }
}

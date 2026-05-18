namespace handlyAdminScreens.Views
{
    partial class TransactionImages
    {
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionImages));
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.gbPhoto1 = new System.Windows.Forms.GroupBox();
            this.pbPhoto1 = new System.Windows.Forms.PictureBox();
            this.lblPhoto1Empty = new System.Windows.Forms.Label();
            this.gbPhoto2 = new System.Windows.Forms.GroupBox();
            this.pbPhoto2 = new System.Windows.Forms.PictureBox();
            this.lblPhoto2Empty = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.gbPhoto1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto1)).BeginInit();
            this.gbPhoto2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto2)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(20, 12, 20, 8);
            this.panelTop.Size = new System.Drawing.Size(900, 50);
            this.panelTop.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(860, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Imágenes de la tarea";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.gbPhoto1, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.gbPhoto2, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 50);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.Padding = new System.Windows.Forms.Padding(15, 5, 15, 5);
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(900, 440);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // gbPhoto1
            // 
            this.gbPhoto1.Controls.Add(this.pbPhoto1);
            this.gbPhoto1.Controls.Add(this.lblPhoto1Empty);
            this.gbPhoto1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPhoto1.Location = new System.Drawing.Point(18, 8);
            this.gbPhoto1.Name = "gbPhoto1";
            this.gbPhoto1.Padding = new System.Windows.Forms.Padding(10);
            this.gbPhoto1.Size = new System.Drawing.Size(429, 424);
            this.gbPhoto1.TabIndex = 0;
            this.gbPhoto1.TabStop = false;
            this.gbPhoto1.Text = "Foto 1";
            // 
            // pbPhoto1
            // 
            this.pbPhoto1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPhoto1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPhoto1.Location = new System.Drawing.Point(10, 29);
            this.pbPhoto1.Name = "pbPhoto1";
            this.pbPhoto1.Size = new System.Drawing.Size(409, 385);
            this.pbPhoto1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPhoto1.TabIndex = 0;
            this.pbPhoto1.TabStop = false;
            // 
            // lblPhoto1Empty
            // 
            this.lblPhoto1Empty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPhoto1Empty.ForeColor = System.Drawing.Color.Gray;
            this.lblPhoto1Empty.Location = new System.Drawing.Point(10, 29);
            this.lblPhoto1Empty.Name = "lblPhoto1Empty";
            this.lblPhoto1Empty.Size = new System.Drawing.Size(409, 385);
            this.lblPhoto1Empty.TabIndex = 1;
            this.lblPhoto1Empty.Text = "(no hay imagen)";
            this.lblPhoto1Empty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPhoto1Empty.Visible = false;
            // 
            // gbPhoto2
            // 
            this.gbPhoto2.Controls.Add(this.pbPhoto2);
            this.gbPhoto2.Controls.Add(this.lblPhoto2Empty);
            this.gbPhoto2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPhoto2.Location = new System.Drawing.Point(453, 8);
            this.gbPhoto2.Name = "gbPhoto2";
            this.gbPhoto2.Padding = new System.Windows.Forms.Padding(10);
            this.gbPhoto2.Size = new System.Drawing.Size(429, 424);
            this.gbPhoto2.TabIndex = 1;
            this.gbPhoto2.TabStop = false;
            this.gbPhoto2.Text = "Foto 2";
            // 
            // pbPhoto2
            // 
            this.pbPhoto2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPhoto2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPhoto2.Location = new System.Drawing.Point(10, 29);
            this.pbPhoto2.Name = "pbPhoto2";
            this.pbPhoto2.Size = new System.Drawing.Size(409, 385);
            this.pbPhoto2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPhoto2.TabIndex = 0;
            this.pbPhoto2.TabStop = false;
            // 
            // lblPhoto2Empty
            // 
            this.lblPhoto2Empty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPhoto2Empty.ForeColor = System.Drawing.Color.Gray;
            this.lblPhoto2Empty.Location = new System.Drawing.Point(10, 29);
            this.lblPhoto2Empty.Name = "lblPhoto2Empty";
            this.lblPhoto2Empty.Size = new System.Drawing.Size(409, 385);
            this.lblPhoto2Empty.TabIndex = 1;
            this.lblPhoto2Empty.Text = "(no hay imagen)";
            this.lblPhoto2Empty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPhoto2Empty.Visible = false;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnClose);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 490);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.panelBottom.Size = new System.Drawing.Size(900, 60);
            this.panelBottom.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(790, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 38);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // TransactionImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 450);
            this.Name = "TransactionImages";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Imágenes de la tarea";
            this.panelTop.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.gbPhoto1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto1)).EndInit();
            this.gbPhoto2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto2)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.GroupBox gbPhoto1;
        private System.Windows.Forms.PictureBox pbPhoto1;
        private System.Windows.Forms.Label lblPhoto1Empty;
        private System.Windows.Forms.GroupBox gbPhoto2;
        private System.Windows.Forms.PictureBox pbPhoto2;
        private System.Windows.Forms.Label lblPhoto2Empty;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnClose;
    }
}

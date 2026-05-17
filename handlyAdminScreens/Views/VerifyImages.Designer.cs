namespace handlyAdminScreens.Views
{
    partial class VerifyImages
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.gbSelfie = new System.Windows.Forms.GroupBox();
            this.pbSelfie = new System.Windows.Forms.PictureBox();
            this.lblSelfieEmpty = new System.Windows.Forms.Label();
            this.gbDocFront = new System.Windows.Forms.GroupBox();
            this.pbDocFront = new System.Windows.Forms.PictureBox();
            this.lblDocFrontEmpty = new System.Windows.Forms.Label();
            this.gbDocBack = new System.Windows.Forms.GroupBox();
            this.pbDocBack = new System.Windows.Forms.PictureBox();
            this.lblDocBackEmpty = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnDeny = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.gbSelfie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelfie)).BeginInit();
            this.gbDocFront.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDocFront)).BeginInit();
            this.gbDocBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDocBack)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel.Controls.Add(this.gbSelfie, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.gbDocFront, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.gbDocBack, 2, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.Padding = new System.Windows.Forms.Padding(15, 5, 15, 5);
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1050, 530);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // gbSelfie
            // 
            this.gbSelfie.Controls.Add(this.pbSelfie);
            this.gbSelfie.Controls.Add(this.lblSelfieEmpty);
            this.gbSelfie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSelfie.Location = new System.Drawing.Point(18, 8);
            this.gbSelfie.Name = "gbSelfie";
            this.gbSelfie.Padding = new System.Windows.Forms.Padding(10);
            this.gbSelfie.Size = new System.Drawing.Size(333, 514);
            this.gbSelfie.TabIndex = 0;
            this.gbSelfie.TabStop = false;
            this.gbSelfie.Text = "Selfie";
            // 
            // pbSelfie
            // 
            this.pbSelfie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSelfie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSelfie.Location = new System.Drawing.Point(10, 29);
            this.pbSelfie.Name = "pbSelfie";
            this.pbSelfie.Size = new System.Drawing.Size(313, 475);
            this.pbSelfie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSelfie.TabIndex = 0;
            this.pbSelfie.TabStop = false;
            // 
            // lblSelfieEmpty
            // 
            this.lblSelfieEmpty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSelfieEmpty.ForeColor = System.Drawing.Color.Gray;
            this.lblSelfieEmpty.Location = new System.Drawing.Point(10, 29);
            this.lblSelfieEmpty.Name = "lblSelfieEmpty";
            this.lblSelfieEmpty.Size = new System.Drawing.Size(313, 475);
            this.lblSelfieEmpty.TabIndex = 1;
            this.lblSelfieEmpty.Text = "(no hay imagen)";
            this.lblSelfieEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSelfieEmpty.Visible = false;
            // 
            // gbDocFront
            // 
            this.gbDocFront.Controls.Add(this.pbDocFront);
            this.gbDocFront.Controls.Add(this.lblDocFrontEmpty);
            this.gbDocFront.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDocFront.Location = new System.Drawing.Point(357, 8);
            this.gbDocFront.Name = "gbDocFront";
            this.gbDocFront.Padding = new System.Windows.Forms.Padding(10);
            this.gbDocFront.Size = new System.Drawing.Size(333, 514);
            this.gbDocFront.TabIndex = 1;
            this.gbDocFront.TabStop = false;
            this.gbDocFront.Text = "DNI - Anverso";
            // 
            // pbDocFront
            // 
            this.pbDocFront.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbDocFront.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbDocFront.Location = new System.Drawing.Point(10, 29);
            this.pbDocFront.Name = "pbDocFront";
            this.pbDocFront.Size = new System.Drawing.Size(313, 475);
            this.pbDocFront.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDocFront.TabIndex = 0;
            this.pbDocFront.TabStop = false;
            // 
            // lblDocFrontEmpty
            // 
            this.lblDocFrontEmpty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDocFrontEmpty.ForeColor = System.Drawing.Color.Gray;
            this.lblDocFrontEmpty.Location = new System.Drawing.Point(10, 29);
            this.lblDocFrontEmpty.Name = "lblDocFrontEmpty";
            this.lblDocFrontEmpty.Size = new System.Drawing.Size(313, 475);
            this.lblDocFrontEmpty.TabIndex = 1;
            this.lblDocFrontEmpty.Text = "(no hay imagen)";
            this.lblDocFrontEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDocFrontEmpty.Visible = false;
            // 
            // gbDocBack
            // 
            this.gbDocBack.Controls.Add(this.pbDocBack);
            this.gbDocBack.Controls.Add(this.lblDocBackEmpty);
            this.gbDocBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDocBack.Location = new System.Drawing.Point(696, 8);
            this.gbDocBack.Name = "gbDocBack";
            this.gbDocBack.Padding = new System.Windows.Forms.Padding(10);
            this.gbDocBack.Size = new System.Drawing.Size(336, 514);
            this.gbDocBack.TabIndex = 2;
            this.gbDocBack.TabStop = false;
            this.gbDocBack.Text = "DNI - Reverso";
            // 
            // pbDocBack
            // 
            this.pbDocBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbDocBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbDocBack.Location = new System.Drawing.Point(10, 29);
            this.pbDocBack.Name = "pbDocBack";
            this.pbDocBack.Size = new System.Drawing.Size(316, 475);
            this.pbDocBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDocBack.TabIndex = 0;
            this.pbDocBack.TabStop = false;
            // 
            // lblDocBackEmpty
            // 
            this.lblDocBackEmpty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDocBackEmpty.ForeColor = System.Drawing.Color.Gray;
            this.lblDocBackEmpty.Location = new System.Drawing.Point(10, 29);
            this.lblDocBackEmpty.Name = "lblDocBackEmpty";
            this.lblDocBackEmpty.Size = new System.Drawing.Size(316, 475);
            this.lblDocBackEmpty.TabIndex = 1;
            this.lblDocBackEmpty.Text = "(no hay imagen)";
            this.lblDocBackEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDocBackEmpty.Visible = false;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnApprove);
            this.panelBottom.Controls.Add(this.btnDeny);
            this.panelBottom.Controls.Add(this.btnClose);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 530);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.panelBottom.Size = new System.Drawing.Size(1050, 70);
            this.panelBottom.TabIndex = 2;
            // 
            // btnApprove
            // 
            this.btnApprove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApprove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(240)))), ((int)(((byte)(200)))));
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnApprove.Location = new System.Drawing.Point(620, 15);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(160, 40);
            this.btnApprove.TabIndex = 0;
            this.btnApprove.Text = "✓  Aprobar";
            this.btnApprove.UseVisualStyleBackColor = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnDeny
            // 
            this.btnDeny.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeny.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDeny.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeny.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeny.Location = new System.Drawing.Point(790, 15);
            this.btnDeny.Name = "btnDeny";
            this.btnDeny.Size = new System.Drawing.Size(160, 40);
            this.btnDeny.TabIndex = 1;
            this.btnDeny.Text = "✗  Denegar";
            this.btnDeny.UseVisualStyleBackColor = false;
            this.btnDeny.Click += new System.EventHandler(this.btnDeny_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(960, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 40);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // VerifyImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 600);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.panelBottom);
            this.MinimumSize = new System.Drawing.Size(800, 550);
            this.Name = "VerifyImages";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Verificación de identidad";
            this.tableLayoutPanel.ResumeLayout(false);
            this.gbSelfie.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSelfie)).EndInit();
            this.gbDocFront.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbDocFront)).EndInit();
            this.gbDocBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbDocBack)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.GroupBox gbSelfie;
        private System.Windows.Forms.PictureBox pbSelfie;
        private System.Windows.Forms.Label lblSelfieEmpty;
        private System.Windows.Forms.GroupBox gbDocFront;
        private System.Windows.Forms.PictureBox pbDocFront;
        private System.Windows.Forms.Label lblDocFrontEmpty;
        private System.Windows.Forms.GroupBox gbDocBack;
        private System.Windows.Forms.PictureBox pbDocBack;
        private System.Windows.Forms.Label lblDocBackEmpty;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnDeny;
        private System.Windows.Forms.Button btnClose;
    }
}

namespace handlyAdminScreens.Views
{
    partial class SolveReport
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
            this.gbReport = new System.Windows.Forms.GroupBox();
            this.lblOriginValue = new System.Windows.Forms.Label();
            this.lblOrigin = new System.Windows.Forms.Label();
            this.lblCauseValue = new System.Windows.Forms.Label();
            this.lblCause = new System.Windows.Forms.Label();
            this.lblReporteeValue = new System.Windows.Forms.Label();
            this.lblReportee = new System.Windows.Forms.Label();
            this.lblReporterValue = new System.Windows.Forms.Label();
            this.lblReporter = new System.Windows.Forms.Label();
            this.gbContext = new System.Windows.Forms.GroupBox();
            this.cmbContextItem = new System.Windows.Forms.ComboBox();
            this.lblContextPicker = new System.Windows.Forms.Label();
            this.panelTaskDetails = new System.Windows.Forms.Panel();
            this.lblTaskDescriptionValue = new System.Windows.Forms.Label();
            this.lblTaskDescription = new System.Windows.Forms.Label();
            this.lblTaskStateValue = new System.Windows.Forms.Label();
            this.lblTaskState = new System.Windows.Forms.Label();
            this.lblTaskCreationValue = new System.Windows.Forms.Label();
            this.lblTaskCreation = new System.Windows.Forms.Label();
            this.lblTaskTitleValue = new System.Windows.Forms.Label();
            this.lblTaskTitle = new System.Windows.Forms.Label();
            this.gridMessages = new System.Windows.Forms.DataGridView();
            this.lblContextEmpty = new System.Windows.Forms.Label();
            this.gbVerdict = new System.Windows.Forms.GroupBox();
            this.rbDismiss = new System.Windows.Forms.RadioButton();
            this.rbReporteeWins = new System.Windows.Forms.RadioButton();
            this.rbReporterWins = new System.Windows.Forms.RadioButton();
            this.chkBanLoser = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbReport.SuspendLayout();
            this.gbContext.SuspendLayout();
            this.panelTaskDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMessages)).BeginInit();
            this.gbVerdict.SuspendLayout();
            this.SuspendLayout();
            //
            // gbReport
            //
            this.gbReport.Controls.Add(this.lblOriginValue);
            this.gbReport.Controls.Add(this.lblOrigin);
            this.gbReport.Controls.Add(this.lblCauseValue);
            this.gbReport.Controls.Add(this.lblCause);
            this.gbReport.Controls.Add(this.lblReporteeValue);
            this.gbReport.Controls.Add(this.lblReportee);
            this.gbReport.Controls.Add(this.lblReporterValue);
            this.gbReport.Controls.Add(this.lblReporter);
            this.gbReport.Location = new System.Drawing.Point(15, 15);
            this.gbReport.Name = "gbReport";
            this.gbReport.Size = new System.Drawing.Size(780, 110);
            this.gbReport.TabIndex = 0;
            this.gbReport.TabStop = false;
            this.gbReport.Text = "Datos de la denuncia";
            //
            // lblReporter
            //
            this.lblReporter.AutoSize = true;
            this.lblReporter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblReporter.Location = new System.Drawing.Point(15, 30);
            this.lblReporter.Name = "lblReporter";
            this.lblReporter.Size = new System.Drawing.Size(105, 18);
            this.lblReporter.Text = "Denunciante:";
            //
            // lblReporterValue
            //
            this.lblReporterValue.AutoSize = true;
            this.lblReporterValue.Location = new System.Drawing.Point(135, 30);
            this.lblReporterValue.Name = "lblReporterValue";
            this.lblReporterValue.Size = new System.Drawing.Size(10, 18);
            this.lblReporterValue.Text = "-";
            //
            // lblReportee
            //
            this.lblReportee.AutoSize = true;
            this.lblReportee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblReportee.Location = new System.Drawing.Point(15, 55);
            this.lblReportee.Name = "lblReportee";
            this.lblReportee.Size = new System.Drawing.Size(100, 18);
            this.lblReportee.Text = "Denunciado:";
            //
            // lblReporteeValue
            //
            this.lblReporteeValue.AutoSize = true;
            this.lblReporteeValue.Location = new System.Drawing.Point(135, 55);
            this.lblReporteeValue.Name = "lblReporteeValue";
            this.lblReporteeValue.Size = new System.Drawing.Size(10, 18);
            this.lblReporteeValue.Text = "-";
            //
            // lblCause
            //
            this.lblCause.AutoSize = true;
            this.lblCause.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblCause.Location = new System.Drawing.Point(15, 80);
            this.lblCause.Name = "lblCause";
            this.lblCause.Size = new System.Drawing.Size(60, 18);
            this.lblCause.Text = "Motivo:";
            //
            // lblCauseValue
            //
            this.lblCauseValue.AutoSize = true;
            this.lblCauseValue.Location = new System.Drawing.Point(135, 80);
            this.lblCauseValue.Name = "lblCauseValue";
            this.lblCauseValue.Size = new System.Drawing.Size(10, 18);
            this.lblCauseValue.Text = "-";
            //
            // lblOrigin
            //
            this.lblOrigin.AutoSize = true;
            this.lblOrigin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblOrigin.Location = new System.Drawing.Point(450, 30);
            this.lblOrigin.Name = "lblOrigin";
            this.lblOrigin.Size = new System.Drawing.Size(60, 18);
            this.lblOrigin.Text = "Origen:";
            //
            // lblOriginValue
            //
            this.lblOriginValue.AutoSize = true;
            this.lblOriginValue.Location = new System.Drawing.Point(530, 30);
            this.lblOriginValue.Name = "lblOriginValue";
            this.lblOriginValue.Size = new System.Drawing.Size(10, 18);
            this.lblOriginValue.Text = "-";
            //
            // gbContext
            //
            this.gbContext.Controls.Add(this.cmbContextItem);
            this.gbContext.Controls.Add(this.lblContextPicker);
            this.gbContext.Controls.Add(this.panelTaskDetails);
            this.gbContext.Controls.Add(this.gridMessages);
            this.gbContext.Controls.Add(this.lblContextEmpty);
            this.gbContext.Location = new System.Drawing.Point(15, 135);
            this.gbContext.Name = "gbContext";
            this.gbContext.Size = new System.Drawing.Size(780, 320);
            this.gbContext.TabIndex = 1;
            this.gbContext.TabStop = false;
            this.gbContext.Text = "Contexto";
            //
            // lblContextPicker
            //
            this.lblContextPicker.AutoSize = true;
            this.lblContextPicker.Location = new System.Drawing.Point(15, 30);
            this.lblContextPicker.Name = "lblContextPicker";
            this.lblContextPicker.Size = new System.Drawing.Size(48, 18);
            this.lblContextPicker.Text = "Ver:";
            //
            // cmbContextItem
            //
            this.cmbContextItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContextItem.FormattingEnabled = true;
            this.cmbContextItem.Location = new System.Drawing.Point(70, 27);
            this.cmbContextItem.Name = "cmbContextItem";
            this.cmbContextItem.Size = new System.Drawing.Size(450, 26);
            this.cmbContextItem.TabIndex = 0;
            this.cmbContextItem.SelectedIndexChanged += new System.EventHandler(this.cmbContextItem_SelectedIndexChanged);
            //
            // gridMessages
            //
            this.gridMessages.AllowUserToAddRows = false;
            this.gridMessages.AllowUserToDeleteRows = false;
            this.gridMessages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMessages.Location = new System.Drawing.Point(15, 70);
            this.gridMessages.Name = "gridMessages";
            this.gridMessages.ReadOnly = true;
            this.gridMessages.RowHeadersVisible = false;
            this.gridMessages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridMessages.Size = new System.Drawing.Size(750, 235);
            this.gridMessages.TabIndex = 1;
            this.gridMessages.Visible = false;
            //
            // panelTaskDetails
            //
            this.panelTaskDetails.Controls.Add(this.lblTaskDescriptionValue);
            this.panelTaskDetails.Controls.Add(this.lblTaskDescription);
            this.panelTaskDetails.Controls.Add(this.lblTaskStateValue);
            this.panelTaskDetails.Controls.Add(this.lblTaskState);
            this.panelTaskDetails.Controls.Add(this.lblTaskCreationValue);
            this.panelTaskDetails.Controls.Add(this.lblTaskCreation);
            this.panelTaskDetails.Controls.Add(this.lblTaskTitleValue);
            this.panelTaskDetails.Controls.Add(this.lblTaskTitle);
            this.panelTaskDetails.Location = new System.Drawing.Point(15, 70);
            this.panelTaskDetails.Name = "panelTaskDetails";
            this.panelTaskDetails.Size = new System.Drawing.Size(750, 235);
            this.panelTaskDetails.TabIndex = 2;
            this.panelTaskDetails.Visible = false;
            //
            // lblTaskTitle
            //
            this.lblTaskTitle.AutoSize = true;
            this.lblTaskTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTaskTitle.Location = new System.Drawing.Point(5, 5);
            this.lblTaskTitle.Name = "lblTaskTitle";
            this.lblTaskTitle.Text = "Título:";
            //
            // lblTaskTitleValue
            //
            this.lblTaskTitleValue.AutoSize = true;
            this.lblTaskTitleValue.Location = new System.Drawing.Point(120, 5);
            this.lblTaskTitleValue.MaximumSize = new System.Drawing.Size(620, 0);
            this.lblTaskTitleValue.Name = "lblTaskTitleValue";
            this.lblTaskTitleValue.Text = "-";
            //
            // lblTaskState
            //
            this.lblTaskState.AutoSize = true;
            this.lblTaskState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTaskState.Location = new System.Drawing.Point(5, 35);
            this.lblTaskState.Name = "lblTaskState";
            this.lblTaskState.Text = "Estado:";
            //
            // lblTaskStateValue
            //
            this.lblTaskStateValue.AutoSize = true;
            this.lblTaskStateValue.Location = new System.Drawing.Point(120, 35);
            this.lblTaskStateValue.Name = "lblTaskStateValue";
            this.lblTaskStateValue.Text = "-";
            //
            // lblTaskCreation
            //
            this.lblTaskCreation.AutoSize = true;
            this.lblTaskCreation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTaskCreation.Location = new System.Drawing.Point(5, 65);
            this.lblTaskCreation.Name = "lblTaskCreation";
            this.lblTaskCreation.Text = "Creación:";
            //
            // lblTaskCreationValue
            //
            this.lblTaskCreationValue.AutoSize = true;
            this.lblTaskCreationValue.Location = new System.Drawing.Point(120, 65);
            this.lblTaskCreationValue.Name = "lblTaskCreationValue";
            this.lblTaskCreationValue.Text = "-";
            //
            // lblTaskDescription
            //
            this.lblTaskDescription.AutoSize = true;
            this.lblTaskDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTaskDescription.Location = new System.Drawing.Point(5, 95);
            this.lblTaskDescription.Name = "lblTaskDescription";
            this.lblTaskDescription.Text = "Descripción:";
            //
            // lblTaskDescriptionValue
            //
            this.lblTaskDescriptionValue.AutoSize = true;
            this.lblTaskDescriptionValue.Location = new System.Drawing.Point(120, 95);
            this.lblTaskDescriptionValue.MaximumSize = new System.Drawing.Size(620, 0);
            this.lblTaskDescriptionValue.Name = "lblTaskDescriptionValue";
            this.lblTaskDescriptionValue.Text = "-";
            //
            // lblContextEmpty
            //
            this.lblContextEmpty.AutoSize = true;
            this.lblContextEmpty.ForeColor = System.Drawing.Color.Gray;
            this.lblContextEmpty.Location = new System.Drawing.Point(15, 145);
            this.lblContextEmpty.Name = "lblContextEmpty";
            this.lblContextEmpty.Text = "No hay contexto disponible para esta denuncia.";
            this.lblContextEmpty.Visible = false;
            //
            // gbVerdict
            //
            this.gbVerdict.Controls.Add(this.chkBanLoser);
            this.gbVerdict.Controls.Add(this.rbDismiss);
            this.gbVerdict.Controls.Add(this.rbReporteeWins);
            this.gbVerdict.Controls.Add(this.rbReporterWins);
            this.gbVerdict.Location = new System.Drawing.Point(15, 465);
            this.gbVerdict.Name = "gbVerdict";
            this.gbVerdict.Size = new System.Drawing.Size(780, 110);
            this.gbVerdict.TabIndex = 2;
            this.gbVerdict.TabStop = false;
            this.gbVerdict.Text = "Veredicto";
            //
            // rbReporterWins
            //
            this.rbReporterWins.AutoSize = true;
            this.rbReporterWins.Location = new System.Drawing.Point(15, 30);
            this.rbReporterWins.Name = "rbReporterWins";
            this.rbReporterWins.Text = "Gana el denunciante";
            this.rbReporterWins.UseVisualStyleBackColor = true;
            //
            // rbReporteeWins
            //
            this.rbReporteeWins.AutoSize = true;
            this.rbReporteeWins.Location = new System.Drawing.Point(220, 30);
            this.rbReporteeWins.Name = "rbReporteeWins";
            this.rbReporteeWins.Text = "Gana el denunciado";
            this.rbReporteeWins.UseVisualStyleBackColor = true;
            //
            // rbDismiss
            //
            this.rbDismiss.AutoSize = true;
            this.rbDismiss.Location = new System.Drawing.Point(425, 30);
            this.rbDismiss.Name = "rbDismiss";
            this.rbDismiss.Text = "Desestimar denuncia";
            this.rbDismiss.UseVisualStyleBackColor = true;
            //
            // chkBanLoser
            //
            this.chkBanLoser.AutoSize = true;
            this.chkBanLoser.Location = new System.Drawing.Point(15, 70);
            this.chkBanLoser.Name = "chkBanLoser";
            this.chkBanLoser.Text = "También banear al perdedor";
            this.chkBanLoser.UseVisualStyleBackColor = true;
            //
            // btnCancel
            //
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(560, 590);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 35);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // btnSave
            //
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(224)))), ((int)(((byte)(232)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(685, 590);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 35);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // SolveReport
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 640);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbVerdict);
            this.Controls.Add(this.gbContext);
            this.Controls.Add(this.gbReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SolveReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Resolver denuncia";
            this.Load += new System.EventHandler(this.SolveReport_Load);
            this.gbReport.ResumeLayout(false);
            this.gbReport.PerformLayout();
            this.gbContext.ResumeLayout(false);
            this.gbContext.PerformLayout();
            this.panelTaskDetails.ResumeLayout(false);
            this.panelTaskDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMessages)).EndInit();
            this.gbVerdict.ResumeLayout(false);
            this.gbVerdict.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox gbReport;
        private System.Windows.Forms.Label lblOriginValue;
        private System.Windows.Forms.Label lblOrigin;
        private System.Windows.Forms.Label lblCauseValue;
        private System.Windows.Forms.Label lblCause;
        private System.Windows.Forms.Label lblReporteeValue;
        private System.Windows.Forms.Label lblReportee;
        private System.Windows.Forms.Label lblReporterValue;
        private System.Windows.Forms.Label lblReporter;
        private System.Windows.Forms.GroupBox gbContext;
        private System.Windows.Forms.ComboBox cmbContextItem;
        private System.Windows.Forms.Label lblContextPicker;
        private System.Windows.Forms.Panel panelTaskDetails;
        private System.Windows.Forms.Label lblTaskDescriptionValue;
        private System.Windows.Forms.Label lblTaskDescription;
        private System.Windows.Forms.Label lblTaskStateValue;
        private System.Windows.Forms.Label lblTaskState;
        private System.Windows.Forms.Label lblTaskCreationValue;
        private System.Windows.Forms.Label lblTaskCreation;
        private System.Windows.Forms.Label lblTaskTitleValue;
        private System.Windows.Forms.Label lblTaskTitle;
        private System.Windows.Forms.DataGridView gridMessages;
        private System.Windows.Forms.Label lblContextEmpty;
        private System.Windows.Forms.GroupBox gbVerdict;
        private System.Windows.Forms.RadioButton rbDismiss;
        private System.Windows.Forms.RadioButton rbReporteeWins;
        private System.Windows.Forms.RadioButton rbReporterWins;
        private System.Windows.Forms.CheckBox chkBanLoser;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}

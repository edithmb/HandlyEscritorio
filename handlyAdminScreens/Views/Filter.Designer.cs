namespace handlyAdminScreens.Views
{
    partial class Filter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filter));
            this.btnFilter = new System.Windows.Forms.Button();
            this.panelUserFilter = new System.Windows.Forms.Panel();
            this.gbAccountState = new System.Windows.Forms.GroupBox();
            this.chklAccountState = new System.Windows.Forms.CheckedListBox();
            this.gbProfession = new System.Windows.Forms.GroupBox();
            this.chklProfessions = new System.Windows.Forms.CheckedListBox();
            this.gbLastConnection = new System.Windows.Forms.GroupBox();
            this.lblConnectionFrom = new System.Windows.Forms.Label();
            this.dtpLastConnectionFrom = new System.Windows.Forms.DateTimePicker();
            this.lblConnectionTo = new System.Windows.Forms.Label();
            this.dtpLastConnectionTo = new System.Windows.Forms.DateTimePicker();
            this.gbCreation = new System.Windows.Forms.GroupBox();
            this.lblAccountFrom = new System.Windows.Forms.Label();
            this.dtpCreatedFrom = new System.Windows.Forms.DateTimePicker();
            this.lblCreationTo = new System.Windows.Forms.Label();
            this.dtpCreatedTo = new System.Windows.Forms.DateTimePicker();
            this.gbTypeAppUser = new System.Windows.Forms.GroupBox();
            this.chkProfessional = new System.Windows.Forms.CheckBox();
            this.chkClient = new System.Windows.Forms.CheckBox();
            this.gbAppUser = new System.Windows.Forms.GroupBox();
            this.chkAppYes = new System.Windows.Forms.CheckBox();
            this.chkAppNo = new System.Windows.Forms.CheckBox();
            this.lblAccountCreation = new System.Windows.Forms.Label();
            this.lblAppUserType = new System.Windows.Forms.Label();
            this.panelTransactionFilter = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTaskFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTaskUntil = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chklTaskState = new System.Windows.Forms.CheckedListBox();
            this.panelReportFilter = new System.Windows.Forms.Panel();
            this.gbReportState = new System.Windows.Forms.GroupBox();
            this.chklReportState = new System.Windows.Forms.CheckedListBox();
            this.panelUserFilter.SuspendLayout();
            this.gbAccountState.SuspendLayout();
            this.gbProfession.SuspendLayout();
            this.gbLastConnection.SuspendLayout();
            this.gbCreation.SuspendLayout();
            this.gbTypeAppUser.SuspendLayout();
            this.gbAppUser.SuspendLayout();
            this.panelTransactionFilter.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelReportFilter.SuspendLayout();
            this.gbReportState.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(128)))), ((int)(((byte)(226)))));
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(287, 511);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 35);
            this.btnFilter.TabIndex = 0;
            this.btnFilter.Text = "Filtrar";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // panelUserFilter
            // 
            this.panelUserFilter.Controls.Add(this.gbAccountState);
            this.panelUserFilter.Controls.Add(this.gbProfession);
            this.panelUserFilter.Controls.Add(this.gbLastConnection);
            this.panelUserFilter.Controls.Add(this.gbCreation);
            this.panelUserFilter.Controls.Add(this.gbTypeAppUser);
            this.panelUserFilter.Controls.Add(this.gbAppUser);
            this.panelUserFilter.Controls.Add(this.lblAccountCreation);
            this.panelUserFilter.Controls.Add(this.lblAppUserType);
            this.panelUserFilter.Location = new System.Drawing.Point(23, 12);
            this.panelUserFilter.Name = "panelUserFilter";
            this.panelUserFilter.Size = new System.Drawing.Size(585, 474);
            this.panelUserFilter.TabIndex = 1;
            this.panelUserFilter.Paint += new System.Windows.Forms.PaintEventHandler(this.panelUserFilter_Paint);
            // 
            // gbAccountState
            // 
            this.gbAccountState.Controls.Add(this.chklAccountState);
            this.gbAccountState.Location = new System.Drawing.Point(334, 282);
            this.gbAccountState.Name = "gbAccountState";
            this.gbAccountState.Size = new System.Drawing.Size(225, 171);
            this.gbAccountState.TabIndex = 25;
            this.gbAccountState.TabStop = false;
            this.gbAccountState.Text = "Estado de la cuenta";
            // 
            // chklAccountState
            // 
            this.chklAccountState.CheckOnClick = true;
            this.chklAccountState.FormattingEnabled = true;
            this.chklAccountState.Location = new System.Drawing.Point(15, 30);
            this.chklAccountState.Name = "chklAccountState";
            this.chklAccountState.Size = new System.Drawing.Size(193, 119);
            this.chklAccountState.TabIndex = 19;
            this.chklAccountState.SelectedIndexChanged += new System.EventHandler(this.chklAccountState_SelectedIndexChanged);
            // 
            // gbProfession
            // 
            this.gbProfession.Controls.Add(this.chklProfessions);
            this.gbProfession.Location = new System.Drawing.Point(334, 13);
            this.gbProfession.Name = "gbProfession";
            this.gbProfession.Size = new System.Drawing.Size(225, 256);
            this.gbProfession.TabIndex = 24;
            this.gbProfession.TabStop = false;
            this.gbProfession.Text = "Professión";
            // 
            // chklProfessions
            // 
            this.chklProfessions.CheckOnClick = true;
            this.chklProfessions.FormattingEnabled = true;
            this.chklProfessions.Location = new System.Drawing.Point(15, 28);
            this.chklProfessions.Name = "chklProfessions";
            this.chklProfessions.Size = new System.Drawing.Size(193, 211);
            this.chklProfessions.TabIndex = 7;
            this.chklProfessions.SelectedIndexChanged += new System.EventHandler(this.chklProfessions_SelectedIndexChanged);
            // 
            // gbLastConnection
            // 
            this.gbLastConnection.Controls.Add(this.lblConnectionFrom);
            this.gbLastConnection.Controls.Add(this.dtpLastConnectionFrom);
            this.gbLastConnection.Controls.Add(this.lblConnectionTo);
            this.gbLastConnection.Controls.Add(this.dtpLastConnectionTo);
            this.gbLastConnection.Location = new System.Drawing.Point(11, 342);
            this.gbLastConnection.Name = "gbLastConnection";
            this.gbLastConnection.Size = new System.Drawing.Size(305, 111);
            this.gbLastConnection.TabIndex = 23;
            this.gbLastConnection.TabStop = false;
            this.gbLastConnection.Text = "Fecha última conexión:";
            // 
            // lblConnectionFrom
            // 
            this.lblConnectionFrom.AutoSize = true;
            this.lblConnectionFrom.Location = new System.Drawing.Point(6, 34);
            this.lblConnectionFrom.Name = "lblConnectionFrom";
            this.lblConnectionFrom.Size = new System.Drawing.Size(60, 20);
            this.lblConnectionFrom.TabIndex = 15;
            this.lblConnectionFrom.Text = "Desde:";
            // 
            // dtpLastConnectionFrom
            // 
            this.dtpLastConnectionFrom.Location = new System.Drawing.Point(73, 29);
            this.dtpLastConnectionFrom.Name = "dtpLastConnectionFrom";
            this.dtpLastConnectionFrom.ShowCheckBox = true;
            this.dtpLastConnectionFrom.Size = new System.Drawing.Size(220, 26);
            this.dtpLastConnectionFrom.TabIndex = 11;
            // 
            // lblConnectionTo
            // 
            this.lblConnectionTo.AutoSize = true;
            this.lblConnectionTo.Location = new System.Drawing.Point(6, 74);
            this.lblConnectionTo.Name = "lblConnectionTo";
            this.lblConnectionTo.Size = new System.Drawing.Size(56, 20);
            this.lblConnectionTo.TabIndex = 17;
            this.lblConnectionTo.Text = "Hasta:";
            // 
            // dtpLastConnectionTo
            // 
            this.dtpLastConnectionTo.Location = new System.Drawing.Point(73, 69);
            this.dtpLastConnectionTo.Name = "dtpLastConnectionTo";
            this.dtpLastConnectionTo.ShowCheckBox = true;
            this.dtpLastConnectionTo.Size = new System.Drawing.Size(220, 26);
            this.dtpLastConnectionTo.TabIndex = 12;
            // 
            // gbCreation
            // 
            this.gbCreation.Controls.Add(this.lblAccountFrom);
            this.gbCreation.Controls.Add(this.dtpCreatedFrom);
            this.gbCreation.Controls.Add(this.lblCreationTo);
            this.gbCreation.Controls.Add(this.dtpCreatedTo);
            this.gbCreation.Location = new System.Drawing.Point(11, 207);
            this.gbCreation.Name = "gbCreation";
            this.gbCreation.Size = new System.Drawing.Size(305, 118);
            this.gbCreation.TabIndex = 22;
            this.gbCreation.TabStop = false;
            this.gbCreation.Text = "Fecha creación de cuenta";
            // 
            // lblAccountFrom
            // 
            this.lblAccountFrom.AutoSize = true;
            this.lblAccountFrom.Location = new System.Drawing.Point(6, 35);
            this.lblAccountFrom.Name = "lblAccountFrom";
            this.lblAccountFrom.Size = new System.Drawing.Size(60, 20);
            this.lblAccountFrom.TabIndex = 14;
            this.lblAccountFrom.Text = "Desde:";
            // 
            // dtpCreatedFrom
            // 
            this.dtpCreatedFrom.Location = new System.Drawing.Point(73, 30);
            this.dtpCreatedFrom.Name = "dtpCreatedFrom";
            this.dtpCreatedFrom.ShowCheckBox = true;
            this.dtpCreatedFrom.Size = new System.Drawing.Size(220, 26);
            this.dtpCreatedFrom.TabIndex = 9;
            // 
            // lblCreationTo
            // 
            this.lblCreationTo.AutoSize = true;
            this.lblCreationTo.Location = new System.Drawing.Point(6, 80);
            this.lblCreationTo.Name = "lblCreationTo";
            this.lblCreationTo.Size = new System.Drawing.Size(56, 20);
            this.lblCreationTo.TabIndex = 16;
            this.lblCreationTo.Text = "Hasta:";
            this.lblCreationTo.Click += new System.EventHandler(this.lblCreationTo_Click);
            // 
            // dtpCreatedTo
            // 
            this.dtpCreatedTo.Location = new System.Drawing.Point(73, 75);
            this.dtpCreatedTo.Name = "dtpCreatedTo";
            this.dtpCreatedTo.ShowCheckBox = true;
            this.dtpCreatedTo.Size = new System.Drawing.Size(220, 26);
            this.dtpCreatedTo.TabIndex = 10;
            // 
            // gbTypeAppUser
            // 
            this.gbTypeAppUser.Controls.Add(this.chkProfessional);
            this.gbTypeAppUser.Controls.Add(this.chkClient);
            this.gbTypeAppUser.Location = new System.Drawing.Point(11, 105);
            this.gbTypeAppUser.Name = "gbTypeAppUser";
            this.gbTypeAppUser.Size = new System.Drawing.Size(305, 80);
            this.gbTypeAppUser.TabIndex = 21;
            this.gbTypeAppUser.TabStop = false;
            this.gbTypeAppUser.Text = "Tipo de usuario/a en la app";
            // 
            // chkProfessional
            // 
            this.chkProfessional.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkProfessional.AutoSize = true;
            this.chkProfessional.Location = new System.Drawing.Point(14, 34);
            this.chkProfessional.Name = "chkProfessional";
            this.chkProfessional.Size = new System.Drawing.Size(98, 30);
            this.chkProfessional.TabIndex = 4;
            this.chkProfessional.Text = "Profesional";
            this.chkProfessional.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkProfessional.UseVisualStyleBackColor = true;
            this.chkProfessional.CheckedChanged += new System.EventHandler(this.chkProfessional_CheckedChanged);
            // 
            // chkClient
            // 
            this.chkClient.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkClient.AutoSize = true;
            this.chkClient.Location = new System.Drawing.Point(151, 34);
            this.chkClient.Name = "chkClient";
            this.chkClient.Size = new System.Drawing.Size(68, 30);
            this.chkClient.TabIndex = 5;
            this.chkClient.Text = "Cliente";
            this.chkClient.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkClient.UseVisualStyleBackColor = true;
            this.chkClient.CheckedChanged += new System.EventHandler(this.chkClient_CheckedChanged);
            // 
            // gbAppUser
            // 
            this.gbAppUser.Controls.Add(this.chkAppYes);
            this.gbAppUser.Controls.Add(this.chkAppNo);
            this.gbAppUser.Location = new System.Drawing.Point(11, 13);
            this.gbAppUser.Name = "gbAppUser";
            this.gbAppUser.Size = new System.Drawing.Size(305, 80);
            this.gbAppUser.TabIndex = 20;
            this.gbAppUser.TabStop = false;
            this.gbAppUser.Text = "Usuario/a de la app";
            // 
            // chkAppYes
            // 
            this.chkAppYes.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkAppYes.AutoSize = true;
            this.chkAppYes.Location = new System.Drawing.Point(14, 34);
            this.chkAppYes.Name = "chkAppYes";
            this.chkAppYes.Size = new System.Drawing.Size(30, 30);
            this.chkAppYes.TabIndex = 0;
            this.chkAppYes.Text = "sí";
            this.chkAppYes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkAppYes.UseVisualStyleBackColor = true;
            this.chkAppYes.CheckedChanged += new System.EventHandler(this.chkAppYes_CheckedChanged);
            // 
            // chkAppNo
            // 
            this.chkAppNo.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkAppNo.AutoSize = true;
            this.chkAppNo.Location = new System.Drawing.Point(73, 33);
            this.chkAppNo.Name = "chkAppNo";
            this.chkAppNo.Size = new System.Drawing.Size(37, 30);
            this.chkAppNo.TabIndex = 1;
            this.chkAppNo.Text = "no";
            this.chkAppNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkAppNo.UseVisualStyleBackColor = true;
            this.chkAppNo.CheckedChanged += new System.EventHandler(this.chkAppNo_CheckedChanged);
            // 
            // lblAccountCreation
            // 
            this.lblAccountCreation.AutoSize = true;
            this.lblAccountCreation.Location = new System.Drawing.Point(24, 218);
            this.lblAccountCreation.Name = "lblAccountCreation";
            this.lblAccountCreation.Size = new System.Drawing.Size(0, 20);
            this.lblAccountCreation.TabIndex = 8;
            // 
            // lblAppUserType
            // 
            this.lblAppUserType.AutoSize = true;
            this.lblAppUserType.Location = new System.Drawing.Point(24, 125);
            this.lblAppUserType.Name = "lblAppUserType";
            this.lblAppUserType.Size = new System.Drawing.Size(0, 20);
            this.lblAppUserType.TabIndex = 3;
            // 
            // panelTransactionFilter
            // 
            this.panelTransactionFilter.Controls.Add(this.groupBox2);
            this.panelTransactionFilter.Controls.Add(this.groupBox1);
            this.panelTransactionFilter.Location = new System.Drawing.Point(693, 101);
            this.panelTransactionFilter.Name = "panelTransactionFilter";
            this.panelTransactionFilter.Size = new System.Drawing.Size(523, 385);
            this.panelTransactionFilter.TabIndex = 0;
            this.panelTransactionFilter.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTransactionFilter_Paint);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dtpTaskFrom);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtpTaskUntil);
            this.groupBox2.Location = new System.Drawing.Point(13, 198);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(305, 118);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fecha creación de la tarea";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Desde:";
            // 
            // dtpTaskFrom
            // 
            this.dtpTaskFrom.Location = new System.Drawing.Point(73, 30);
            this.dtpTaskFrom.Name = "dtpTaskFrom";
            this.dtpTaskFrom.ShowCheckBox = true;
            this.dtpTaskFrom.Size = new System.Drawing.Size(220, 26);
            this.dtpTaskFrom.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Hasta:";
            // 
            // dtpTaskUntil
            // 
            this.dtpTaskUntil.Location = new System.Drawing.Point(73, 75);
            this.dtpTaskUntil.Name = "dtpTaskUntil";
            this.dtpTaskUntil.ShowCheckBox = true;
            this.dtpTaskUntil.Size = new System.Drawing.Size(220, 26);
            this.dtpTaskUntil.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chklTaskState);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 167);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estado de la tarea";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // chklTaskState
            // 
            this.chklTaskState.CheckOnClick = true;
            this.chklTaskState.FormattingEnabled = true;
            this.chklTaskState.Location = new System.Drawing.Point(15, 28);
            this.chklTaskState.Name = "chklTaskState";
            this.chklTaskState.Size = new System.Drawing.Size(193, 119);
            this.chklTaskState.TabIndex = 20;
            // 
            // panelReportFilter
            // 
            this.panelReportFilter.Controls.Add(this.gbReportState);
            this.panelReportFilter.Location = new System.Drawing.Point(693, 13);
            this.panelReportFilter.Name = "panelReportFilter";
            this.panelReportFilter.Size = new System.Drawing.Size(318, 207);
            this.panelReportFilter.TabIndex = 2;
            // 
            // gbReportState
            // 
            this.gbReportState.Controls.Add(this.chklReportState);
            this.gbReportState.Location = new System.Drawing.Point(13, 13);
            this.gbReportState.Name = "gbReportState";
            this.gbReportState.Size = new System.Drawing.Size(280, 171);
            this.gbReportState.TabIndex = 0;
            this.gbReportState.TabStop = false;
            this.gbReportState.Text = "Estado de la denuncia";
            // 
            // chklReportState
            // 
            this.chklReportState.CheckOnClick = true;
            this.chklReportState.FormattingEnabled = true;
            this.chklReportState.Location = new System.Drawing.Point(15, 30);
            this.chklReportState.Name = "chklReportState";
            this.chklReportState.Size = new System.Drawing.Size(248, 119);
            this.chklReportState.TabIndex = 0;
            // 
            // Filter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 567);
            this.Controls.Add(this.panelReportFilter);
            this.Controls.Add(this.panelTransactionFilter);
            this.Controls.Add(this.panelUserFilter);
            this.Controls.Add(this.btnFilter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Filter";
            this.Text = "Filtrar";
            this.Load += new System.EventHandler(this.Filter_Load);
            this.panelUserFilter.ResumeLayout(false);
            this.panelUserFilter.PerformLayout();
            this.gbAccountState.ResumeLayout(false);
            this.gbProfession.ResumeLayout(false);
            this.gbLastConnection.ResumeLayout(false);
            this.gbLastConnection.PerformLayout();
            this.gbCreation.ResumeLayout(false);
            this.gbCreation.PerformLayout();
            this.gbTypeAppUser.ResumeLayout(false);
            this.gbTypeAppUser.PerformLayout();
            this.gbAppUser.ResumeLayout(false);
            this.gbAppUser.PerformLayout();
            this.panelTransactionFilter.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panelReportFilter.ResumeLayout(false);
            this.gbReportState.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Panel panelUserFilter;
        private System.Windows.Forms.Panel panelTransactionFilter;
        private System.Windows.Forms.CheckBox chkAppNo;
        private System.Windows.Forms.CheckBox chkAppYes;
        private System.Windows.Forms.CheckBox chkClient;
        private System.Windows.Forms.CheckBox chkProfessional;
        private System.Windows.Forms.Label lblAppUserType;
        private System.Windows.Forms.CheckedListBox chklProfessions;
        private System.Windows.Forms.DateTimePicker dtpCreatedFrom;
        private System.Windows.Forms.Label lblAccountCreation;
        private System.Windows.Forms.DateTimePicker dtpLastConnectionFrom;
        private System.Windows.Forms.DateTimePicker dtpCreatedTo;
        private System.Windows.Forms.Label lblAccountFrom;
        private System.Windows.Forms.DateTimePicker dtpLastConnectionTo;
        private System.Windows.Forms.Label lblConnectionTo;
        private System.Windows.Forms.Label lblCreationTo;
        private System.Windows.Forms.Label lblConnectionFrom;
        private System.Windows.Forms.CheckedListBox chklAccountState;
        private System.Windows.Forms.GroupBox gbTypeAppUser;
        private System.Windows.Forms.GroupBox gbAppUser;
        private System.Windows.Forms.GroupBox gbCreation;
        private System.Windows.Forms.GroupBox gbProfession;
        private System.Windows.Forms.GroupBox gbLastConnection;
        private System.Windows.Forms.GroupBox gbAccountState;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox chklTaskState;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTaskFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTaskUntil;
        private System.Windows.Forms.Panel panelReportFilter;
        private System.Windows.Forms.GroupBox gbReportState;
        private System.Windows.Forms.CheckedListBox chklReportState;
    }
}
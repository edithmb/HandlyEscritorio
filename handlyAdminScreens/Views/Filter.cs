using handlyAdminScreens.Models;
using handlyAdminScreens.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace handlyAdminScreens.Views
{
    public partial class Filter : Form
    {
        private CurrentGridType _currentType;

        //TODO crec que es pot treure
        private readonly ApiService _api = new ApiService();

        public BaseFilterOptions SelectedFilters { get; private set; }

        public Filter(CurrentGridType type)
        {
            InitializeComponent();
            _currentType = type;

            panelUserFilter.Location = new Point(12, 12);
            panelTransactionFilter.Location = new Point(12, 12);
            panelReportFilter.Location = new Point(12, 12);

            SetupUI();
        }

        private void Filter_Load(object sender, EventArgs e)
        {
            Size = new Size(412, 423);
        }

        private void SetupUI()
        {
            panelUserFilter.Visible = false;
            panelTransactionFilter.Visible = false;
            panelReportFilter.Visible = false;

            switch (_currentType)
            {
                case CurrentGridType.Users:
                    this.Text = "Filtrar usuarios";
                    panelUserFilter.Visible = true;
                    SelectedFilters = new UserFilterOptions();

                    SetupProfessions();
                    SetupCalendars(_currentType);
                    SetupAccountStates();

                    break;

                case CurrentGridType.Transactions:
                    this.Text = "Filtrar transacciones";
                    panelTransactionFilter.Visible = true;
                    SelectedFilters = new TransactionFilterOptions();

                    SetupTransactionSates();
                    SetupCalendars(_currentType);

                    break;

                case CurrentGridType.Reports:
                    this.Text = "Filtrar denuncias";
                    panelReportFilter.Visible = true;
                    SelectedFilters = new ReportFilterOptions();

                    LoadReportStatesFromCatalog();

                    break;
            }
        }

        // los estados de denuncia se sacan del catálogo cacheado tras el login.
        // sin API call: si catalogs.json estaba bien, esto es instantáneo
        private void LoadReportStatesFromCatalog()
        {
            chklReportState.Items.Clear();
            foreach (var s in Catalogs.Current.ReportStates)
            {
                if (!string.IsNullOrWhiteSpace(s.Name))
                    chklReportState.Items.Add(s.Name);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (_currentType == CurrentGridType.Users)
            {
                var userFilter = (UserFilterOptions)SelectedFilters;


                if (dtpCreatedFrom.Checked && dtpCreatedTo.Checked && dtpCreatedFrom.Value > dtpCreatedTo.Value)
                {
                    MessageBox.Show("La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'");
                    return;
                }

                if (chkAppYes.Checked) userFilter.IsAppUser = 1;
                else if (chkAppNo.Checked) userFilter.IsAppUser = 0;
                else userFilter.IsAppUser = null;

                if (chkClient.Checked) userFilter.RoleName = "cliente";
                else if (chkProfessional.Checked) userFilter.RoleName = "profesional";
                else userFilter.RoleName = null;

                userFilter.Professions.Clear();
                foreach (var p in chklProfessions.CheckedItems)
                {
                    userFilter.Professions.Add(p.ToString().ToLower());
                }

                userFilter.StateName.Clear();
                foreach (var s in chklAccountState.CheckedItems)
                {
                    userFilter.StateName.Add(s.ToString().ToLower());
                }

                if (dtpCreatedFrom.Checked) userFilter.CreatedFromDate = dtpCreatedFrom.Value;
                else userFilter.CreatedFromDate = null;

                if (dtpCreatedTo.Checked) userFilter.CreatedToDate = dtpCreatedTo.Value;
                else userFilter.CreatedToDate = null;

                if (dtpLastConnectionFrom.Checked) userFilter.LastConnectionFromDate = dtpLastConnectionFrom.Value;
                else userFilter.LastConnectionFromDate= null;

                if (dtpLastConnectionTo.Checked) userFilter.LastConnectionToDate = dtpLastConnectionTo.Value;
                else userFilter.LastConnectionToDate= null;


            }
            else if (_currentType == CurrentGridType.Transactions)
            {
                var transactionFilter = (TransactionFilterOptions)SelectedFilters;

                if (dtpTaskFrom.Checked && dtpTaskUntil.Checked && dtpTaskFrom.Value > dtpTaskUntil.Value)
                {
                    MessageBox.Show("La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'");
                    return;
                }

                transactionFilter.TaskState.Clear();
                foreach (var s in chklTaskState.CheckedItems)
                {
                    transactionFilter.TaskState.Add(s.ToString().ToLower());
                }
            }
            else if (_currentType == CurrentGridType.Reports)
            {
                var reportFilter = (ReportFilterOptions)SelectedFilters;
                reportFilter.StateNames.Clear();
                foreach (var s in chklReportState.CheckedItems)
                {
                    // guardamos en minúsculas para el match en Denuncias.ApplyFilterAndSearch
                    reportFilter.StateNames.Add(s.ToString().ToLower());
                }
            }



            SelectedFilters.RemoveFilter = false;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // profesiones desde el catálogo cacheado (NO API call)
        private void SetupProfessions()
        {
            chklProfessions.Items.Clear();
            foreach (var p in Catalogs.Professions)
            {
                if (!string.IsNullOrWhiteSpace(p.NameProfession))
                    chklProfessions.Items.Add(p.NameProfession);
            }
        }

        // estados de cuenta desde el catálogo cacheado (NO API)
        private void SetupAccountStates()
        {
            chklAccountState.Items.Clear();
            foreach (var s in Catalogs.Current.AccountStates)
            {
                if (!string.IsNullOrWhiteSpace(s.Name))
                    chklAccountState.Items.Add(s.Name);
            }
        }

        private void SetupTransactionSates()
        {
            chklTaskState.Items.Clear();
            foreach (var s in Catalogs.Current.TaskStates)
            {
                if (string.IsNullOrWhiteSpace(s.Name))
                    chklTaskState.Items.Add(s.Name);
            }
        }

        private void SetupCalendars(CurrentGridType type)
        {
            switch (type)
            {
                case CurrentGridType.Users:

                    dtpCreatedFrom.ShowCheckBox = true;
                    dtpCreatedTo.ShowCheckBox = true;
                    dtpLastConnectionFrom.ShowCheckBox = true;
                    dtpLastConnectionTo.ShowCheckBox = true;

                    dtpCreatedFrom.Checked = false;
                    dtpCreatedTo.Checked = false;
                    dtpLastConnectionFrom.Checked = false;
                    dtpLastConnectionTo.Checked = false;
                break;

                case CurrentGridType.Transactions:
                    dtpTaskUntil.ShowCheckBox = true;
                    dtpTaskFrom.ShowCheckBox = true;

                    dtpTaskFrom.Checked = false;
                    dtpTaskUntil.Checked = false;
                    break;
            } 
        }

        private void chkAppNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAppNo.Checked)
            {
                chkAppYes.Checked = false;

                chkProfessional.Enabled = false;
                chkClient.Enabled = false;
                chklProfessions.Enabled = false;

                chkProfessional.Checked = false;
                chkClient.Checked = false;
                for (int i = 0; i < chklProfessions.Items.Count; i++)
                {
                    chklProfessions.SetItemChecked(i, false);
                }
            }
            else
            {
                chkProfessional.Enabled = true;
                chkClient.Enabled = true;
                chklProfessions.Enabled = true;
            }
        }

        private void chkClient_CheckedChanged(object sender, EventArgs e)
        {
            if (chkClient.Checked)
            {
                chkProfessional.Checked = false;
            
                chklProfessions.Enabled=false;
                for (int i = 0; i < chklProfessions.Items.Count; i++)
                {
                    chklProfessions.SetItemChecked(i, false);
                }
            }
            else chklProfessions.Enabled =true;
        }

        private void chkProfessional_CheckedChanged(object sender, EventArgs e)
        {
            if (chkProfessional.Checked) chkClient.Checked = false;
        }

        private void chkAppYes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAppYes.Checked) chkAppNo.Checked = false;
        }

        private void panelTransactionFilter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelUserFilter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chklProfessions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblCreationTo_Click(object sender, EventArgs e)
        {

        }

        private void chklAccountState_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
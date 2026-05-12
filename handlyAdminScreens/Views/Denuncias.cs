using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using handlyAdminScreens.Helpers;
using handlyAdminScreens.Models;
using handlyAdminScreens.Services;

namespace handlyAdminScreens.Views
{
    public partial class Denuncias : Form
    {
        private List<Report> _listaDenuncias;
        private ReportFilterOptions _currentFilter = null;
        private readonly ApiService _api = new ApiService();

        public Denuncias()
        {
            InitializeComponent();
        }

        private async void Denuncias_Load(object sender, EventArgs e)
        {
            // cargamos las denuncias desde la API
            try
            {
                var result = await _api.GetAllReportsAsync();
                if (result.Success)
                {
                    _listaDenuncias = result.Data ?? new List<Report>();
                }
                else
                {
                    _listaDenuncias = new List<Report>();
                    SafeData.ShowError("Error al cargar denuncias",
                        "No se pudieron cargar las denuncias: " + result.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                _listaDenuncias = new List<Report>();
                SafeData.ShowError("Error inesperado",
                    "No se pudieron cargar las denuncias.", ex);
            }

            if (_listaDenuncias == null) _listaDenuncias = new List<Report>();

            ApplyFilterAndSearch();
        }

        private void SetupGrid()
        {
            if (gridReports.Columns.Count == 0) return;

            // ocultamos IDs y campos "raw" que tienen versión legible aparte
            if (gridReports.Columns["StateId"] != null) gridReports.Columns["StateId"].Visible = false;
            if (gridReports.Columns["StateName"] != null) gridReports.Columns["StateName"].Visible = false;
            if (gridReports.Columns["ReporterName"] != null) gridReports.Columns["ReporterName"].Visible = false;
            if (gridReports.Columns["ReporterSurname"] != null) gridReports.Columns["ReporterSurname"].Visible = false;
            if (gridReports.Columns["ReporteeName"] != null) gridReports.Columns["ReporteeName"].Visible = false;
            if (gridReports.Columns["ReporteeSurname"] != null) gridReports.Columns["ReporteeSurname"].Visible = false;

            gridReports.Columns["Id"].HeaderText = "ID";
            gridReports.Columns["ReporterId"].HeaderText = "ID Denunciante";
            gridReports.Columns["ReporterFullName"].HeaderText = "Denunciante";
            gridReports.Columns["ReporteeId"].HeaderText = "ID Denunciado";
            gridReports.Columns["ReporteeFullName"].HeaderText = "Denunciado";
            gridReports.Columns["ReportOrigin"].HeaderText = "Origen";
            gridReports.Columns["Cause"].HeaderText = "Motivo";
            gridReports.Columns["StateDisplay"].HeaderText = "Estado";

            gridReports.Columns["Id"].DisplayIndex = 0;
            gridReports.Columns["ReporterId"].DisplayIndex = 1;
            gridReports.Columns["ReporterFullName"].DisplayIndex = 2;
            gridReports.Columns["ReporteeId"].DisplayIndex = 3;
            gridReports.Columns["ReporteeFullName"].DisplayIndex = 4;
            gridReports.Columns["ReportOrigin"].DisplayIndex = 5;
            gridReports.Columns["Cause"].DisplayIndex = 6;
            gridReports.Columns["StateDisplay"].DisplayIndex = 7;

            gridReports.Columns["Id"].Frozen = true;
        }

        private void ApplyFilterAndSearch()
        {
            var query = _listaDenuncias.AsQueryable();

            if (_currentFilter != null)
            {
                if (_currentFilter.StateNames != null && _currentFilter.StateNames.Any())
                {
                    query = query.Where(r =>
                        !string.IsNullOrEmpty(r.StateName) &&
                        _currentFilter.StateNames.Contains(r.StateName.ToLower()));
                }
            }

            string text = txtSearchReport.Text.FormatStrForSearch().Trim();

            if (!string.IsNullOrEmpty(text))
            {
                query = query.Where(r =>
                    r.Id.ToString().Contains(text) ||
                    (r.ReportOrigin != null && r.ReportOrigin.FormatStrForSearch().Contains(text)) ||
                    (r.Cause != null && r.Cause.FormatStrForSearch().Contains(text)) ||
                    (r.StateName != null && r.StateName.FormatStrForSearch().Contains(text)) ||
                    (r.ReporterName != null && r.ReporterName.FormatStrForSearch().Contains(text)) ||
                    (r.ReporterSurname != null && r.ReporterSurname.FormatStrForSearch().Contains(text)) ||
                    (r.ReporteeName != null && r.ReporteeName.FormatStrForSearch().Contains(text)) ||
                    (r.ReporteeSurname != null && r.ReporteeSurname.FormatStrForSearch().Contains(text)) ||
                    (r.ReporterId.HasValue && r.ReporterId.Value.ToString().Contains(text)) ||
                    (r.ReporteeId.HasValue && r.ReporteeId.Value.ToString().Contains(text)) ||
                    r.ReporterFullName.FormatStrForSearch().Contains(text) ||
                    r.ReporteeFullName.FormatStrForSearch().Contains(text)
                );
            }

            gridReports.DataSource = null;
            gridReports.DataSource = query.ToList();

            SetupGrid();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            using (var filterForm = new Filter(CurrentGridType.Reports))
            {
                if (filterForm.ShowDialog() == DialogResult.OK)
                {
                    _currentFilter = (ReportFilterOptions)filterForm.SelectedFilters;
                    ApplyFilterAndSearch();
                }
            }
        }

        private void txtSearchReport_TextChanged(object sender, EventArgs e)
        {
            ApplyFilterAndSearch();
        }

        private void btnDeleteFilter_Click(object sender, EventArgs e)
        {
            _currentFilter = null;
            txtSearchReport.Text = null;
            ApplyFilterAndSearch();
        }
    }
}

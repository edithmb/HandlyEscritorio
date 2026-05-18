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
        private List<Report> _reportsList;
        private ReportFilterOptions _currentFilter = null;
        private readonly ApiService _api = new ApiService();

        public Denuncias()
        {
            InitializeComponent();
        }

        private async void Denuncias_Load(object sender, EventArgs e)
        {
            await LoadReportsAsync(forceRefresh: false);
        }

        private async System.Threading.Tasks.Task LoadReportsAsync(bool forceRefresh)
        {
            if (!forceRefresh)
            {
                var cached = CacheService.Load<List<Report>>("reports.json");
                if (cached != null)
                {
                    _reportsList = cached;
                    ApplyFilterAndSearch();
                    return;
                }
            }

            try
            {
                var result = await _api.GetAllReportsAsync();
                if (result.Success)
                {
                    _reportsList = result.Data ?? new List<Report>();
                }
                else
                {
                    _reportsList = new List<Report>();
                    SafeData.ShowError("Error al cargar denuncias",
                        "No se pudieron cargar las denuncias: " + result.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                _reportsList = new List<Report>();
                SafeData.ShowError("Error inesperado",
                    "No se pudieron cargar las denuncias.", ex);
            }

            if (_reportsList == null) _reportsList = new List<Report>();

            CacheService.Save("reports.json", _reportsList);

            ApplyFilterAndSearch();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            btnRefresh.Text = "Actualizando...";
            try
            {
                await LoadReportsAsync(forceRefresh: true);
            }
            finally
            {
                btnRefresh.Enabled = true;
                btnRefresh.Text = "↺ Actualizar datos";
            }
        }

        private void SetupGrid()
        {
            if (gridReports.Columns.Count > 0)
            {
                gridReports.HideCol(
                    "ReporterId",
                    "ReporteeId",
                    "StateId",
                    "StateName",
                    "ReporterName",
                    "ReporterSurname",
                    "ReporteeName",
                    "ReporteeSurname",
                    "ReporterUserId",
                    "ReporteeUserId"
                );

                gridReports.ConfigureCol("Id", "ID", 0, true);
                gridReports.ConfigureCol("ReporterFullName", "Denunciante", 1);
                gridReports.ConfigureCol("ReporterFullName", "Denunciante", 1);
                gridReports.ConfigureCol("ReporteeFullName", "Denunciado", 2);
                gridReports.ConfigureCol("ReportOrigin", "Origen", 3);
                gridReports.ConfigureCol("Cause", "Motivo", 4);
                gridReports.ConfigureCol("StateDisplay", "Estado", 5);
            }
        }
    
        
        private void ApplyFilterAndSearch()
        {
            var query = _reportsList.AsQueryable();

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
            gridReports.ClearSelection();
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

        //TODO mirar com simplificar i treure crida API, dades venen de json
        private async void gridReports_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var colName = gridReports.Columns[e.ColumnIndex].DataPropertyName;
                var report = gridReports.Rows[e.RowIndex].DataBoundItem as Report;
                if (report == null) return;

                if (colName == "ReporterFullName" || colName == "ReporteeFullName")
                {
                    long? userId = colName == "ReporterFullName"
                        ? report.ReporterUserId
                        : report.ReporteeUserId;
                    if (userId.HasValue && userId.Value > 0)
                        await OpenUserReadOnlyAsync(userId.Value);
                    return;
                }

                using (var form = new SolveReport(report))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                        await LoadReportsAsync(forceRefresh: true);
                }
            }
        }

        //TOD treure crida api
        private async System.Threading.Tasks.Task OpenUserReadOnlyAsync(long userId)
        {
            // 1) primero intentamos el cache (users.json) - sin API call
            var cached = CacheService.Load<List<User>>("users.json");
            var user = cached?.FirstOrDefault(u => u.Id == userId);

            // 2) si no está en cache, fallback al API (sólo este caso pega al servidor)
            if (user == null)
            {
                var result = await _api.GetUserByIdAsync(userId);
                if (!result.Success || result.Data == null)
                {
                    SafeData.ShowError("Error", "No se pudieron cargar los datos del usuario: " + result.ErrorMessage);
                    return;
                }
                user = result.Data;
            }

            using (var form = new EditUser(user, readOnly: true))
                form.ShowDialog();
        }

        private async void btnResolve_Click(object sender, EventArgs e)
        {
            if (gridReports.SelectedRows.Count > 0)
            {
                var report = gridReports.SelectedRows[0].DataBoundItem as Report;
                
                if (report != null)
                {
                    using (var form = new SolveReport(report))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            await LoadReportsAsync(forceRefresh: true);
                        }
                    }
                }
            }
            else
            {
                SafeData.ShowInfo("Selecciona una denuncia",
                    "Tienes que seleccionar una fila para resolver la denuncia.");
            }
        }
    }
}

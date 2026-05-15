using handlyAdminScreens.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using handlyAdminScreens.Helpers;
using handlyAdminScreens.Services;

namespace handlyAdminScreens.Views
{
    public partial class Transacciones : Form
    {

        private List<Transaction> _listaTransaccionesDePrueba;
        private TransactionFilterOptions _currentFilter = null;
        private readonly ApiService _api = new ApiService();

        public Transacciones()
        {
            InitializeComponent();
        }

        private async void Transacciones_Load(object sender, EventArgs e)
        {
            await LoadTransactionsAsync(forceRefresh: false);
        }

        private async System.Threading.Tasks.Task LoadTransactionsAsync(bool forceRefresh)
        {
            if (!forceRefresh)
            {
                var cached = CacheService.Load<List<Transaction>>("transactions.json");
                if (cached != null)
                {
                    _listaTransaccionesDePrueba = cached;
                    ApplyFilterAndSearch();
                    return;
                }
            }

            try
            {
                var result = await _api.GetAllTransactionsAsync();
                if (result.Success)
                {
                    _listaTransaccionesDePrueba = result.Data ?? new List<Transaction>();
                }
                else
                {
                    _listaTransaccionesDePrueba = new List<Transaction>();
                    SafeData.ShowError("Error al cargar transacciones",
                        "No se pudieron cargar las transacciones: " + result.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                _listaTransaccionesDePrueba = new List<Transaction>();
                SafeData.ShowError("Error inesperado",
                    "No se pudieron cargar las transacciones.", ex);
            }

            if (_listaTransaccionesDePrueba == null) _listaTransaccionesDePrueba = new List<Transaction>();

            CacheService.Save("transactions.json", _listaTransaccionesDePrueba);

            ApplyFilterAndSearch();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            btnRefresh.Text = "Actualizando...";
            try
            {
                await LoadTransactionsAsync(forceRefresh: true);
            }
            finally
            {
                btnRefresh.Enabled = true;
                btnRefresh.Text = "↺ Actualizar datos";
            }
        }

        private void SetupGrid()
        {
            if (gridTransactions.Columns.Count > 0)
            {
                gridTransactions.AutoGenerateColumns = false;

                // 1. Hide unwanted columns (using your new helper!)
                gridTransactions.HideCol("Task", "Invoice");

                // 2. Configure columns (using your new helper!)
                gridTransactions.ConfigureCol("TaskID", "ID", 0, true);
                gridTransactions.ConfigureCol("TaskTitle", "Título", 1, true);
                gridTransactions.ConfigureCol("TaskState", "Estado tarea", 2);
                gridTransactions.ConfigureCol("TaskCreation", "F.Creación", 3);
                gridTransactions.ConfigureCol("ClientName", "Cliente", 4);
                gridTransactions.ConfigureCol("ProfesionalName", "Profesional", 5);
                gridTransactions.ConfigureCol("TotalPayment", "Importe", 6);
            }
        }

        private void ApplyFilterAndSearch()
        {
            var query = _listaTransaccionesDePrueba.AsQueryable();

            if (_currentFilter != null)
            {
                if (_currentFilter.TaskState != null && _currentFilter.TaskState.Any())
                {
                    query = query.Where(t => t.Task != null &&
                                             _currentFilter.TaskState.Contains(t.Task.TaskStateName.ToLower()));
                }

                if (_currentFilter.CreatedFromDate.HasValue)
                {
                    query = query.Where(t => t.Task != null &&
                                             t.Task.CreationDate >= _currentFilter.CreatedFromDate.Value);
                }

                if (_currentFilter.CreatedToDate.HasValue)
                {
                    DateTime until = _currentFilter.CreatedToDate.Value.Date.AddDays(1).AddTicks(-1);
                    query = query.Where(t => t.Task != null &&
                                             t.Task.CreationDate <= until);
                }

                if (_currentFilter.MinAmount.HasValue)
                {
                    query = query.Where(t => t.Invoice != null &&
                                             t.Invoice.TotalPayment >= _currentFilter.MinAmount.Value);
                }

                if (_currentFilter.MaxAmount.HasValue)
                {
                    query = query.Where(t => t.Invoice != null &&
                                             t.Invoice.TotalPayment <= _currentFilter.MaxAmount.Value);
                }
            }


            string text = txtSearchTransaction.Text.FormatStrForSearch().Trim();

            if (!string.IsNullOrEmpty(text))
            {
                query = query.Where(t =>
                    (t.Task != null && t.Task.Id.ToString().Contains(text)) ||
                    (t.Task != null && t.Task.Title != null && t.Task.Title.FormatStrForSearch().Contains(text)) ||
                    (t.Task != null && t.Task.Description != null && t.Task.Description.FormatStrForSearch().Contains(text)) ||
                    (t.Task != null && t.Task.TaskStateName != null && t.Task.TaskStateName.FormatStrForSearch().Contains(text)) ||

                    (t.Task != null && t.Task.Client != null && (
                        (t.Task.Client.Name != null && t.Task.Client.Name.FormatStrForSearch().Contains(text)) ||
                        (t.Task.Client.LastName != null && t.Task.Client.LastName.FormatStrForSearch().Contains(text)) ||
                        ((t.Task.Client.Name + " " + t.Task.Client.LastName).FormatStrForSearch().Contains(text))
                    )) ||

                        (t.Task != null && t.Task.Professional != null && (
                        (t.Task.Professional.Name != null && t.Task.Professional.Name.FormatStrForSearch().Contains(text)) ||
                        (t.Task.Professional.LastName != null && t.Task.Professional.LastName.FormatStrForSearch().Contains(text)) ||
                        ((t.Task.Professional.Name + " " + t.Task.Professional.LastName).FormatStrForSearch().Contains(text))
                    )) ||

                    (t.Invoice != null && t.Invoice.PaymentMethod != null && t.Invoice.PaymentMethod.FormatStrForSearch().Contains(text)) ||
                    (t.Invoice != null && t.Invoice.TotalPayment.ToString().Contains(text))
                );
            }

            gridTransactions.DataSource = null;
            gridTransactions.DataSource = query.ToList();

            SetupGrid();
            gridTransactions.ClearSelection();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            using (var filterForm = new Filter(CurrentGridType.Transactions))
            {
                if (filterForm.ShowDialog() == DialogResult.OK)
                {
                    _currentFilter = (TransactionFilterOptions)filterForm.SelectedFilters;

                    ApplyFilterAndSearch();
                }
            }
        }
        private void txtSearchTransaction_TextChanged(object sender, EventArgs e)
        {
            ApplyFilterAndSearch();
        }

        private void btnDeleteFilter_Click(object sender, EventArgs e)
        {
            _currentFilter = null;
            txtSearchTransaction.Text = null;
            ApplyFilterAndSearch();
        }

        private void gridTransactions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var colName = gridTransactions.Columns[e.ColumnIndex].DataPropertyName;
            if (colName != "ClientName" && colName != "ProfesionalName") return;

            var tx = (Transaction)gridTransactions.Rows[e.RowIndex].DataBoundItem;
            if (tx?.Task == null) return;

            long userId = colName == "ClientName"
                ? tx.Task.Client?.Id ?? 0
                : tx.Task.Professional?.Id ?? 0;

            if (userId > 0) _ = OpenUserReadOnlyAsync(userId);
        }

        private async System.Threading.Tasks.Task OpenUserReadOnlyAsync(long userId)
        {
            var result = await _api.GetUserByIdAsync(userId);
            if (!result.Success || result.Data == null)
            {
                SafeData.ShowError("Error", "No se pudieron cargar los datos del usuario: " + result.ErrorMessage);
                return;
            }
            using (var form = new EditUser(result.Data, readOnly: true))
                form.ShowDialog();
        }
    }
}

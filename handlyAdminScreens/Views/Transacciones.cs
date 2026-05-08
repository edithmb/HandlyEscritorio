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

namespace handlyAdminScreens.Views
{
    public partial class Transacciones : Form
    {

        private List<Transaction> _listaTransaccionesDePrueba;
        private TransactionFilterOptions _currentFilter = null;

        public Transacciones()
        {
            InitializeComponent();
        }

        private void Transacciones_Load(object sender, EventArgs e)
        {
            _listaTransaccionesDePrueba = CrearTransaccionesPrueba();
            gridTransactions.DataSource = _listaTransaccionesDePrueba;

            SetupGrid();
        }

        private void SetupGrid()
        {
            if (gridTransactions.Columns.Count == 0) return;

            gridTransactions.AutoGenerateColumns = false;

            gridTransactions.Columns["TaskID"].HeaderText = "ID Tarea";
            gridTransactions.Columns["TaskTitle"].HeaderText = "Título";
            gridTransactions.Columns["TaskState"].HeaderText = "Estado tarea";
            gridTransactions.Columns["TaskCreation"].HeaderText = "F.Creación";
            gridTransactions.Columns["ClientName"].HeaderText = "Cliente";
            gridTransactions.Columns["ProfesionalName"].HeaderText = "Profesional";
            gridTransactions.Columns["TotalPayment"].HeaderText = "Importe";

            gridTransactions.Columns["TaskID"].DisplayIndex = 0;
            gridTransactions.Columns["TaskTitle"].DisplayIndex = 1;
            gridTransactions.Columns["TaskState"].DisplayIndex = 2;
            gridTransactions.Columns["TaskCreation"].DisplayIndex = 3;
            gridTransactions.Columns["ClientName"].DisplayIndex = 4;
            gridTransactions.Columns["ProfesionalName"].DisplayIndex = 5;
            gridTransactions.Columns["TotalPayment"].DisplayIndex = 6;

            if (gridTransactions.Columns["Task"] != null) gridTransactions.Columns["Task"].Visible = false;
            if (gridTransactions.Columns["Invoice"] != null) gridTransactions.Columns["Invoice"].Visible = false;

            gridTransactions.Columns["TaskID"].Frozen = true;
            gridTransactions.Columns["TaskTitle"].Frozen = true;
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

        private List<Transaction> CrearTransaccionesPrueba()
        {
            _listaTransaccionesDePrueba = new List<Transaction>
            {
                 new Transaction
                 {
                     Task = new Transaction.TaskData
                     {
                         Id = 1001,
                         Title = "Reparación de tubería rota",
                         Description = "El cliente reportó una fuga masiva en el baño principal debajo del lavabo.",
                         TaskStateId = 5, // 5 = finalized
                         CreationDate = new DateTime(2026, 3, 28, 10, 30, 0),
                         Client = new Transaction.UserShortData
                         {
                             Id = 101,
                             Name = "Juan",
                             LastName = "Pérez"
                         },
                         Professional = new Transaction.UserShortData
                         {
                             Id = 102,
                             Name = "Laura",
                             LastName = "Gómez"
                         }
                     },
                     Invoice = new Transaction.InvoiceData
                     {
                         Id = 5001,
                         TotalPayment = 150.00,
                         PaymentMethod = "tarjeta",
                         PaymentDate = new DateTime(2026, 3, 29, 12, 00, 0),
                         ProfessionalRevenue = 135.00,
                         AppComission = 15.00
                     }
                 },
                 new Transaction
                 {
                     Task = new Transaction.TaskData
                     {
                         Id = 1002,
                         Title = "Instalación de 4 enchufes",
                         Description = "Poner 4 enchufes nuevos en el salón. Hay que hacer rozas.",
                         TaskStateId = 3, // 3 = in process
                         CreationDate = DateTime.Now.AddDays(-1),
                         Client = new Transaction.UserShortData
                         {
                             Id = 104,
                             Name = "María",
                             LastName = "López"
                         },
                         Professional = new Transaction.UserShortData
                         {
                             Id = 105,
                             Name = "Carlos",
                             LastName = "Ruiz"
                         }
                     },
                     Invoice = null // Al estar en proceso, la factura puede ser null
                 },
                 new Transaction
                 {
                     Task = new Transaction.TaskData
                     {
                         Id = 1003,
                         Title = "Montaje de armario IKEA",
                         Description = "Armario modelo PAX de 3 puertas. Urgente.",
                         TaskStateId = 6, // 6 = cancelled
                         CreationDate = new DateTime(2026, 4, 1, 9, 0, 0),
                         Client = new Transaction.UserShortData
                         {
                             Id = 106,
                             Name = "Ana",
                             LastName = "Martínez"
                         },
                         Professional = new Transaction.UserShortData
                         {
                             Id = 107,
                             Name = "David",
                             LastName = "Carpintero"
                         }
                     },
                     Invoice = new Transaction.InvoiceData
                     {
                         Id = 5003,
                         TotalPayment = 0.00,
                         PaymentMethod = "cancelado",
                         PaymentDate = new DateTime(2026, 4, 2, 10, 0, 0),
                         ProfessionalRevenue = 0.00,
                         AppComission = 0.00
                     }
                 },
                 new Transaction
                 {
                     Task = new Transaction.TaskData
                     {
                         Id = 1004,
                         Title = "Pintar piso completo (70m2)",
                         Description = "Piso vacío. Pintura plástica blanca mate en paredes y techos.",
                         TaskStateId = 2, // 2 = negotiating
                         CreationDate = DateTime.Now.AddHours(-3),
                         Client = new Transaction.UserShortData
                         {
                             Id = 108,
                             Name = "Pedro",
                             LastName = "Sánchez"
                         },
                         Professional = new Transaction.UserShortData
                         {
                             Id = 109,
                             Name = "Jorge",
                             LastName = "Díaz"
                         }
                     },
                     Invoice = null
                 }
             };
            return _listaTransaccionesDePrueba;
        }
    }
}

using handlyAdminScreens.Models;
using handlyAdminScreens.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using handlyAdminScreens.Helpers;
using handlyAdminScreens.Services;

namespace handlyAdminScreens.Views
{
    public partial class Usuarios : Form
    {

        private List<User> _usersList;
        private UserFilterOptions _currentFilter = null;
        private ApiService _apiService;

        public Usuarios()
        {
            InitializeComponent();
            _apiService = new ApiService();
        }

        private async void Usuarios_Load(object sender, EventArgs e)
        {
            await LoadUsersAsync(forceRefresh: false);
        }

        private async System.Threading.Tasks.Task LoadUsersAsync(bool forceRefresh)
        {
            if (!forceRefresh)
            {
                var cached = CacheService.Load<List<User>>("users.json");
                if (cached != null)
                {
                    _usersList = cached;
                    foreach (var u in _usersList)
                        u.IsAppUser = u.RoleId == 1 || u.RoleId == 2;
                    ApplyFilterAndSearch();
                    return;
                }
            }

            try
            {
                _usersList = await _apiService.GetAllUsersAsync();
            }
            catch (Exception ex)
            {
                _usersList = new List<User>();
                Helpers.SafeData.ShowError("Error al cargar usuarios",
                    "No se pudieron cargar los usuarios desde el servidor.", ex);
            }

            if (_usersList == null) _usersList = new List<User>();

            // IsAppUser no viene del API: lo derivamos del rol
            // rol_id 1 = cliente, 2 = profesional -> son usuarios de la app
            // rol_id 3 = admin, 4 = superadmin -> NO son usuarios de la app
            foreach (var u in _usersList)
            {
                u.IsAppUser = u.RoleId == 1 || u.RoleId == 2;
            }

            CacheService.Save("users.json", _usersList);

            ApplyFilterAndSearch();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            btnRefresh.Text = "Actualizando...";
            try
            {
                await LoadUsersAsync(forceRefresh: true);
            }
            finally
            {
                btnRefresh.Enabled = true;
                btnRefresh.Text = "↺ Actualizar datos";
            }
        }

        private void SetupGrid()
        {
            if (gridUsers.Columns.Count > 0)
            {

                gridUsers.HideCol("Id", "UserId", "RoleId", "StateId", "Profession", "Selfie", "DocumentFront", "DocumentBack");

                gridUsers.ConfigureCol("Name", "Nombre", 0);
                gridUsers.ConfigureCol("LastName", "Apellidos", 1, true);
                gridUsers.ConfigureCol("Email", "E-Mail", 2);
                gridUsers.ConfigureCol("RoleName", "Rol", 3);
                gridUsers.ConfigureCol("ProfessionSummary", "Profesión", 4);
                gridUsers.ConfigureCol("StateName", "Estado", 5);
                gridUsers.ConfigureCol("DNI", "DNI / NIE", 6);
                gridUsers.ConfigureCol("StreetNumber", "Dirección", 7);
                gridUsers.ConfigureCol("City", "Ciudad", 8);
                gridUsers.ConfigureCol("Postalcode", "C.P.", 9);
                gridUsers.ConfigureCol("Country", "País", 10);
                gridUsers.ConfigureCol("Birthdate", "F. Nacimiento", 11);
                gridUsers.ConfigureCol("MobileNumber", "Teléfono", 12);
                gridUsers.ConfigureCol("AccountCreation", "F. Registro", 13);
                gridUsers.ConfigureCol("LastConnection", "Últ. Conexión", 14);

                gridUsers.ConfigureCol("IsAppUser", "Usuario app", 15);
            }
        }
          
        private void ApplyFilterAndSearch()
        {
            var query = _usersList.AsQueryable();

            if (_currentFilter != null)
            {
                if (!string.IsNullOrEmpty(_currentFilter.RoleName))
                {
                    query = query.Where(u => u.RoleName.ToLower() == _currentFilter.RoleName.ToLower());
                }

                if (_currentFilter.IsAppUser.HasValue)
                {
                    bool isApp = _currentFilter.IsAppUser == 1;
                    query = query.Where(u => u.IsAppUser == isApp);
                }

                if (_currentFilter.Professions != null && _currentFilter.Professions.Count > 0)
                {
                    query = query.Where(u => u.Profession != null &&
                                            u.Profession.Any(p => _currentFilter.Professions.Contains(p)));
                }

                if (_currentFilter.StateName != null && _currentFilter.StateName.Any())
                {
                    query = query.Where(u => u.StateName != null &&
                                            _currentFilter.StateName.Contains(u.StateName.ToLower()));
                }

                if (_currentFilter.CreatedFromDate.HasValue)
                {
                    query = query.Where(u => u.AccountCreation >= _currentFilter.CreatedFromDate.Value);
                }

                if (_currentFilter.CreatedToDate.HasValue)
                {
                    DateTime until = _currentFilter.CreatedToDate.Value.Date.AddDays(1).AddTicks(-1);
                    query = query.Where(u => u.AccountCreation <= until);
                }

                if (_currentFilter.LastConnectionFromDate.HasValue)
                {
                    query = query.Where(u => u.LastConnection >= _currentFilter.LastConnectionFromDate.Value);
                }

                if (_currentFilter.LastConnectionToDate.HasValue)
                {
                    DateTime until = _currentFilter.LastConnectionToDate.Value.Date.AddDays(1).AddTicks(-1);
                    query = query.Where(u => u.LastConnection <= until);
                }
            }

            string text = txtSearchUsers.Text.FormatStrForSearch().Trim();

            if (!string.IsNullOrEmpty(text))
            {
                query = query.Where(u =>
                    (u.Name != null && u.Name.FormatStrForSearch().Contains(text)) ||
                    (u.LastName != null && u.LastName.FormatStrForSearch().Contains(text)) ||
                    (u.Profession != null && u.Profession.Any(p => p.FormatStrForSearch().Contains(text))) ||
                    (u.Email != null && u.Email.ToLower().Contains(text)) ||
                    (u.DNI != null && u.DNI.FormatStrForSearch().Contains(text)) ||
                    (u.RoleName != null && u.RoleName.FormatStrForSearch().Contains(text)) ||
                    (u.StateName != null && u.StateName.FormatStrForSearch().Contains(text)) ||
                    (u.StreetNumber != null && u.StreetNumber.FormatStrForSearch().Contains(text)) ||
                    (u.City != null && u.City.FormatStrForSearch().Contains(text)) ||
                    (u.Postalcode != null && u.Postalcode.FormatStrForSearch().Contains(text)) ||
                    (u.Country != null && u.Country.FormatStrForSearch().Contains(text)) ||
                    (u.MobileNumber != null && u.MobileNumber.ToLower().Contains(text)) ||
                    (u.Name + " " + u.LastName).FormatStrForSearch().Contains(text)
                );
            }

            gridUsers.DataSource = null;
            gridUsers.DataSource = query.ToList();

            SetupGrid();
            gridUsers.ClearSelection();
        }


        private void btnFilter_Click(object sender, EventArgs e)
        {
            using (var filterForm = new Filter(CurrentGridType.Users))
            {
                if (filterForm.ShowDialog() == DialogResult.OK)
                {
                    _currentFilter = (UserFilterOptions)filterForm.SelectedFilters;

                    ApplyFilterAndSearch();
                }
            }
        }

        private void btnDeleteFilter_Click(object sender, EventArgs e)
        {
            _currentFilter = null;

            txtSearchUsers.Text = null;

            ApplyFilterAndSearch();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (gridUsers.SelectedRows.Count > 0)
            {
                var selectedUser = (User)gridUsers.SelectedRows[0].DataBoundItem;

                using (var editForm = new EditUser(selectedUser))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        var updatedUser = editForm.EditedUser;
                        UpdateLocalList(updatedUser);
                        ApplyFilterAndSearch();
                        MessageBox.Show("Usuario actualizado correctamente");
                    }
                }
            }
        }

        private void UpdateLocalList(User updatedUser)
        {
            var index = _usersList.FindIndex(u => u.Id == updatedUser.Id);
            if (index != -1) _usersList[index] = updatedUser;
        }

        private void gridUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) btnEditUser_Click(null, null);
        }

        private void txtSearchUsers_TextChanged(object sender, EventArgs e)
        {
            ApplyFilterAndSearch();
        }

        private void lblBuscar_Click(object sender, EventArgs e)
        {

        }

        private void gridUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
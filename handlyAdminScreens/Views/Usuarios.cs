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

namespace handlyAdminScreens.Views
{
    public partial class Usuarios : Form
    {

        private List<UserGridItem> _listaUsuariosDePrueba;
        private UserFilterOptions _currentFilter = null;

        public Usuarios()
        {
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            _listaUsuariosDePrueba = CrearUsariosPrueba();
            gridUsers.DataSource = _listaUsuariosDePrueba;

            SetupGrid();
        }

        private void SetupGrid()
        {
            if (gridUsers.Columns.Count == 0) return;

            if (gridUsers.Columns["Id"] != null) gridUsers.Columns["Id"].Visible = false;
            if (gridUsers.Columns["UserId"] != null) gridUsers.Columns["UserId"].Visible = false;
            if (gridUsers.Columns["RoleId"] != null) gridUsers.Columns["RoleId"].Visible = false;
            if (gridUsers.Columns["StateId"] != null) gridUsers.Columns["StateId"].Visible = false;
            if (gridUsers.Columns["Profession"] != null) gridUsers.Columns["Profession"].Visible = false;

            gridUsers.Columns["Name"].HeaderText = "Nombre";
            gridUsers.Columns["LastName"].HeaderText = "Apellidos";
            gridUsers.Columns["Email"].HeaderText = "E-Mail";
            gridUsers.Columns["RoleName"].HeaderText = "Rol";
            gridUsers.Columns["ProfessionSummary"].HeaderText = "Profesión";
            gridUsers.Columns["StateName"].HeaderText = "Estado";
            gridUsers.Columns["DNI"].HeaderText = "DNI / NIE";
            gridUsers.Columns["StreetNumber"].HeaderText = "Dirección";
            gridUsers.Columns["City"].HeaderText = "Ciudad";
            gridUsers.Columns["Postalcode"].HeaderText = "C.P.";
            gridUsers.Columns["Country"].HeaderText = "País";
            gridUsers.Columns["Birthdate"].HeaderText = "F. Nacimiento";
            gridUsers.Columns["MobileNumber"].HeaderText = "Teléfono";
            gridUsers.Columns["AccountCreation"].HeaderText = "F. Registro";
            gridUsers.Columns["LastConnection"].HeaderText = "Últ. Conexión";

            gridUsers.Columns["Name"].DisplayIndex = 0;
            gridUsers.Columns["LastName"].DisplayIndex = 1;
            gridUsers.Columns["Email"].DisplayIndex = 2;
            gridUsers.Columns["RoleName"].DisplayIndex = 3;
            gridUsers.Columns["StateName"].DisplayIndex = 4;


            gridUsers.Columns["LastName"].Frozen = true;
        }
    


        // <>


        private void ApplyFilterAndSearch()
        {
            var query = _listaUsuariosDePrueba.AsQueryable();

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

            string text = txtSearchUsers.Text.ToLower().Trim();

            if (!string.IsNullOrEmpty(text))
            {
                query = query.Where(u =>
                    (u.Name != null && u.Name.ToLower().Contains(text)) ||
                    (u.LastName != null && u.LastName.ToLower().Contains(text)) ||
                    (u.Profession != null && u.Profession.Any(p => p.ToLower().Contains(text))) ||
                    (u.Email != null && u.Email.ToLower().Contains(text)) ||
                    (u.DNI != null && u.DNI.ToLower().Contains(text)) ||
                    (u.RoleName != null && u.RoleName.ToLower().Contains(text)) ||
                    (u.StateName != null && u.StateName.ToLower().Contains(text)) ||
                    (u.Name + " " + u.LastName).ToLower().Contains(text)
                );
            }

            gridUsers.DataSource = null;
            gridUsers.DataSource = query.ToList();

            SetupGrid();
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

        private void txtSearchUsers_TextChanged(object sender, EventArgs e)
        {
            ApplyFilterAndSearch();
        }

      

        private void gridUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblBuscar_Click(object sender, EventArgs e)
        {

        }

        private List<UserGridItem>  CrearUsariosPrueba()
        {
            _listaUsuariosDePrueba = new List<UserGridItem>
            {
                new UserGridItem
                {
                    Id = 1,
                    UserId = 101,
                    Name = "Juan",
                    LastName = "Pérez",
                    Email = "juan@ejemplo.com",
                    RoleId = 1, // 1 = Cliente
                    Profession = null,
                    StateId = 1, // 1 = Active
                    DNI = "12345678A",
                    StreetNumber = "Calle Mayor 1",
                    City = "Madrid",
                    Postalcode = "28001",
                    Country = "España",
                    Birthdate = new DateTime(1990, 5, 15),
                    MobileNumber = "600111222",
                    LastConnection = DateTime.Now.AddHours(-2),
                    AccountCreation = new DateTime(2025, 1, 10),
                    IsAppUser = true
                },

                new UserGridItem
                {
                    Id = 2,
                    UserId = 102,
                    Name = "Laura",
                    LastName = "Gómez",
                    Email = "laura.fontanera@ejemplo.com",
                    RoleId = 2, // 2 = Profesional
                    Profession = new List<string> { "Téc. Calderas" },
                    StateId = 2,
                    DNI = "87654321B",
                    StreetNumber = "Av. Diagonal 200",
                    City = "Barcelona",
                    Postalcode = "08001",
                    Country = "España",
                    Birthdate = new DateTime(1985, 8, 22),
                    MobileNumber = "600333444",
                    LastConnection = DateTime.Now.AddDays(-5),
                    AccountCreation = new DateTime(2025, 2, 15),
                    IsAppUser = true
                },

                new UserGridItem
                {
                    Id = 3,
                    UserId = 103,
                    Name = "Carlos",
                    LastName = "Admin",
                    Email = "carlos@handly.com",
                    RoleId = 3,
                    Profession = null,
                    StateId = 1,
                    DNI = "99999999Z",
                    StreetNumber = "Oficina Central",
                    City = "Madrid",
                    Postalcode = "28000",
                    Country = "España",
                    Birthdate = new DateTime(1980, 1, 1),
                    MobileNumber = "600999999",
                    LastConnection = DateTime.Now,
                    AccountCreation = new DateTime(2024, 1, 1),
                    IsAppUser = false
                }

            };

            return _listaUsuariosDePrueba;
        }

        private void btnDeleteFilter_Click(object sender, EventArgs e)
        {
            _currentFilter = null;

            txtSearchUsers.Text = null;

            ApplyFilterAndSearch();
        }

        // <>

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (gridUsers.Rows.Count > 0)
            {
                var selectedUser = (UserGridItem)gridUsers.SelectedRows[0].DataBoundItem;

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

        private void UpdateLocalList(UserGirdItem updatedUser)
        {

        }
    }
}
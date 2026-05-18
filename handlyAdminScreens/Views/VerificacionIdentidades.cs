using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using handlyAdminScreens.Helpers;
using handlyAdminScreens.Services;
using handlyAdminScreens.Views; 

namespace handlyAdminScreens.Views
{
    public partial class VerificacionIdentidades : Form
    {
        // estado "in revision" -> son los que aparecen en este tab
        private const int STATE_IN_REVISION = 4;

        // todos los usuarios devueltos por la API
        private List<User> _allUsers = new List<User>();
        // sólo los que tienen account_state_id == 4
        private List<User> _pendingUsers = new List<User>();

        private readonly ApiService _api = new ApiService();

        public VerificacionIdentidades()
        {
            InitializeComponent();
        }

        private async void VerificacionIdentidades_Load(object sender, EventArgs e)
        {
            await LoadUsersAsync(forceRefresh: false);
        }

        private async System.Threading.Tasks.Task LoadUsersAsync(bool forceRefresh)
        {
            // si hay caché y no nos piden forzar, usamos lo que ya teníamos
            if (!forceRefresh)
            {
                var cached = CacheService.Load<List<User>>("users_verification.json");
                if (cached != null)
                {
                    _allUsers = cached;
                    FilterPending();
                    ApplySearch();
                    return;
                }
            }

            try
            {
                _allUsers = await _api.GetAllUsersAsync();
            }
            catch (Exception ex)
            {
                _allUsers = new List<User>();
                SafeData.ShowError("Error al cargar usuarios",
                    "No se pudieron cargar los usuarios desde el servidor.", ex);
            }

            if (_allUsers == null) _allUsers = new List<User>();

            CacheService.Save("users_verification.json", _allUsers);

            FilterPending();
            ApplySearch();
        }

        // filtramos a los usuarios que están "in revision" (account_state_id = 4)
        private void FilterPending()
        {
            _pendingUsers = _allUsers
                .Where(u => u.StateId.HasValue && u.StateId.Value == STATE_IN_REVISION)
                .ToList();
        }

        private void ApplySearch()
        {
            var query = _pendingUsers.AsQueryable();

            string text = txtSearch.Text.FormatStrForSearch().Trim();
            if (!string.IsNullOrEmpty(text))
            {
                query = query.Where(u =>
                    (u.Name != null && u.Name.FormatStrForSearch().Contains(text)) ||
                    (u.LastName != null && u.LastName.FormatStrForSearch().Contains(text)) ||
                    (u.Email != null && u.Email.ToLower().Contains(text)) ||
                    (u.DNI != null && u.DNI.FormatStrForSearch().Contains(text)) ||
                    (u.RoleName != null && u.RoleName.FormatStrForSearch().Contains(text)) ||
                    (u.Profession != null && u.Profession.Any(p => p.FormatStrForSearch().Contains(text))) ||
                    (u.Name + " " + u.LastName).FormatStrForSearch().Contains(text));
            }

            gridVerify.DataSource = null;
            gridVerify.DataSource = query.ToList();

            SetupGrid();
        }

        private void SetupGrid()
        {
            if (gridVerify.Columns.Count == 0) return;

            gridVerify.HideCol(
                "Id",
                "UserId",
                "RoleId",
                "StateId",
                "StateName",
                "Profession",
                "DNI",
                "StreetNumber",
                "City",
                "Postalcode",
                "Country",
                "Birthdate",
                "MobileNumber",
                "Email",
                "LastConnection",
                "AccountCreation",
                "IsAppUser",
                "Selfie",
                "DocumentFront",
                "DocumentBack"
            );

            gridVerify.ConfigureCol("Name", "Nombre", 0);
            gridVerify.ConfigureCol("LastName", "Apellidos", 1);
            gridVerify.ConfigureCol("RoleName", "Rol", 2);
            gridVerify.ConfigureCol("ProfessionSummary", "Profesión", 3);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplySearch();
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

        private void btnViewImages_Click(object sender, EventArgs e)
        {
            OpenImagesForSelected();
        }

        //TODO agafar dades de api
        private async void gridVerify_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var colName = gridVerify.Columns[e.ColumnIndex].DataPropertyName;
                var user = gridVerify.Rows[e.RowIndex].DataBoundItem as User;
                if (user == null) return;

                if (colName == "Name" || colName == "LastName")
                {
                    using (var form = new EditUser(user, readOnly: true))
                        form.ShowDialog();
                    return;
                }

                OpenImagesForSelected();
            }
        }
        private async void OpenImagesForSelected()
        {
            if (gridVerify.SelectedRows.Count == 0)
            {
                SafeData.ShowInfo("Selecciona un usuario",
                    "Selecciona una fila para ver las imágenes de verificación.");
                return;
            }

            var user = gridVerify.SelectedRows[0].DataBoundItem as User;
            if (user == null) return;

            using (var form = new VerifyImages(user))
            {
                // si el admin aprobó/denegó al usuario, recargamos desde la API
                // para que esa fila desaparezca del grid (ya no estará en estado 4)
                if (form.ShowDialog() == DialogResult.OK)
                {
                    await LoadUsersAsync(forceRefresh: true);
                }
            }
        }

        private void gridVerify_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

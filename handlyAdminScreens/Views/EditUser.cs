using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using handlyAdminScreens.Helpers;
using handlyAdminScreens.Models;
using handlyAdminScreens.Services;

namespace handlyAdminScreens.Views
{
    public partial class EditUser : Form
    {
        public User EditedUser { get; private set; }

        private readonly ApiService _api = new ApiService();

        public EditUser(User originalUser)
        {
            InitializeComponent();

            // si nos pasan un usuario null, montamos uno vacío para que no reviente nada
            if (originalUser == null) originalUser = new User();

            // copia defensiva del usuario - todos los campos string usan SafeData
            EditedUser = new User
            {
                Id = originalUser.Id,
                UserId = originalUser.Id,
                Name = SafeData.Text(originalUser.Name),
                LastName = SafeData.Text(originalUser.LastName),
                Email = SafeData.Text(originalUser.Email),
                RoleId = originalUser.RoleId,
                Profession = SafeData.List(originalUser.Profession),
                StateId = originalUser.StateId,
                DNI = SafeData.Text(originalUser.DNI),
                StreetNumber = SafeData.Text(originalUser.StreetNumber),
                City = SafeData.Text(originalUser.City),
                Postalcode = SafeData.Text(originalUser.Postalcode),
                Country = SafeData.Text(originalUser.Country),
                Birthdate = originalUser.Birthdate,
                MobileNumber = SafeData.Text(originalUser.MobileNumber),
                LastConnection = originalUser.LastConnection,
                AccountCreation = originalUser.AccountCreation
            };

            try
            {
                SetupComboBoxes();
                SetupProfessions();
                LoadData();
            }
            catch (Exception ex)
            {
                // no queremos que el form reviente al abrirse
                SafeData.ShowError("Error al cargar usuario",
                    "No se pudieron cargar todos los datos del usuario. Faltan campos en la API.",
                    ex);
            }
        }

        private void SetupComboBoxes()
        {
            cmbRole.Items.Clear();
            cmbRole.Items.Add("Cliente");
            cmbRole.Items.Add("Profesional");
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Superadmin");
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbAccountState.Items.Clear();
            cmbAccountState.Items.Add("Active");
            cmbAccountState.Items.Add("Banned");
            cmbAccountState.Items.Add("Pending aprobation");
            cmbAccountState.Items.Add("In revision");
            cmbAccountState.Items.Add("Inactive");
            cmbAccountState.Items.Add("Deleted");
            cmbAccountState.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void SetupProfessions()
        {
            chklProfessions.Items.Clear();
            string[] options =
            {
                "Albañil", "Carpintero", "Cerrajero" , "Cristalero", "Electricista", "Fontanero", "Fumigador",
                "Jardinero", "Limpieza Hogar", "Manitas (Handyman)", "Mudanzas y Portes" , "Parquetista", "Pintor", "Tapicero",
                "Téc. Calderas", "Téc. Electrodomésticos"
            };

            chklProfessions.Items.AddRange(options);
        }

        private void LoadData()
        {
            LoadProfessionsInUI();

            txtName.Text = EditedUser.Name;
            txtLastName.Text = EditedUser.LastName;
            txtEmail.Text = EditedUser.Email;
            txtPhone.Text = EditedUser.MobileNumber;
            txtDNI.Text = EditedUser.DNI;
            txtStreet.Text = EditedUser.StreetNumber;
            txtCity.Text = EditedUser.City;
            txtPostalCode.Text = EditedUser.Postalcode;
            txtCountry.Text = EditedUser.Country;

            // DateTimePicker no acepta DateTime.MinValue ni fechas < 1753 -> usamos helper
            SafeData.SetDate(dtBirthdate, EditedUser.Birthdate);

            // SelectedIndex seguro: si el rol/estado vienen vacíos, no peta
            SafeData.SelectIndex(cmbRole, EditedUser.RoleId - 1);
            // StateId es int? (null para admin/superadmin) -> usamos GetValueOrDefault
            SafeData.SelectIndex(cmbAccountState, EditedUser.StateId.GetValueOrDefault() - 1);
        }

        private void LoadProfessionsInUI()
        {
            // EditedUser.Profession ya está garantizado no-null por SafeData.List
            for (int i = 0; i < chklProfessions.Items.Count; i++)
            {
                string professionName = chklProfessions.Items[i].ToString();
                chklProfessions.SetItemChecked(i, EditedUser.Profession.Contains(professionName));
            }
        }

        private void EditUser_Load(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void groupBox7_Enter(object sender, EventArgs e) { }
        private void txtName_TextChanged(object sender, EventArgs e) { }
        private void txtLastName_TextChanged(object sender, EventArgs e) { }
        private void chklProfessions_SelectedIndexChanged(object sender, EventArgs e) { }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            // sólo profesionales tienen oficios
            chklProfessions.Enabled = (cmbRole.SelectedIndex == 1);
        }

        // valida que el formulario tiene los campos mínimos antes de mandar al API
        private bool ValidateInputs(out string errorMessage)
        {
            errorMessage = null;

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorMessage = "El nombre es obligatorio.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                errorMessage = "El apellido es obligatorio.";
                return false;
            }

            // email simple: si está, que tenga @
            string email = txtEmail.Text.Trim();
            if (!string.IsNullOrEmpty(email) && !email.Contains("@"))
            {
                errorMessage = "El email no es válido.";
                return false;
            }

            return true;
        }

        private async void btnAccept_Click(object sender, EventArgs e)
        {
            // 1. validar antes de tocar nada
            if (!ValidateInputs(out string error))
            {
                SafeData.ShowError("Datos no válidos", error);
                return;
            }

            // 2. recoger los valores actuales del formulario
            EditedUser.Name = txtName.Text.Trim();
            EditedUser.LastName = txtLastName.Text.Trim();
            EditedUser.Email = txtEmail.Text.Trim();
            EditedUser.MobileNumber = txtPhone.Text.Trim();
            EditedUser.DNI = txtDNI.Text.Trim();
            EditedUser.StreetNumber = txtStreet.Text.Trim();
            EditedUser.Postalcode = txtPostalCode.Text.Trim();
            EditedUser.City = txtCity.Text.Trim();
            EditedUser.Country = txtCountry.Text.Trim();
            EditedUser.Birthdate = dtBirthdate.Value;
            if (cmbRole.SelectedIndex >= 0) EditedUser.RoleId = cmbRole.SelectedIndex + 1;
            if (cmbAccountState.SelectedIndex >= 0) EditedUser.StateId = cmbAccountState.SelectedIndex + 1;

            // profesiones (sólo si es profesional)
            EditedUser.Profession = new List<string>();
            if (cmbRole.SelectedIndex == 1)
            {
                foreach (var i in chklProfessions.CheckedItems)
                {
                    EditedUser.Profession.Add(i.ToString());
                }
            }

            // 3. mandar al API (un sólo PUT /users/{id} con todo el usuario)
            SetBusy(true);
            try
            {
                var updateResult = await _api.UpdateUserAsync(EditedUser);
                if (!updateResult.Success)
                {
                    SafeData.ShowError("No se pudo guardar",
                        "Error al actualizar datos: " + updateResult.ErrorMessage);
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                SafeData.ShowError("Error inesperado",
                    "No se pudo guardar el usuario.", ex);
            }
            finally
            {
                SetBusy(false);
            }
        }

        private void SetBusy(bool busy)
        {
            btnAccept.Enabled = !busy;
            btnCancel.Enabled = !busy;
            this.Cursor = busy ? Cursors.WaitCursor : Cursors.Default;
        }
    }
}

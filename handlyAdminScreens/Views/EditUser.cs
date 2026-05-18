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
        private readonly bool _readOnly;

        //TODO mirar exactament com funciona linia 26 i 28

        // Constructor normal (edición)
        public EditUser(User originalUser) : this(originalUser, readOnly: false) { }

        // Constructor de solo lectura — usado desde Transacciones y Denuncias
        public EditUser(User originalUser, bool readOnly)
        {
            InitializeComponent();
            _readOnly = readOnly;

            //TODO mirar si aixo te sentit
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
                SafeData.ShowError("Error al cargar usuario",
                    "No se pudieron cargar todos los datos del usuario. Faltan campos en la API.",
                    ex);
            }
        }

        private void SetupComboBoxes()
        {
            cmbRole.Items.Clear();
            foreach (var r in Catalogs.Current.Roles)
                cmbRole.Items.Add(r);                  // CatalogItem.ToString() devuelve Name
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbAccountState.Items.Clear();
            foreach (var s in Catalogs.Current.AccountStates)
                cmbAccountState.Items.Add(s);
            cmbAccountState.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // selecciona el item del ComboBox cuyo CatalogItem.Id coincide con targetId
       
        private static void SelectByCatalogId(ComboBox cmb, int? targetId)
        {
            if (cmb != null)
            {
                int targetIndex = -1;

                if (targetId.HasValue)
                {
                    // The loop automatically stops running as soon as targetIndex changes from -1
                    for (int i = 0; i < cmb.Items.Count && targetIndex == -1; i++)
                    {
                        var ci = cmb.Items[i] as CatalogItem;

                        if (ci != null && ci.Id == targetId.Value)
                        {
                            targetIndex = i;
                        }
                    }
                }

                cmb.SelectedIndex = targetIndex;
            }
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

            // seleccionamos por ID del catálogo (no asumimos que el orden coincide con el ID)
            SelectByCatalogId(cmbRole, EditedUser.RoleId);
            SelectByCatalogId(cmbAccountState, EditedUser.StateId);

            if (_readOnly) ApplyReadOnly();
        }

        //TODO versio simplificada potser no funciona xd
        /*
         private void ApplyReadOnly()
        {
            // 1. Clean up the TextBoxes using the single-line Array trick
            Array.ForEach(new[] { txtName, txtLastName, txtEmail, txtPhone, txtDNI }, tb => {
                tb.Enabled = false;
                tb.BackColor = System.Drawing.SystemColors.Window;
                tb.ForeColor = System.Drawing.Color.Black;
                tb.TabStop = false;
            });

            // 2. Hide original controls and replace them with text smoothly
            string birthText = (EditedUser.Birthdate.HasValue && EditedUser.Birthdate.Value.Year > 1900)
                ? EditedUser.Birthdate.Value.ToString("dd/MM/yyyy")
                : "—";
            string roleText = cmbRole.SelectedIndex >= 0 ? cmbRole.Items[cmbRole.SelectedIndex].ToString() : "—";
            string stateText = cmbAccountState.SelectedIndex >= 0 ? cmbAccountState.Items[cmbAccountState.SelectedIndex].ToString() : "—";
            string profsText = (EditedUser.Profession != null && EditedUser.Profession.Count > 0)
                ? string.Join(Environment.NewLine, EditedUser.Profession)
                : "—";

            ReplaceWithLabel(dtBirthdate, birthText);
            ReplaceWithLabel(cmbRole, roleText);
            ReplaceWithLabel(cmbAccountState, stateText);
            ReplaceWithLabel(chklProfessions, profsText, gbProfession); // Injects into the GroupBox


            groupBox5.Visible = false;
            btnAccept.Visible = false;
            btnCancel.Text = "Cerrar";
        }


        private static void ReplaceWithLabel(Control originalControl, string text, Control customParent = null)
        {
            originalControl.Visible = false;

            var lbl = new Label
            {
                AutoSize = false,
                Location = originalControl.Location,
                Size = originalControl.Size,
                ForeColor = System.Drawing.Color.Black,
                TextAlign = originalControl is CheckedListBox ? System.Drawing.ContentAlignment.TopLeft : System.Drawing.ContentAlignment.MiddleLeft,
                Text = text
            };

            // If a specific parent (like a GroupBox) is provided, use it. Otherwise, use the control's natural parent.
            Control parent = customParent ?? originalControl.Parent;
    
            parent.Controls.Add(lbl);
            lbl.BringToFront();
        }
        
         */
        private void ApplyReadOnly()
        {
            foreach (var tb in new[] { txtName, txtLastName, txtEmail, txtPhone, txtDNI })
            {
                tb.ReadOnly = true;
                tb.BackColor = System.Drawing.SystemColors.Window;
                tb.ForeColor = System.Drawing.Color.Black;
                tb.TabStop = false;
            }

            dtBirthdate.Visible = false;
            var lblBirth = new Label
            {
                AutoSize = false,
                Location = dtBirthdate.Location,
                Size = dtBirthdate.Size,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                ForeColor = System.Drawing.Color.Black,
                Text = (EditedUser.Birthdate.HasValue && EditedUser.Birthdate.Value.Year > 1900)
                    ? EditedUser.Birthdate.Value.ToString("dd/MM/yyyy")
                    : "—"
            };
            dtBirthdate.Parent.Controls.Add(lblBirth);
            lblBirth.BringToFront();

            cmbRole.Visible = false;
            var lblRole = new Label
            {
                AutoSize = false,
                Location = cmbRole.Location,
                Size = cmbRole.Size,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                ForeColor = System.Drawing.Color.Black,
                Text = cmbRole.SelectedIndex >= 0 ? cmbRole.Items[cmbRole.SelectedIndex].ToString() : "—"
            };
            cmbRole.Parent.Controls.Add(lblRole);
            lblRole.BringToFront();

            cmbAccountState.Visible = false;
            var lblState = new Label
            {
                AutoSize = false,
                Location = cmbAccountState.Location,
                Size = cmbAccountState.Size,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                ForeColor = System.Drawing.Color.Black,
                Text = cmbAccountState.SelectedIndex >= 0 ? cmbAccountState.Items[cmbAccountState.SelectedIndex].ToString() : "—"
            };
            cmbAccountState.Parent.Controls.Add(lblState);
            lblState.BringToFront();

            //TODO fix
            chklProfessions.Visible = false;
            var lblProfs = new Label
            {
                AutoSize = false,
                Location = chklProfessions.Location,
                Size = chklProfessions.Size,
                TextAlign = System.Drawing.ContentAlignment.TopLeft,
                Text = EditedUser.Profession != null && EditedUser.Profession.Count > 0
                    ? string.Join(Environment.NewLine, EditedUser.Profession)
                    : "—"
            };
            gbProfession.Controls.Add(lblProfs);


            groupBox5.Visible = false;
            btnAccept.Visible = false;
            btnCancel.Text = "Cerrar";
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
            // sólo profesionales (rol_id == 2) tienen oficios
            var selected = cmbRole.SelectedItem as CatalogItem;
            chklProfessions.Enabled = (selected != null && selected.Id == 2);
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
            // leemos el ID del CatalogItem seleccionado (no asumimos orden secuencial)
            var rSel = cmbRole.SelectedItem as CatalogItem;
            if (rSel != null) EditedUser.RoleId = rSel.Id;
            var sSel = cmbAccountState.SelectedItem as CatalogItem;
            if (sSel != null) EditedUser.StateId = sSel.Id;

            // profesiones (sólo si es profesional, rol_id 2)
            EditedUser.Profession = new List<string>();
            if (EditedUser.RoleId == 2)
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

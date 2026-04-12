using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using handlyAdminScreens.Models;

namespace handlyAdminScreens.Views
{
    public partial class EditUser : Form
    {
        public User EditedUser {  get; private set; }

        public EditUser(User originalUser)
        {
            InitializeComponent();

            EditedUser = new User
            {
                Id = originalUser.Id,
                UserId = originalUser.Id,
                Name = originalUser.Name,
                LastName = originalUser.LastName,
                Email = originalUser.Email,
                RoleId = originalUser.RoleId,
                Profession = originalUser.Profession != null ? new List<string>(originalUser.Profession) : new List<string>(),
                StateId = originalUser.StateId,
                DNI = originalUser.DNI,
                StreetNumber = originalUser.StreetNumber,
                City = originalUser.City,   
                Postalcode = originalUser.Postalcode,
                Country = originalUser.Country,
                Birthdate = originalUser.Birthdate,
                MobileNumber = originalUser.MobileNumber,
                LastConnection = originalUser.LastConnection,
                AccountCreation = originalUser.AccountCreation
            };

            SetupComboBoxes();
            SetupProfessions();
            LoadData();
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

        // <>
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
            dtBirthdate.Value = EditedUser.Birthdate;

            if (EditedUser.RoleId > 0) cmbRole.SelectedIndex = EditedUser.RoleId - 1;
            if (EditedUser.StateId > 0) cmbAccountState.SelectedIndex = EditedUser.StateId - 1;
        }

        private void LoadProfessionsInUI()
        {
            for (int i = 0; i< chklProfessions.Items.Count; i++)
            {
                string professionName = chklProfessions.Items[i].ToString();

                if (EditedUser.Profession.Contains(professionName)) chklProfessions.SetItemChecked(i, true);
                else chklProfessions.SetItemChecked (i, false);
            }
        }

        private void EditUser_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void chklProfessions_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRole.SelectedIndex == 1) chklProfessions.Enabled = true;
            else chklProfessions.Enabled = false;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
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
            EditedUser.RoleId = cmbRole.SelectedIndex + 1;
            EditedUser.StateId = cmbRole.SelectedIndex + 1;

            if (cmbRole.SelectedIndex != 1) EditedUser.Profession = null;

            foreach (var i in chklProfessions.CheckedItems) {
                EditedUser.Profession.Add(i.ToString());
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

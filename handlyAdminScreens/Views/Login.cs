using System;
using System.Windows.Forms;
using handlyAdminScreens.Services;

namespace handlyAdminScreens.Views
{
    public partial class Login : Form
    {
        private readonly ApiService _api = new ApiService();

        // bandera para saber si el login fue OK (Program.cs la consulta)
        public bool LoginSuccess { get; private set; } = false;

        public Login()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            // limpiamos error anterior y validamos campos vacíos
            lblError.Text = "";

            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                lblError.Text = "Rellena email y contraseña.";
                return;
            }

            SetBusy(true);
            try
            {
                var result = await _api.LoginAsync(email, password);

                if (result.Success)
                {
                    LoginSuccess = true;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    lblError.Text = result.ErrorMessage;
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            finally
            {
                SetBusy(false);
            }
        }

        private void SetBusy(bool busy)
        {
            btnLogin.Enabled = !busy;
            txtEmail.Enabled = !busy;
            txtPassword.Enabled = !busy;
            this.Cursor = busy ? Cursors.WaitCursor : Cursors.Default;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}

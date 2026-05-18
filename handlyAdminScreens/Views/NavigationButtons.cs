using handlyAdminScreens.Helpers;
using handlyAdminScreens.Services;
using handlyAdminScreens.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace handlyAdminScreens
{
    public partial class NavigationButtons : Form
    {
        private Form activeForm = null;
        private readonly ApiService _api = new ApiService();

        // Lo lee Program.Main al cerrarse este form:
        //   true  -> el admin pulsó "Cerrar sesión" -> volver al login
        //   false -> el admin cerró la ventana (X) -> salir de la app
        public bool LoggedOut { get; private set; } = false;

        public NavigationButtons()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OpenChildForm(new Inicio());
        }

        public void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelMain.Visible = true;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Inicio());
        }

        private void btnIdentidad_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new VerificacionIdentidades());
        }

        private void btnDenuncias_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Denuncias());
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Usuarios());
        }

        private void btnTransacciones_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Transacciones());
        }

        // pide confirmación; si OK invalida el token en el servidor,
        // borra los caches de datos y cierra la ventana principal.
        // Program.Main vuelve a mostrar el login al detectar LoggedOut = true.
        private async void btnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "¿Seguro que quieres cerrar sesión?",
                "Cerrar sesión",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.OK) return;

            btnLogout.Enabled = false;
            try
            {
                // invalidamos el token en el servidor y lo limpiamos en memoria
                await _api.LogoutAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Logout error: " + ex.Message);
            }

            // borramos todos los caches de datos para que el siguiente login
            // empiece limpio (sin información del admin anterior)
            CacheService.ClearDataCaches();
            Catalogs.Clear();

            LoggedOut = true;
            this.Close();
        }

     
    }
}

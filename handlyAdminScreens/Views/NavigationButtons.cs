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
    }
}

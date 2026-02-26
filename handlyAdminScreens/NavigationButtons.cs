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

        private void OpenChildForm(Form childForm)
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
        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DenunciasPorRevisar());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DenunciasResueltas());
        }

        private void btnIdentidadRevisar_Click(object sender, EventArgs e)
        {
            OpenChildForm(new IdentiadesPorRevisar());
        }
       
        private void btnIdentidadesResueltas_Click(object sender, EventArgs e)
        {
            OpenChildForm(new IdentidadesResultas());
        }

        private void btnCuentasPorRevisar_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CuentasPorRevisar());

        }
        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CuentasInactivas());
        }

        private void btnCuentasActivas_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CuentasActivas());
        }

        private void btnIdentidad_Click_1(object sender, EventArgs e)
        {
            panelIdentidad.Visible=!panelIdentidad.Visible;

            panelDenuncias.Visible = false;
            panelCuentas.Visible = false;
        }

        private void btnDenuncias_Click(object sender, EventArgs e)
        {
            panelDenuncias.Visible=!panelDenuncias.Visible;

            panelCuentas.Visible = false;
            panelIdentidad.Visible = false;
        }

        private void btnCuentas_Click(object sender, EventArgs e)
        {
            panelCuentas.Visible=!panelCuentas.Visible;

            panelIdentidad.Visible = false;
            panelDenuncias.Visible=false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (panelCuentas.Visible)
            {
                panelCuentas.Visible = false;
            }
            else
            {
                panelCuentas.Visible = true;
            }
        }

        private void panelDenuncias_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelIdentidad_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelCuentas_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

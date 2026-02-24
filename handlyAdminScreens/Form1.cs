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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panelDenuncias_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelIdentidad_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panelCuentas.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btnCuentasActivas_Click(object sender, EventArgs e)
        {

        }

        private void panelCuentas_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnIdentidad_Click_1(object sender, EventArgs e)
        {
            if (panelIdentidad.Visible == true)
            {
                panelIdentidad.Visible = false;
            }
            else
            {
                panelIdentidad.Visible = true;
            }
        }

        private void btnDenuncias_Click(object sender, EventArgs e)
        {
            if (panelDenuncias.Visible == true)
            {
                panelDenuncias.Visible = false;
            }
            else
            {
                panelDenuncias.Visible = true;
            }
           
        }

        private void btnCuentas_Click(object sender, EventArgs e)
        {
            if (panelCuentas.Visible == true)
            {
                panelCuentas.Visible = false;
            }
            else
            {
                panelCuentas.Visible = true;
            }
        }
    }
}

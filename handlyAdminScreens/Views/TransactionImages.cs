using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using handlyAdminScreens.Helpers;
using handlyAdminScreens.Models;

namespace handlyAdminScreens.Views
{
    // Visor de las fotos asociadas a una tarea (photo_1, photo_2 en Tasks).
    // Las fotos llegan ya en base64 desde el API (bytea -> base64).
    public partial class TransactionImages : Form
    {
        private readonly Transaction _tx;

        public TransactionImages(Transaction tx)
        {
            InitializeComponent();
            _tx = tx;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (_tx?.Task != null)
            {
                this.Text = "Imágenes - Tarea #" + _tx.Task.Id;
                lblTitle.Text = "Imágenes de la tarea #" + _tx.Task.Id +
                    (string.IsNullOrEmpty(_tx.Task.Title) ? "" : "  -  " + _tx.Task.Title);

                LoadImage(pbPhoto1, lblPhoto1Empty, _tx.Task.Photo1, "photo_1");
                LoadImage(pbPhoto2, lblPhoto2Empty, _tx.Task.Photo2, "photo_2");
            }
            else
            {
                ShowMessage(pbPhoto1, lblPhoto1Empty, "(transacción sin tarea)");
                ShowMessage(pbPhoto2, lblPhoto2Empty, "(transacción sin tarea)");
            }
        }

        // misma lógica que VerifyImages.LoadImage: tolera prefijo data URI,
        // quita whitespace y diferencia distintos modos de fallo
        private void LoadImage(PictureBox box, Label emptyLabel, string base64, string fieldName)
        {
            if (box == null) return;
            box.Image = null;

            if (base64 == null)
            {
                ShowMessage(box, emptyLabel, "(no hay imagen)");
                return;
            }
            if (base64.Length == 0)
            {
                ShowMessage(box, emptyLabel, "(cadena vacía)");
                return;
            }

            try
            {
                int comma = base64.IndexOf(',');
                string clean = (comma >= 0) ? base64.Substring(comma + 1) : base64;
                clean = StripWhitespace(clean);

                if (clean.Length == 0)
                {
                    ShowMessage(box, emptyLabel, "(cadena sin contenido)");
                    return;
                }

                byte[] bytes = Convert.FromBase64String(clean);
                if (bytes == null || bytes.Length == 0)
                {
                    ShowMessage(box, emptyLabel, "(base64 decodificado vacío)");
                    return;
                }

                var ms = new MemoryStream(bytes);
                box.Image = Image.FromStream(ms);

                if (emptyLabel != null) emptyLabel.Visible = false;
                box.Visible = true;
            }
            catch (FormatException ex)
            {
                System.Diagnostics.Debug.WriteLine($"[TransactionImages] base64 inválido en {fieldName}: {ex.Message}");
                ShowMessage(box, emptyLabel, "(base64 inválido)");
            }
            catch (ArgumentException ex)
            {
                System.Diagnostics.Debug.WriteLine($"[TransactionImages] bytes no son imagen en {fieldName}: {ex.Message}");
                ShowMessage(box, emptyLabel, "(no es imagen)");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[TransactionImages] error en {fieldName}: {ex.Message}");
                ShowMessage(box, emptyLabel, "(error: " + ex.GetType().Name + ")");
            }
        }

        private static string StripWhitespace(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            var sb = new System.Text.StringBuilder(s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (!char.IsWhiteSpace(c)) sb.Append(c);
            }
            return sb.ToString();
        }

        private void ShowMessage(PictureBox box, Label emptyLabel, string message)
        {
            if (box != null) box.Visible = false;
            if (emptyLabel != null)
            {
                emptyLabel.Text = message;
                emptyLabel.Visible = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

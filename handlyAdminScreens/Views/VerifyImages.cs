using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using handlyAdminScreens.Helpers;
using handlyAdminScreens.Services;

namespace handlyAdminScreens.Views
{
    public partial class VerifyImages : Form
    {
        // estados de cuenta en App_users.account_state_id
        private const int ACCOUNT_STATE_ACTIVE = 1;
        private const int ACCOUNT_STATE_BANNED = 2;

        private readonly User _user;
        private readonly ApiService _api = new ApiService();

        public VerifyImages(User user)
        {
            InitializeComponent();
            _user = user ?? new User();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // título personalizado con el nombre del usuario
            string displayName = (_user.Name + " " + _user.LastName).Trim();
            if (string.IsNullOrWhiteSpace(displayName)) displayName = "Usuario #" + _user.Id;
            this.Text = "Verificación de identidad - " + displayName;

            // pintar cada imagen, mostrando el label "(no hay imagen)" si está vacía
            LoadImage(pbSelfie, lblSelfieEmpty, _user.Selfie, "selfie");
            LoadImage(pbDocFront, lblDocFrontEmpty, _user.DocumentFront, "document_front");
            LoadImage(pbDocBack, lblDocBackEmpty, _user.DocumentBack, "document_back");
        }

        // intenta decodificar la cadena base64 y mostrarla en el PictureBox
        // si falla, mostramos un mensaje distinto según POR QUÉ falla
        // (para diagnosticar si el problema es la API, la cadena, o los bytes)
        private void LoadImage(PictureBox box, Label emptyLabel, string base64, string fieldName)
        {
            if (box == null) return;
            box.Image = null;

            // CASO 1: la API no mandó nada (null) o vino vacía
            if (base64 == null)
            {
                ShowMessage(box, emptyLabel, "(API no envió este campo)");
                System.Diagnostics.Debug.WriteLine($"[VerifyImages] {fieldName} es null - la API no devuelve la columna");
                return;
            }
            if (base64.Length == 0)
            {
                ShowMessage(box, emptyLabel, "(cadena vacía)");
                return;
            }

            try
            {
                // si viene como data URI ("data:image/png;base64,iVBOR...") quitamos el prefijo
                int comma = base64.IndexOf(',');
                string clean = (comma >= 0) ? base64.Substring(comma + 1) : base64;

                // Convert.FromBase64String es ESTRICTO con espacios/saltos de línea
                // -> los limpiamos todos antes de decodificar
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

                // usamos un nuevo MemoryStream sin "using" porque Image.FromStream
                // mantiene una referencia al stream mientras la imagen exista
                var ms = new MemoryStream(bytes);
                box.Image = Image.FromStream(ms);

                if (emptyLabel != null) emptyLabel.Visible = false;
                box.Visible = true;
            }
            catch (FormatException ex)
            {
                System.Diagnostics.Debug.WriteLine($"[VerifyImages] base64 inválido en {fieldName}: {ex.Message}");
                ShowMessage(box, emptyLabel, "(base64 inválido)");
            }
            catch (ArgumentException ex)
            {
                // Image.FromStream lanza ArgumentException si los bytes no son una imagen válida
                System.Diagnostics.Debug.WriteLine($"[VerifyImages] bytes no son imagen en {fieldName}: {ex.Message}");
                ShowMessage(box, emptyLabel, "(no es imagen)");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[VerifyImages] error en {fieldName}: {ex.Message}");
                ShowMessage(box, emptyLabel, "(error: " + ex.GetType().Name + ")");
            }
        }

        // quita TODOS los whitespace (espacios, tabs, saltos de línea) de la cadena base64
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

        // botón "Aprobar": pone la cuenta del usuario en estado activo (1)
        private async void btnApprove_Click(object sender, EventArgs e)
        {
            await ChangeStateAsync(
                ACCOUNT_STATE_ACTIVE,
                "¿Aprobar la verificación de identidad?\nLa cuenta del usuario pasará a estado ACTIVO.");
        }

        // botón "Denegar": pone la cuenta del usuario en estado baneado (2)
        private async void btnDeny_Click(object sender, EventArgs e)
        {
            await ChangeStateAsync(
                ACCOUNT_STATE_BANNED,
                "¿Denegar la verificación?\nLa cuenta del usuario pasará a estado BANEADO.");
        }

        // helper común a aprobar/denegar: confirma -> llama API -> cierra el form si va bien
        private async System.Threading.Tasks.Task ChangeStateAsync(int newStateId, string confirmMessage)
        {
            if (_user == null || _user.Id <= 0)
            {
                SafeData.ShowError("Usuario no válido", "No se puede actualizar este usuario.");
                return;
            }

            var confirm = MessageBox.Show(confirmMessage, "Confirmar",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (confirm != DialogResult.OK) return;

            SetBusy(true);
            try
            {
                var result = await _api.ChangeUserStateAsync(_user.Id, newStateId);
                if (!result.Success)
                {
                    SafeData.ShowError("No se pudo actualizar",
                        "Error al cambiar el estado: " + result.ErrorMessage);
                    return;
                }

                // OK -> cerramos con DialogResult.OK para que VerificacionIdentidades refresque
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                SafeData.ShowError("Error inesperado",
                    "No se pudo cambiar el estado del usuario.", ex);
            }
            finally
            {
                SetBusy(false);
            }
        }

        private void SetBusy(bool busy)
        {
            btnApprove.Enabled = !busy;
            btnDeny.Enabled = !busy;
            btnClose.Enabled = !busy;
            this.Cursor = busy ? Cursors.WaitCursor : Cursors.Default;
        }
    }
}

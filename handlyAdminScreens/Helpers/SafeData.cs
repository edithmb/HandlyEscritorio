using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace handlyAdminScreens.Helpers
{
    /// <summary>
    /// Helpers para trabajar con datos posiblemente incompletos o nulos
    /// (campos que la API aún no devuelve, fechas vacías, listas null, etc.).
    ///
    /// Estos métodos sirven aunque la API esté completa: actúan como una
    /// red de seguridad. Validan/normalizan antes de pintar en pantalla.
    /// </summary>
    public static class SafeData
    {
        // mínimo válido para DateTimePicker (1753-01-01)
        private static readonly DateTime DtpMin = new DateTime(1753, 1, 1);

        // texto seguro: si es null o vacío devuelve el fallback
        public static string Text(string value, string fallback = "")
        {
            return string.IsNullOrWhiteSpace(value) ? fallback : value;
        }

        // fecha segura para DateTimePicker (que sólo acepta >= 1753)
        public static DateTime Date(DateTime value, DateTime? fallback = null)
        {
            if (value < DtpMin || value == DateTime.MinValue)
            {
                return fallback ?? DateTime.Today;
            }
            return value;
        }

        // asigna fecha al DateTimePicker sin reventar si no es válida
        public static void SetDate(DateTimePicker dtp, DateTime value, DateTime? fallback = null)
        {
            if (dtp == null) return;
            try
            {
                dtp.Value = Date(value, fallback);
            }
            catch
            {
                dtp.Value = fallback ?? DateTime.Today;
            }
        }

        // selecciona un índice en un ComboBox sin reventar si está fuera de rango
        public static void SelectIndex(ComboBox cmb, int index)
        {
            if (cmb == null) return;
            if (index < 0 || index >= cmb.Items.Count)
            {
                cmb.SelectedIndex = -1;
                return;
            }
            cmb.SelectedIndex = index;
        }

        // lista segura: nunca devuelve null
        public static List<T> List<T>(List<T> value)
        {
            return value ?? new List<T>();
        }

        // muestra un mensaje de error con un formato uniforme
        public static void ShowError(string title, string message, Exception ex = null)
        {
            string body = message;
            if (ex != null)
            {
                body += Environment.NewLine + Environment.NewLine + "Detalle técnico: " + ex.Message;
            }
            MessageBox.Show(body, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // muestra un mensaje de info con formato uniforme
        public static void ShowInfo(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

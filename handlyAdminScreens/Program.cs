using System;
using System.Threading;
using System.Windows.Forms;
using handlyAdminScreens.Helpers;
using handlyAdminScreens.Views;

namespace handlyAdminScreens
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // -- red de seguridad para excepciones que no se hayan capturado en otro sitio --
            // si algo peta dentro de un handler de UI, mostramos un mensaje en vez de cerrar la app
            Application.ThreadException += (sender, e) =>
            {
                SafeData.ShowError("Error inesperado",
                    "Ha ocurrido un error inesperado en la aplicación. Inténtalo de nuevo.",
                    e.Exception);
            };

            // si peta algo fuera del hilo de UI (ej. tarea async sin await), tampoco queremos cerrar
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                var ex = e.ExceptionObject as Exception;
                SafeData.ShowError("Error crítico",
                    "Ha ocurrido un error crítico en segundo plano.",
                    ex);
            };

            // primero el login: si no entra, no se abre el resto de la app
            using (var login = new Login())
            {
                var result = login.ShowDialog();
                if (result != DialogResult.OK || !login.LoginSuccess)
                {
                    return;
                }
            }

            // login OK -> abrir la pantalla principal
            Application.Run(new NavigationButtons());
        }
    }
}

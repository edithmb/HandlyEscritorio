using System;
using System.Threading;
using System.Windows.Forms;
using handlyAdminScreens.Helpers;
using handlyAdminScreens.Services;
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
            Application.ThreadException += (sender, e) =>
            {
                SafeData.ShowError("Error inesperado",
                    "Ha ocurrido un error inesperado en la aplicación. Inténtalo de nuevo.",
                    e.Exception);
            };

            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                var ex = e.ExceptionObject as Exception;
                SafeData.ShowError("Error crítico",
                    "Ha ocurrido un error crítico en segundo plano.",
                    ex);
            };

            // Al arrancar la app borramos los caches de datos (usuarios, transacciones,
            // denuncias, verificación). Así cada lanzamiento de la app empieza limpio
            // y cada pestaña hace su llamada al API la primera vez que se abre.
            // Los catálogos (estados, roles) NO se borran aquí: se recargan tras login.
            CacheService.ClearDataCaches();

            // ----- bucle login -> main -> logout -> login -----
            while (true)
            {
                // 1. Login
                using (var login = new Login())
                {
                    var result = login.ShowDialog();
                    if (result != DialogResult.OK || !login.LoginSuccess)
                    {
                        // el usuario canceló el login -> salir de la app
                        return;
                    }
                }

                // 2. Tras login OK, cargamos los catálogos (account_states, roles, etc.)
                // Se hace en sincrónico para no abrir la pantalla principal hasta tenerlos.
                LoadCatalogsBlocking();

                // 3. Mostramos la pantalla principal
                var nav = new NavigationButtons();
                Application.Run(nav);

                // 4. Cuando NavigationButtons se cierra, miramos si fue por logout
                //    o si el usuario cerró la ventana (X) -> salir
                if (!nav.LoggedOut) return;

                // 5. Logout -> los caches ya se han borrado en btnLogout_Click,
                //    volvemos al bucle para mostrar el Login otra vez.
            }
        }

        // carga catálogos del API en modo bloqueante (Task.GetAwaiter().GetResult()).
        // No es ideal en general pero aquí estamos justo después del login, antes de
        // abrir cualquier UI compleja, así que es seguro y mantiene el código simple.
        private static void LoadCatalogsBlocking()
        {
            try
            {
                var api = new ApiService();
                var result = api.GetCatalogsAsync().GetAwaiter().GetResult();
                if (result.Success && result.Data != null)
                {
                    Catalogs.Set(result.Data);
                }
                else
                {
                    // si la API falla, intentamos cargar del cache anterior por si acaso
                    Catalogs.LoadFromDisk();
                    System.Diagnostics.Debug.WriteLine(
                        "No se pudieron cargar los catálogos desde la API: " + result.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                Catalogs.LoadFromDisk();
                System.Diagnostics.Debug.WriteLine("Error cargando catálogos: " + ex.Message);
            }
        }
    }
}

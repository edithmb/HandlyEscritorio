using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace handlyAdminScreens.Views
{
    public partial class Usuarios : Form
    {

        private List<UserGridItem> _listaUsuariosDePrueba;

        public Usuarios()
        {
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            // 2. CREAR LOS DATOS INVENTADOS
            _listaUsuariosDePrueba = new List<UserGridItem>
            {
                // Usuario 1: Un cliente activo
                new UserGridItem
                {
                    Id = 1,
                    UserId = 101,
                    Name = "Juan",
                    LastName = "Pérez",
                    Email = "juan@ejemplo.com",
                    RoleId = 1, // 1 = Cliente
                    StateId = 1, // 1 = Active
                    DNI = "12345678A",
                    StreetNumber = "Calle Mayor 1",
                    City = "Madrid",
                    Postalcode = "28001",
                    Country = "España",
                    Birthdate = new DateTime(1990, 5, 15),
                    MobileNumber = "600111222",
                    LastConnection = DateTime.Now.AddHours(-2),
                    AccountCreation = new DateTime(2025, 1, 10),
                    IsAppUser = true
                },

                // Usuario 2: Un profesional baneado
                new UserGridItem
                {
                    Id = 2,
                    UserId = 102,
                    Name = "Laura",
                    LastName = "Gómez",
                    Email = "laura.fontanera@ejemplo.com",
                    RoleId = 2, // 2 = Profesional
                    StateId = 2, // 2 = Banned
                    DNI = "87654321B",
                    StreetNumber = "Av. Diagonal 200",
                    City = "Barcelona",
                    Postalcode = "08001",
                    Country = "España",
                    Birthdate = new DateTime(1985, 8, 22),
                    MobileNumber = "600333444",
                    LastConnection = DateTime.Now.AddDays(-5),
                    AccountCreation = new DateTime(2025, 2, 15),
                    IsAppUser = true
                },

                // Usuario 3: Un admin
                new UserGridItem
                {
                    Id = 3,
                    UserId = 103,
                    Name = "Carlos",
                    LastName = "Admin",
                    Email = "carlos@handly.com",
                    RoleId = 3, // 3 = Admin
                    StateId = 1, // 1 = Active
                    DNI = "99999999Z",
                    StreetNumber = "Oficina Central",
                    City = "Madrid",
                    Postalcode = "28000",
                    Country = "España",
                    Birthdate = new DateTime(1980, 1, 1),
                    MobileNumber = "600999999",
                    LastConnection = DateTime.Now,
                    AccountCreation = new DateTime(2024, 1, 1),
                    IsAppUser = false
                }
            };

            // 3. CONECTAR LOS DATOS AL GRID
            // Suponiendo que tu grid se llama gridUsers en el diseñador
            gridUsers.DataSource = _listaUsuariosDePrueba;


            gridUsers.Columns["RoleId"].Visible = false;
            gridUsers.Columns["StateId"].Visible = false;

            gridUsers.Columns["Name"].HeaderText = "Nombre";
            gridUsers.Columns["LastName"].HeaderText = "Apellidos";
            gridUsers.Columns["Email"].HeaderText = "Correo Electrónico";
            gridUsers.Columns["RoleName"].HeaderText = "Rol"; // ... y mostramos el texto!
            gridUsers.Columns["StateName"].HeaderText = "Estado";
            gridUsers.Columns["DNI"].HeaderText = "DNI / NIE";
            gridUsers.Columns["StreetNumber"].HeaderText = "Dirección";
            gridUsers.Columns["City"].HeaderText = "Ciudad";
            gridUsers.Columns["Postalcode"].HeaderText = "C.P.";
            gridUsers.Columns["Country"].HeaderText = "País";
            gridUsers.Columns["Birthdate"].HeaderText = "F. Nacimiento";
            gridUsers.Columns["MobileNumber"].HeaderText = "Teléfono";
            gridUsers.Columns["LastConnection"].HeaderText = "Últ. Conexión";
            gridUsers.Columns["AccountCreation"].HeaderText = "Fecha Registro";

            // 3. Ordenar las columnas más importantes al principio
            // DisplayIndex es la posición de izquierda a derecha (0 es la primera)
            gridUsers.Columns["Name"].DisplayIndex = 0;
            gridUsers.Columns["LastName"].DisplayIndex = 1;
            gridUsers.Columns["Email"].DisplayIndex = 2;
            gridUsers.Columns["RoleName"].DisplayIndex = 3;
            gridUsers.Columns["StateName"].DisplayIndex = 4;
        }

        private void gridUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba_MCV
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Crear una nueva instancia de ListarPersona
            ListarPersona listar = new ListarPersona();

            // Mostrar el UserControl en el panel
            MostrarControl(listar);
        }

        private void MostrarControl(UserControl control)
        {
            panel1.Controls.Clear();  // Limpiar cualquier control previo
            control.Dock = DockStyle.Fill;  // Ajustar el UserControl al tamaño del panel
            panel1.Controls.Add(control);  // Añadir el UserControl al panel
        }

        public void MostrarFormularioAgregarModificar(Persona persona = null)
        {
            panel1.Controls.Clear();
            var uc = new AgregarModificarPersona();
            uc.Dock = DockStyle.Fill;
            uc.VolverAListar += () =>
            {
                MostrarFormularioListar(); // Método que carga el ListarPersona
            };
            uc.Inicializar(persona);
            panel1.Controls.Add(uc);
        }

        private void MostrarFormularioListar()
        {
            panel1.Controls.Clear();
            var uc = new ListarPersona();
            uc.Dock = DockStyle.Fill;

            // También podés suscribirte a eventos de este control si es necesario
            panel1.Controls.Add(uc);
        }
    }
}

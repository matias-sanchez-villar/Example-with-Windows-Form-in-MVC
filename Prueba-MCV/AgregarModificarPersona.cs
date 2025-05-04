using System;
using System.Windows.Forms;
using Controler;
using Model;

namespace Prueba_MCV
{
    public partial class AgregarModificarPersona: UserControl
    {
        private PersonaController personaController;
        // Variables internas para almacenar la persona actual
        private Persona persona;

        // Evento que otros pueden suscribirse
        public event Action VolverAListar;

        public AgregarModificarPersona()
        {
            InitializeComponent();
            personaController = new PersonaController();
        }

        // Propiedad para establecer y obtener una persona completa
        public void Inicializar(Persona persona = null)
        {
            this.persona = persona;

            if (this.persona != null)
            {
                // Modo modificar
                nombreTextBox.Text = this.persona.Nombre;
                edadTextBox.Text = this.persona.Edad;
                direccionTextBox.Text = this.persona.Direccion;
                btnAgregarModificar.Text = "Modificar";
            }
            else
            {
                // Modo agregar: limpiar campos
                nombreTextBox.Text = "";
                edadTextBox.Text = "";
                direccionTextBox.Text = "";
                btnAgregarModificar.Text = "Agregar";
            }
        }


        private void agregarModificarButton_Click(object sender, EventArgs e)
        {
            if (persona == null) // Si persona es null, estamos en modo agregar
            {
                AgregarPersona();
            }
            else // Si persona no es null, estamos en modo modificar
            {
                ModificarPersona();
            }
        }

        // Método para agregar una persona
        private void AgregarPersona()
        {
            try
            {
                // Obtener los valores de los campos de texto
                string nombre = nombreTextBox.Text;
                string edad = edadTextBox.Text;
                string direccion = direccionTextBox.Text;
                Console.WriteLine($"Nombre: {nombre}, Edad: {edad}, Dirección: {direccion}");

                // Crear una nueva persona
                Persona nuevaPersona = new Persona(0, nombre, edad, direccion);
                bool resultado = personaController.GuardarPersona(nuevaPersona);

                // Mostrar mensaje de éxito o error
                MessageBox.Show(resultado ? "Persona agregada exitosamente." : "Error al agregar la persona.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                VolverAListar?.Invoke();
            }
        }

        // Método para modificar una persona
        private void ModificarPersona()
        {
            try
            {
                // Obtener los valores de los campos de texto
                string nombre = nombreTextBox.Text;
                string edad = edadTextBox.Text;
                string direccion = direccionTextBox.Text;

                // Modificar los datos de la persona existente
                persona.Nombre = nombre;
                persona.Edad = edad;
                persona.Direccion = direccion;

                bool resultado = personaController.ModificarPersona(persona);

                // Mostrar mensaje de éxito o error
                MessageBox.Show(resultado ? "Persona modificada exitosamente." : "Error al modificar la persona.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                VolverAListar?.Invoke();
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            VolverAListar?.Invoke();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Controler;

namespace Prueba_MCV
{
    public partial class ListarPersona: UserControl
    {

        private PersonaController personaController = new PersonaController();


        public ListarPersona()
        {
            InitializeComponent();
            CargarPersonas();
        }

        private void CargarPersonas()
        {
            personaDataGridView.Columns.Clear(); // Limpiar columnas anteriores

            List<Persona> personas = personaController.ObtenerTodasLasPersonas();

            // Asignar la lista al DataSource
            personaDataGridView.DataSource = new BindingList<Persona>(personas); // Para que se pueda editar si querés

            // Agregar botón "Eliminar"
            DataGridViewButtonColumn eliminarBtn = new DataGridViewButtonColumn();
            eliminarBtn.HeaderText = "Eliminar";
            eliminarBtn.Text = "Eliminar";
            eliminarBtn.Name = "Eliminar";
            eliminarBtn.UseColumnTextForButtonValue = true;
            personaDataGridView.Columns.Add(eliminarBtn);

            // Agregar botón "Modificar"
            DataGridViewButtonColumn modificarBtn = new DataGridViewButtonColumn();
            modificarBtn.HeaderText = "Modificar";
            modificarBtn.Text = "Modificar";
            modificarBtn.Name = "Modificar";
            modificarBtn.UseColumnTextForButtonValue = true;
            personaDataGridView.Columns.Add(modificarBtn);

            // Manejar clicks en los botones
            personaDataGridView.CellClick -= personaDataGridView_CellClick; // evitar múltiples suscripciones
            personaDataGridView.CellClick += personaDataGridView_CellClick;

            personaDataGridView.RowHeadersVisible = false;

        }

        private void personaDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Obtener la persona seleccionada
            Persona personaSeleccionada = (Persona)personaDataGridView.Rows[e.RowIndex].DataBoundItem;

            if (personaDataGridView.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                if (MessageBox.Show("¿Estás seguro que querés eliminar a esta persona?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (personaController.EliminarPersona(personaSeleccionada.Id))
                    {
                        MessageBox.Show("Persona eliminada correctamente.");
                        CargarPersonas();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar.");
                    }
                }
            }
            else if (personaDataGridView.Columns[e.ColumnIndex].Name == "Modificar")
            {
                // Acá luego hacés el formulario para modificar
                Form1 form = (Form1)this.FindForm();
                form.MostrarFormularioAgregarModificar(personaSeleccionada);
            }
        }




        private void btnAgregarPersona_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)this.FindForm();
            form.MostrarFormularioAgregarModificar();
        }
    }
}

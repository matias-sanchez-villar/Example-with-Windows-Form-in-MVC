using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Edad { get; set; }
        public string Direccion { get; set; }

        // Constructor por defecto
        public Persona() { }

        // Constructor con parámetros para inicializar las propiedades
        public Persona(int id, string nombre, string edad, string direccion)
        {
            Id = id;
            Nombre = nombre;
            Edad = edad;
            Direccion = direccion;
        }

        // Método ToString para mostrar la información de la persona en formato de texto
        public override string ToString()
        {
            return $"ID: {Id}, Nombre: {Nombre}, Edad: {Edad}, Dirección: {Direccion}";
        }
    }
}

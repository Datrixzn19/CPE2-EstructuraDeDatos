using System;
using System.Collections.Generic;

namespace ParqueDiversiones
{
    // Clase que representa a una persona en la cola
    public class Persona
    {
        public string Nombre { get; set; } 

        public Persona(string nombre)
        {
            Nombre = nombre;
        }
    }


/*
La calse Cabecera es simplemente visual, no afecta al sistema
es una portada basica
*/
    public class Cabecera
    {
        public static void uea()
        {
            string guiones = new string('✦', 101);//ponemos el mensaje y luego las veces que se repite
            string mitadGuiones = new string('✦', 48);

            Console.WriteLine(guiones);
            Console.WriteLine($"{guiones}\n{mitadGuiones} UEA {mitadGuiones}\n{guiones}");
            Console.WriteLine(guiones);
        }
    }



    // Clase que representa la cola de espera y la asignación de asientos
    public class ColaAtraccion
    {
        private Queue<Persona> cola; // Cola de personas esperando
        private int asientosDisponibles; // Número de asientos disponibles
        private const int TotalAsientos = 30; // Total de asientos en la atracción


        public ColaAtraccion()
        {
            cola = new Queue<Persona>();//inicializamos la cola o queue
            asientosDisponibles = TotalAsientos;//al inicio los asientos disponibles seran igual a los asientos totales
        }
        

        // Método para agregar una persona a la cola
        public void AgregarPersona(Persona persona)
        {
            if (asientosDisponibles > 0)
            {
                cola.Enqueue(persona); // Enqueue agrega una persona 
               
                Console.WriteLine($"{persona.Nombre} se ha unido a la cola.");
            }
            else
            {
                Console.WriteLine("Lo siento, todos los asientos están ocupados.");
            }
        }

        // Método para simular el proceso de subir a la atracción
        public void SubirAtraccion()
        {
            while (cola.Count > 0)
            {
                Persona persona = cola.Dequeue(); // Dequeue saca a la persona de la cola
                if(asientosDisponibles >0) asientosDisponibles--;
                
                Console.WriteLine($"{persona.Nombre} ha subido a la atracción. Asientos disponibles: {asientosDisponibles}");
            }

            Console.WriteLine("\n\nTodos los asientos han sido ocupados y la atracción está llena.");
        }
    }

    // Clase principal del programa
    class Program
    {
        static void Main(string[] args)
        {
            Cabecera.uea();//portada simple para la presentacion de la practica 
            Console.WriteLine("\nSimulacion de una cola de personas que buscan subirse a una atraccion en un parque, pero hay asientos limitados y deben subirse en orden de llegada \n\n");
          
          
            // Crear una instancia de la cola de la atracción
            ColaAtraccion colaAtraccion = new ColaAtraccion();

            
            Console.WriteLine("\n \n");//Mejoranmos la visibilidad dando espacios 

            // Simular la llegada de personas a la cola
            for (int i = 1; i <= 30; i++) // Intentamos agregar 35 personas
            {
                Persona persona = new Persona($"Persona {i}");
                colaAtraccion.AgregarPersona(persona);//la agraegamos a la cola 
            }

            Console.WriteLine("\n \n");

            // Simular el proceso de subir a la atracción
            colaAtraccion.SubirAtraccion();
        }
    }
}
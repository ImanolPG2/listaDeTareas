using System;
using System.Collections.Generic;
using System.Linq;

class Tarea
{
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public int Prioridad { get; set; }

    public override string ToString()
    {
        return $"Título: {Titulo}, Descripción: {Descripcion}, Prioridad: {Prioridad}";
    }
}

class Program
{
    static LinkedList<Tarea> listaTareas = new LinkedList<Tarea>();

    static void Main(string[] args)
    {
        while (true)
        {
            MostrarMenu();
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarTarea();
                    break;
                case "2":
                    MostrarTareas();
                    break;
                case "3":
                    BuscarTarea();
                    break;
                case "4":
                    EliminarTarea();
                    break;
                case "5":
                    CambiarPrioridad();
                    break;
                case "6":
                    Console.WriteLine("Saliendo del programa...");
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("\n--- Gestor de Tareas ---");
        Console.WriteLine("1. Agregar tarea");
        Console.WriteLine("2. Mostrar tareas");
        Console.WriteLine("3. Buscar tarea");
        Console.WriteLine("4. Eliminar tarea");
        Console.WriteLine("5. Cambiar prioridad");
        Console.WriteLine("6. Salir");
        Console.Write("Seleccione una opción: ");
    }

    static void AgregarTarea()
    {
        Console.Write("Título: ");
        string titulo = Console.ReadLine();
        Console.Write("Descripción: ");
        string descripcion = Console.ReadLine();
        Console.Write("Prioridad (1-5): ");
        int prioridad = int.Parse(Console.ReadLine());

        Tarea nuevaTarea = new Tarea { Titulo = titulo, Descripcion = descripcion, Prioridad = prioridad };
        listaTareas.AddLast(nuevaTarea);
        Console.WriteLine("Tarea agregada exitosamente.");
    }

    static void MostrarTareas()
    {
        if (listaTareas.Count == 0)
        {
            Console.WriteLine("No hay tareas en la lista.");
            return;
        }

        var tareasOrdenadas = listaTareas.OrderByDescending(t => t.Prioridad);
        foreach (var tarea in tareasOrdenadas)
        {
            Console.WriteLine(tarea);
        }
    }

    static void BuscarTarea()
    {
        Console.Write("Buscar por (1) Título o (2) Prioridad: ");
        string opcion = Console.ReadLine();

        if (opcion == "1")
        {
            Console.Write("Ingrese el título a buscar: ");
            string titulo = Console.ReadLine();
            var tareas = listaTareas.Where(t => t.Titulo.ToLower().Contains(titulo.ToLower()));
            MostrarResultadosBusqueda(tareas);
        }
        else if (opcion == "2")
        {
            Console.Write("Ingrese la prioridad a buscar: ");
            int prioridad = int.Parse(Console.ReadLine());
            var tareas = listaTareas.Where(t => t.Prioridad == prioridad);
            MostrarResultadosBusqueda(tareas);
        }
        else
        {
            Console.WriteLine("Opción no válida.");
        }
    }

    static void MostrarResultadosBusqueda(IEnumerable<Tarea> tareas)
    {
        if (!tareas.Any())
        {
            Console.WriteLine("No se encontraron tareas.");
        }
        else
        {
            foreach (var tarea in tareas)
            {
                Console.WriteLine(tarea);
            }
        }
    }

    static void EliminarTarea()
    {
        Console.Write("Ingrese el título de la tarea a eliminar: ");
        string titulo = Console.ReadLine();
        var tarea = listaTareas.FirstOrDefault(t => t.Titulo.ToLower() == titulo.ToLower());

        if (tarea != null)
        {
            listaTareas.Remove(tarea);
            Console.WriteLine("Tarea eliminada exitosamente.");
        }
        else
        {
            Console.WriteLine("No se encontró la tarea especificada.");
        }
    }

    static void CambiarPrioridad()
    {
        Console.Write("Ingrese el título de la tarea: ");
        string titulo = Console.ReadLine();
        var tarea = listaTareas.FirstOrDefault(t => t.Titulo.ToLower() == titulo.ToLower());

        if (tarea != null)
        {
            Console.Write("Nueva prioridad (1-5): ");
            int nuevaPrioridad = int.Parse(Console.ReadLine());
            tarea.Prioridad = nuevaPrioridad;
            Console.WriteLine("Prioridad actualizada exitosamente.");
        }
        else
        {
            Console.WriteLine("No se encontró la tarea especificada.");
        }
    }
}
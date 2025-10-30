using System;
using System.Collections.Generic;

namespace ListaCalificaciones
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> calificaciones = new List<double>();
            int opcion = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("MENU DE CALIFICACIONES");
                Console.WriteLine("1. Agregar calificacion");
                Console.WriteLine("2. Eliminar calificacion");
                Console.WriteLine("3. Buscar calificacion");
                Console.WriteLine("4. Ordenar calificaciones");
                Console.WriteLine("5. Mostrar todas las calificaciones");
                Console.WriteLine("6. Salir");
                Console.Write("Elige una opcion: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Por favor ingresa un numero valido...");
                    Console.ReadKey();
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        Console.Write("Introduce la calificacion: ");
                        if (double.TryParse(Console.ReadLine(), out double nuevaCalificacion))
                        {
                            calificaciones.Add(nuevaCalificacion);
                            Console.WriteLine("Calificacion agregada correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Entrada no valida, intenta de nuevo.");
                        }
                        break;

                    case 2:
                        Console.Write("Calificación a eliminar: ");
                        if (double.TryParse(Console.ReadLine(), out double eliminar))
                        {
                            if (calificaciones.Contains(eliminar))
                            {
                                calificaciones.Remove(eliminar);
                                Console.WriteLine("Calificacion eliminada.");
                            }
                            else
                            {
                                Console.WriteLine("Esa calificacion no está en la lista.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Entrada no valida.");
                        }
                        break;

                    case 3:
                        Console.Write("Calificacion a buscar: ");
                        if (double.TryParse(Console.ReadLine(), out double buscar))
                        {
                            if (calificaciones.Contains(buscar))
                                Console.WriteLine("La calificacion si se encuentra en la lista.");
                            else
                                Console.WriteLine("No se encontro esa calificacion.");
                        }
                        else
                        {
                            Console.WriteLine("Entrada no valida.");
                        }
                        break;

                    case 4:
                        calificaciones.Sort();
                        Console.WriteLine("Calificaciones ordenadas de menor a mayor.");
                        break;

                    case 5:
                        Console.WriteLine("=== LISTA DE CALIFICACIONES ===");
                        if (calificaciones.Count == 0)
                        {
                            Console.WriteLine("No hay calificaciones registradas.");
                        }
                        else
                        {
                            foreach (var c in calificaciones)
                            {
                                Console.WriteLine(c);
                            }
                        }
                        break;

                    case 6:
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opcion no valida.");
                        break;
                }

                Console.WriteLine("\nPresiona una tecla para continuar...");
                Console.ReadKey();

            } while (opcion != 6);
        }
    }
}
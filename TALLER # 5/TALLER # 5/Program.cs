using System;
using TALLER___5;

class Program
{
    static void Main(string[] args)
    {
        DoublyLinkedList<string> list = new DoublyLinkedList<string>();
        int option;

        do
        {
            Console.WriteLine("\n--- MENÚ ---");
            Console.WriteLine("1. Adicionar");
            Console.WriteLine("2. Mostrar hacia adelante");
            Console.WriteLine("3. Mostrar hacia atrás");
            Console.WriteLine("4. Ordenar descendentemente");
            Console.WriteLine("5. Mostrar moda(s)");
            Console.WriteLine("6. Mostrar gráfico");
            Console.WriteLine("7. Existe");
            Console.WriteLine("8. Eliminar una ocurrencia");
            Console.WriteLine("9. Eliminar todas las ocurrencias");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.Write("Ingrese valor: ");
                    string value = Console.ReadLine();
                    list.AddInOrder(value);
                    break;
                case 2:
                    Console.WriteLine("Lista hacia adelante:");
                    list.DisplayForward();
                    break;
                case 3:
                    Console.WriteLine("Lista hacia atrás:");
                    list.DisplayBackward();
                    break;
                case 4:
                    list.SortDescending();
                    Console.WriteLine("Lista ordenada en orden descendente.");
                    break;
                case 5:
                    list.ShowModes();
                    break;
                case 6:
                    list.ShowGraph();
                    break;
                case 7:
                    Console.Write("Valor a buscar: ");
                    string search = Console.ReadLine();
                    Console.WriteLine(list.Exists(search) ? "Sí existe" : "No existe");
                    break;
                case 8:
                    Console.Write("Valor a eliminar (una vez): ");
                    string removeOne = Console.ReadLine();
                    list.RemoveOne(removeOne);
                    break;
                case 9:
                    Console.Write("Valor a eliminar (todas las ocurrencias): ");
                    string removeAll = Console.ReadLine();
                    list.RemoveAll(removeAll);
                    break;
                case 0:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

        } while (option != 0);
    }
}

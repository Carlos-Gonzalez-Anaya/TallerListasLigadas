
using DoubleList;

var list = new DoubleLinkedList<string>();
var option = string.Empty;
var value = string.Empty;

do
{
    option = Menu();
    Console.WriteLine();

    switch (option)
    {
        case "1":
            Console.Write("Ingrese un valor: ");
            value = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(value))
            {
                list.InsertOrdered(value);
                Console.WriteLine($"'{value}' agregado correctamente.");
            }
            else
                Console.WriteLine("Valor vacío, no se agregó.");
            break;

        case "2":
            Console.WriteLine("Lista hacia adelante:");
            Console.WriteLine(list.ToString());
            break;

        case "3":
            Console.WriteLine("Lista hacia atrás:");
            Console.WriteLine(list.ToStringReverse());
            break;

        case "4":
            list.Reverse();
            Console.WriteLine("Lista ordenada descendentemente:");
            Console.WriteLine(list.ToString());
            break;

        case "5":
            var modes = list.GetModes();
            if (modes.Count == 0)
                Console.WriteLine("La lista está vacía, no hay moda.");
            else if (modes.Count == 1)
                Console.WriteLine($"Moda: {modes[0]}");
            else
                Console.WriteLine($"Modas: {string.Join(", ", modes)}");
            break;

        case "6":
            Console.WriteLine("Gráfico de ocurrencias:");
            Console.WriteLine(list.GetChart());
            break;

        case "7":
            Console.Write("Ingrese un valor a buscar: ");
            value = Console.ReadLine() ?? string.Empty;
            if (list.Contains(value))
                Console.WriteLine($" El valor '{value}' SÍ existe.");
            else
                Console.WriteLine($" El valor '{value}' NO existe.");
            break;

        case "8":
            Console.Write("Ingrese el valor a eliminar (primera ocurrencia): ");
            value = Console.ReadLine() ?? string.Empty;
            list.Remove(value);
            break;

        case "9":
            Console.Write("Ingrese el valor a eliminar (todas las ocurrencias): ");
            value = Console.ReadLine() ?? string.Empty;
            list.RemoveAll(value);
            break;

        case "0":
            Console.WriteLine("¡Hasta luego!");
            break;

        default:
            Console.WriteLine("Opción inválida, intente de nuevo.");
            break;
    }
    if(option != "0")
    {
        Console.WriteLine("----------------------------");
        Console.WriteLine("----------------------------");
    }

} while (option != "0");


string Menu()
{
    Console.WriteLine("      LISTA DOBLEMENTE LIGADA         ");
    Console.WriteLine("  1. Adicionar                        ");
    Console.WriteLine("  2. Mostrar hacia adelante           ");
    Console.WriteLine("  3. Mostrar hacia atrás              ");
    Console.WriteLine("  4. Ordenar descendentemente         ");
    Console.WriteLine("  5. Mostrar la(s) moda(s)            ");
    Console.WriteLine("  6. Mostrar gráfico                  ");
    Console.WriteLine("  7. Existe                           ");
    Console.WriteLine("  8. Eliminar una ocurrencia          ");
    Console.WriteLine("  9. Eliminar todas las ocurrencias   ");
    Console.WriteLine("  0. Salir                            ");
    Console.Write("Seleccione una opción: ");
    return Console.ReadLine() ?? string.Empty;
}
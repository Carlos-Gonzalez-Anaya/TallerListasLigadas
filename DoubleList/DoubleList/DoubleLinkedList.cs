using Shared;

namespace DoubleList;

public class DoubleLinkedList<T> : ILinkedList<T> where T : IComparable<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;

    public DoubleLinkedList()
    {
        _head = null;
        _tail = null;
    }


    public void InsertOrdered(T data)
    {
        var newNode = new Node<T>(data);

        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
            return;
        }

        var current = _head;
        while (current != null && current.Data!.CompareTo(data) < 0)
        {
            current = current.Next;
        }

        if (current == null)
        {
            _tail!.Next = newNode;
            newNode.Previous = _tail;
            _tail = newNode;
        }
        else if (current == _head)
        {
            newNode.Next = _head;
            _head.Previous = newNode;
            _head = newNode;
        }
        else
        {
            newNode.Next = current;
            newNode.Previous = current.Previous;
            current.Previous!.Next = newNode;
            current.Previous = newNode;
        }
    }

    public bool Contains(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
                return true;
            current = current.Next;
        }
        return false;
    }

    public void Remove(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                RemoveNode(current);
                return;
            }
            current = current.Next;
        }
        Console.WriteLine($"El valor '{data}' no fue encontrado.");
    }

    public void RemoveAll(T data)
    {
        var current = _head;
        bool found = false;
        while (current != null)
        {
            var next = current.Next;
            if (current.Data!.Equals(data))
            {
                RemoveNode(current);
                found = true;
            }
            current = next;
        }
        if (!found)
            Console.WriteLine($"El valor '{data}' no fue encontrado.");
    }

    private void RemoveNode(Node<T> node)
    {
        if (node == _head && node == _tail)
        {
            _head = null;
            _tail = null;
        }
        else if (node == _head)
        {
            _head = _head.Next;
            _head!.Previous = null;
        }
        else if (node == _tail)
        {
            _tail = _tail.Previous;
            _tail!.Next = null;
        }
        else
        {
            node.Previous!.Next = node.Next;
            node.Next!.Previous = node.Previous;
        }
    }

    public void Reverse()
    {
        if (_head == null || _head == _tail) return;

        var current = _head;
        while (current != null)
        {
            var temp = current.Previous;
            current.Previous = current.Next;
            current.Next = temp;
            current = current.Previous;
        }

        var oldHead = _head;
        _head = _tail;
        _tail = oldHead;
    }
    public List<T> GetModes()
    {
        if (_head == null) return new List<T>();

        // Paso 1: contar cuántos nodos hay en total
        int total = 0;
        var current = _head;
        while (current != null)
        {
            total++;
            current = current.Next;
        }

        // Paso 2: arreglos paralelos para elementos y conteos
        T[] elements = new T[total];
        int[] counts = new int[total];
        int size = 0;

        current = _head;
        while (current != null)
        {
            // Buscar si el elemento ya está en el arreglo
            bool found = false;
            for (int i = 0; i < size; i++)
            {
                if (elements[i]!.Equals(current.Data))
                {
                    counts[i]++;
                    found = true;
                    break;
                }
            }
            // Si no estaba, agregarlo
            if (!found)
            {
                elements[size] = current.Data!;
                counts[size] = 1;
                size++;
            }
            current = current.Next;
        }

        // Paso 3: buscar el conteo máximo
        int maxCount = 0;
        for (int i = 0; i < size; i++)
            if (counts[i] > maxCount) maxCount = counts[i];

        // Paso 4: recolectar los que tengan el conteo máximo
        var modes = new List<T>();
        for (int i = 0; i < size; i++)
            if (counts[i] == maxCount)
                modes.Add(elements[i]);

        modes.Sort();
        return modes;
    }

    public string GetChart()
    {
        if (_head == null) return "(lista vacía)";

        // Paso 1: contar total de nodos
        int total = 0;
        var current = _head;
        while (current != null)
        {
            total++;
            current = current.Next;
        }

        // Paso 2: arreglos paralelos para elementos y conteos
        T[] elements = new T[total];
        int[] counts = new int[total];
        int size = 0;

        current = _head;
        while (current != null)
        {
            bool found = false;
            for (int i = 0; i < size; i++)
            {
                if (elements[i]!.Equals(current.Data))
                {
                    counts[i]++;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                elements[size] = current.Data!;
                counts[size] = 1;
                size++;
            }
            current = current.Next;
        }

        // Paso 3: construir el gráfico
        var result = string.Empty;
        for (int i = 0; i < size; i++)
            result += $"{elements[i],-12} {new string('*', counts[i])}\n";

        return result.TrimEnd();
    }

    

    public override string ToString()
    {
        var current = _head;
        var result = string.Empty;
        while (current != null)
        {
            result += $"{current.Data} <-> ";
            current = current.Next;
        }
        result += "null";
        return result;
    }

    public string ToStringReverse()
    {
        var current = _tail;
        var result = string.Empty;
        while (current != null)
        {
            result += $"{current.Data} <-> ";
            current = current.Previous;
        }
        result += "null";
        return result;
    }


}
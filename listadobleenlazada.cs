using System;

namespace DoublyLinkedList
{
    // Clase que representa un nodo de la lista doblemente enlazada
    public class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }

        public Node(int data)
        {
            Data = data;
            Next = null;
            Previous = null;
        }
    }

    // Clase que representa la lista doblemente enlazada
    public class DoublyLinkedList
    {
        public Node Head { get; private set; }
        public Node Tail { get; private set; }
        public bool IsCircular { get; set; }

        public DoublyLinkedList()
        {
            Head = null;
            Tail = null;
            IsCircular = false;
        }

        // Método para insertar un nodo al final de la lista
        public void Insert(int data)
        {
            Node newNode = new Node(data);
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                newNode.Previous = Tail;
                Tail = newNode;
            }

            if (IsCircular)
            {
                Tail.Next = Head;
                Head.Previous = Tail;
            }
        }

        // Método para eliminar un nodo por su valor
        public void Delete(int data)
        {
            Node current = Head;
            while (current != null)
            {
                if (current.Data == data)
                {
                    if (current.Previous != null)
                    {
                        current.Previous.Next = current.Next;
                    }
                    else
                    {
                        Head = current.Next;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Previous = current.Previous;
                    }
                    else
                    {
                        Tail = current.Previous;
                    }

                    if (IsCircular && Head != null)
                    {
                        Tail.Next = Head;
                        Head.Previous = Tail;
                    }

                    return;
                }
                current = current.Next;
            }
        }

        // Método para imprimir la lista
        public void Print()
        {
            Node current = Head;
            if (IsCircular)
            {
                if (current == null) return;

                do
                {
                    Console.Write(current.Data + " ");
                    current = current.Next;
                } while (current != Head);
            }
            else
            {
                while (current != null)
                {
                    Console.Write(current.Data + " ");
                    current = current.Next;
                }
            }
            Console.WriteLine();
        }

        // Método para verificar si la lista es circular
        public bool CheckIfCircular()
        {
            if (Head == null) return false;

            Node slow = Head;
            Node fast = Head;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                if (slow == fast)
                {
                    return true;
                }
            }

            return false;
        }
    }

    // Clase principal para probar la lista doblemente enlazada
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList list = new DoublyLinkedList();

            // Insertar elementos
            list.Insert(10);
            list.Insert(20);
            list.Insert(30);

            // Imprimir la lista
            Console.WriteLine("Lista no circular:");
            list.Print();

            // Hacer la lista circular
            list.IsCircular = true;
            list.Insert(40);

            // Imprimir la lista circular
            Console.WriteLine("Lista circular:");
            list.Print();

            // Verificar si la lista es circular
            Console.WriteLine("¿La lista es circular? " + list.CheckIfCircular());

            // Eliminar un elemento
            list.Delete(20);
            Console.WriteLine("Lista después de eliminar 20:");
            list.Print();
        }
    }
}
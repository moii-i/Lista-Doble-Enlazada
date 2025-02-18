# Implementación de una Lista Doblemente Enlazada en C#

Este repositorio contiene una implementación sencilla de una lista doblemente enlazada en C#. La lista incluye un mecanismo para identificar si es circular y maneja operaciones básicas como inserción, eliminación y recorrido de elementos.

## Características

- **Inserción**: Se pueden insertar elementos al final de la lista.
- **Eliminación**: Se pueden eliminar elementos por su valor.
- **Recorrido**: Se puede imprimir la lista, tanto si es circular como si no.
- **Verificación de circularidad**: Se puede verificar si la lista es circular.

## Ejemplos de Uso

```csharp
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

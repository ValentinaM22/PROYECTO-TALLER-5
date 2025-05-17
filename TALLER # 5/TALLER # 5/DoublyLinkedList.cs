using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TALLER___5
{
    public class DoublyLinkedList<T> where T : IComparable<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public DoublyLinkedList()
        {
            head = null;
            tail = null;
        }

        public void AddInOrder(T value)
        {
            Node<T> newNode = new Node<T>(value);

            if (head == null)
            {
                head = tail = newNode;
            }
            else if (value.CompareTo(head.Value) < 0)
            {
                newNode.Next = head;
                head.Previous = newNode;
                head = newNode;
            }
            else
            {
                Node<T> current = head;
                while (current.Next != null && current.Next.Value.CompareTo(value) < 0)
                {
                    current = current.Next;
                }

                newNode.Next = current.Next;
                newNode.Previous = current;

                if (current.Next != null)
                    current.Next.Previous = newNode;
                else
                    tail = newNode;

                current.Next = newNode;
            }
        }

        public void DisplayForward()
        {
            Node<T> current = head;
            while (current != null)
            {
                Console.Write(current.Value + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        public void DisplayBackward()
        {
            Node<T> current = tail;
            while (current != null)
            {
                Console.Write(current.Value + " ");
                current = current.Previous;
            }
            Console.WriteLine();
        }

        public void SortDescending()
        {
            List<T> values = new List<T>();
            Node<T> current = head;

            while (current != null)
            {
                values.Add(current.Value);
                current = current.Next;
            }

            values = values.OrderByDescending(x => x).ToList();
            head = tail = null;

            foreach (T item in values)
            {
                AddInOrder(item);
            }

            // Rebuild manually to maintain descending order
            head = tail = null;
            foreach (T item in values)
            {
                Node<T> newNode = new Node<T>(item);
                if (head == null)
                {
                    head = tail = newNode;
                }
                else
                {
                    tail.Next = newNode;
                    newNode.Previous = tail;
                    tail = newNode;
                }
            }
        }

        public void ShowModes()
        {
            Dictionary<T, int> frequency = new Dictionary<T, int>();
            Node<T> current = head;

            while (current != null)
            {
                if (frequency.ContainsKey(current.Value))
                    frequency[current.Value]++;
                else
                    frequency[current.Value] = 1;

                current = current.Next;
            }

            int max = frequency.Values.Max();
            var modes = frequency.Where(x => x.Value == max);

            Console.WriteLine("Moda(s):");
            foreach (var mode in modes)
            {
                Console.WriteLine($"{mode.Key}: {mode.Value} veces");
            }
        }

        public void ShowGraph()
        {
            Dictionary<T, int> frequency = new Dictionary<T, int>();
            Node<T> current = head;

            while (current != null)
            {
                if (frequency.ContainsKey(current.Value))
                    frequency[current.Value]++;
                else
                    frequency[current.Value] = 1;

                current = current.Next;
            }

            Console.WriteLine("Gráfico de ocurrencias:");
            foreach (var pair in frequency)
            {
                Console.Write($"{pair.Key} ");
                Console.WriteLine(new string('*', pair.Value));
            }
        }

        public bool Exists(T value)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public void RemoveOne(T value)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (current.Previous != null)
                        current.Previous.Next = current.Next;
                    else
                        head = current.Next;

                    if (current.Next != null)
                        current.Next.Previous = current.Previous;
                    else
                        tail = current.Previous;

                    return;
                }
                current = current.Next;
            }
        }

        public void RemoveAll(T value)
        {
            Node<T> current = head;
            while (current != null)
            {
                Node<T> next = current.Next;
                if (current.Value.Equals(value))
                {
                    if (current.Previous != null)
                        current.Previous.Next = current.Next;
                    else
                        head = current.Next;

                    if (current.Next != null)
                        current.Next.Previous = current.Previous;
                    else
                        tail = current.Previous;
                }
                current = next;
            }
        }
    }
}

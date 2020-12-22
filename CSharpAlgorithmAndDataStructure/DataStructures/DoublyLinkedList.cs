using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAlgorithmAndDataStructure.DataStructures
{
    public class DoublyLinkedListNode<T>
    {
        public T Value { get; set; }
        public DoublyLinkedListNode<T> Previous { get; set; }
        public DoublyLinkedListNode<T> Next { get; set; }
        public DoublyLinkedListNode(T value)
        {
            Value = value;
        }

    }
    public class DoublyLinkedList<T> : ICollection<T>
    {
        public DoublyLinkedListNode<T> Head { get; private set; }
        public DoublyLinkedListNode<T> Tail { get; private set; }

        #region Add
        public void AddHead(T item)
        {
            AddHead(new DoublyLinkedListNode<T>(item));
        }

        /// <summary>
        /// Adds node to the top of the head
        /// </summary>
        /// <param name="node"></param>
        public void AddHead(DoublyLinkedListNode<T> node)
        {
            // save off the head so we dont lose it
            var temp = Head;
            // point head to the new node
            Head = node;
            // insert rest of the list behind the head
            Head.Next = temp;
            if (Count == 0)
            {
                // if the list was empty the Head and Tail should point to the new node
                Tail = Head;
            }
            else
            {
                // Before 5(H)-> 3
                // After 2(H)->5-> 3
                // temp.Previous was null before,point its previous to the new Head
                temp.Previous = Head;

            }
            Count++;
        }


        public void AddTail(T item)
        {
            AddTail(new DoublyLinkedListNode<T>(item));
        }
        /// <summary>
        /// Adds the node to the end of the list
        /// </summary>
        /// <param name="node"></param>
        public void AddTail(DoublyLinkedListNode<T> node)
        {
            if (Count == 0)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;

            }
            Tail = node;
            Count++;
        }
        #endregion

        #region Find
        public DoublyLinkedListNode<T> Find(T item)
        {
            DoublyLinkedListNode<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }

        public bool GetHead(out T value)
        {
            if (Count > 0)
            {
                value = Head.Value;
                return true;
            }
            value = default;
            return false;
        }

        public bool GetTail(out T value)
        {
            if (Count > 0)
            {
                value = Tail.Value;
                return true;
            }
            value = default;
            return false;
        }


        #endregion
        #region ICollection

        public int Count { get; private set; }
        public bool IsReadOnly => false;

        public void Add(T item)
        {
            AddHead(item);
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;

        }

        public bool Contains(T item)
        {
            return Find(item) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            DoublyLinkedListNode<T> current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public IEnumerable<T> GetReverseEnumerator()
        {
            var current = Tail;
            while (current != null)
            {
                yield return current.Value;
                current = current.Previous;
            }
        }

        public bool Remove(T item)
        {
            var found = Find(item);
            if (found == null) return false;
            var previous = found.Previous;
            var next = found.Next;
            if (previous == null)
            {
                // we are removing head
                Head = next;
                if (Head != null)
                {
                    Head.Previous = null;
                }
            }
            else
            {
                // found is in position after head
                previous.Next = next;
            }
            if (next == null)
            {
                // we are removing tail
                Tail = previous;
                if (Tail != null)
                {
                    Tail.Next = null;
                }

            }
            else
            {
                // found in in position before tail
                next.Previous = previous;
            }
            Count--;
            return true;



        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}

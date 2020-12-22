using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAlgorithmAndDataStructure.DataStructures
{
    public class LinkedListNode<T>
    {
        public T Value { get; private set; }
        public LinkedListNode<T> Next { get; set; }
        public LinkedListNode(T value)
        {
            Value = value;
        }
    }
    public class LinkedList<T> : ICollection<T>
    {
        public T Head => head.Value;
        public T Tail => tail.Value;
        private LinkedListNode<T> head { get; set; }
        public LinkedListNode<T> tail { get; set; }
        public bool IsReadOnly { get; }
        public int Count { get; private set; }
        #region Add


        /// <summary>
        /// Add value to the start of the head
        /// </summary>
        /// <param name="node"></param>
        public void AddHead(T node)
        {
            AddHead(new LinkedListNode<T>(node));
        }

        /// <summary>
        /// Adds value to th end of the tail
        /// </summary>
        /// <param name="node"></param>
        public void AddTail(T node)
        {
            AddTail(new LinkedListNode<T>(node));
        }
        /// <summary>
        /// Adds node to the start of the head
        /// </summary>
        /// <param name="node"></param>
        public void AddHead(LinkedListNode<T> node)
        {
            //save off the head node so we dont lose it
            var temp = head;
            // point head to the new node
            head = node;
            // insert the rest of the list behind the head
            head.Next = temp;

            // increase the counter
            Count++;
            if (Count == 1) tail = head;
        }

        /// <summary>
        /// Adds node to the end of the tail
        /// </summary>
        /// <param name="node"></param>
        public void AddTail(LinkedListNode<T> node)
        {
            if (Count == 0)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
            }
            tail = node;
            Count++;

        }
        public void Add(T item)
        {
            AddHead(item);
        }


        #endregion

        #region Remove
        public bool Remove(T item)
        {
            LinkedListNode<T> previous = null;
            LinkedListNode<T> current = head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    // must be in mid or at last(tail)
                    if (previous != null)
                    {
                        // Head->3->5->tail becomes Head->3->tail on removing 5
                        previous.Next = current.Next;
                        // tail
                        if (current.Next == null)
                        {
                            tail = previous;
                        }

                        Count--;
                    }
                    else
                    {
                        RemoveFirst();
                    }
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;

        }


        /// <summary>
        /// Removes the first node from the list
        /// </summary>
        public void RemoveFirst()
        {
            // Before: Head -> 3 -> 5
            // After:  Head ------> 5

            // Head -> 3 -> null
            // Head ------> null
            if (Count != 0)
            {
                head = head.Next;
                Count--;
                if (Count == 0)
                {
                    tail = null;
                }
            }
        }


        public void RemoveLast()
        {
            if (Count != 0)
            {
                if (Count == 1)
                {
                    head = null;
                    tail = null;
                }
                var current = head;
                while (current.Next != tail)
                {
                    current = current.Next;
                }
                current.Next = null;
                tail = current;
                Count--;
            }
        }
        /// <summary>
        /// Finds the first node in the list
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Find(LinkedListNode<T> item)
        {
            LinkedListNode<T> current = head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
        #endregion

        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            LinkedListNode<T> current = head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            LinkedListNode<T> current = head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }



        public IEnumerator<T> GetEnumerator()
        {
            var current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAlgorithmAndDataStructure.DataStructures
{
    public class SortedItemList<T> : IEnumerable<T>, ICollection<T> where T : IComparable<T>
    {
        public SortedItemListNode<T> head = null;
        public SortedItemListNode<T> tail = null;

        public class SortedItemListNode<TNode>
        {
            public SortedItemListNode<TNode> prev;
            public SortedItemListNode<TNode> next;
            public TNode data;
            public SortedItemListNode(TNode value, SortedItemListNode<TNode> prev = null, SortedItemListNode<TNode> next = null)
            {
                this.prev = prev;
                this.next = next;
                this.data = value;
            }
        }
        public int Count { get; private set; }
        public bool IsReadOnly => false;

        public void Add(T item)
        {
            // if item < head add before head
            // if item > tail add after tail
            // else find the insertion point and insert
            SortedItemListNode<T> node = new SortedItemListNode<T>(item);
            if (head == null)
            {
                // list is empty
                head = node;
                tail = head;
            }
            // if item is less than head
            else if (head.data.CompareTo(node.data) >= 0)
            {
                // add before head
                node.next = head;
                head.prev = node;
                head = node;
            }
            // if item is greater than tail
            else if (tail.data.CompareTo(node.data) < 0)
            {
                // add after tail
                tail.next = node;
                node.prev = tail;
                tail = node;
            }
            else
            {
                // find the insertion point
                var insertBefore = head;
                while (insertBefore.data.CompareTo(node.data) < 0)
                {
                    insertBefore = insertBefore.next;
                }
                // insert the node
                node.next = insertBefore;
                node.prev = insertBefore.prev;
                insertBefore.prev.next = node;
                insertBefore.prev = node;
            }
            Count++;

        }

        public SortedItemListNode<T> FindNode(T item)
        {
            SortedItemListNode<T> current = head;
            while (current != null)
            {
                if (current.data.Equals(item))
                {
                    return current;
                }
                current = current.next;
            }
            return null;

        }

        public bool Find(T item, out T value)
        {
            var found = FindNode(item);
            if (found == null)
            {
                value = default;
                return false;
            }
            value = found.data;
            return true;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            return FindNode(item) != null;
        }


        public void CopyTo(T[] array, int arrayIndex)
        {
            var current = head;
            while (current != null)
            {
                array[arrayIndex++] = current.data;
                current = current.next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = head;
            while (current != null)
            {
                yield return current.data;
                current = current.next;
            }
        }

        public bool Remove(T item)
        {
            var found = FindNode(item);
            if (found == null)
            {
                return false;
            }
            var prev = found.prev;
            var next = found.next;

            //list contains one node
            if (prev == null && next == null)
            {
                //after removing the node
                prev = null;
                next = null;
            }
            // node to remove is in between head and tail
            else if (prev != null && next != null)
            {
                prev.next = next;
                next.prev = prev;
            }
            // node is at tail
            else if (prev != null && next == null)
            {
                // remove the tail

                prev.next = null;
                tail = prev;
            }
            // node is at head
            else
            {
                // remove the head

                next.prev = null;
                head = next;
            }
            Count--;
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetReverseEnumerator()
        {
            var current = tail;
            while (current != null)
            {
                yield return current.data;
                current = tail.prev;
            }
        }
    }
}

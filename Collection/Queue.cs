using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection
{
    public class Queue<T> : IEnumerable<T>
    {
        #region Fields and properties

        private static T[] emptyArray = new T[0];
        private T[] array;
        private int head;
        private int tail;
        private int size;

        public int Count => size;

        #endregion Fields
        
        #region Construction

        /// <summary>
        /// Construction
        /// </summary>
        public Queue() => array = emptyArray;
        
        /// <summary>
        /// Construction
        /// </summary>
        /// <param name="capacity">
        /// Size
        /// </param>
        public Queue(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            array = new T[capacity];
            head = 0;
            tail = 0;
            size = 0;
        }

        #endregion Construction

        #region API

        /// <summary>
        /// Method to add element to queue  
        /// </summary>
        /// <param name="item">
        /// Item for adding
        /// </param>
        public void Enqueue(T item)
        {
            if (size == array.Length)
            {
                int capacity = array.Length * 2;
                SetCapacity(capacity);
            }

            array[tail] = item;
            tail = (tail + 1) % array.Length;
            size = size + 1;
        }

        public T Dequeue()
        {
            if (size == 0)
            {
                throw new ArgumentNullException("Queue is empty");
            }

            T obj = array[head];
            array[head] = default(T);
            head = (head + 1) % array.Length;
            size = size - 1;
            return obj;
        }
        
        #endregion API

        #region IEnumerable<T> members

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)new Enumerator(this);
        }

        #endregion IEnumerable<T> members

        #region Helpers

        private T GetElement(int i)
        {
            return array[(head + i) % array.Length];
        }

        private void SetCapacity(int capacity)
        {
            T[] objArray = new T[capacity];
            if (size > 0)
            {
                if (head < tail)
                {
                    Array.Copy((Array)array, head, (Array)objArray, 0, size);
                }
                else
                {
                    Array.Copy((Array)array, head, (Array)objArray, 0, array.Length - head);
                    Array.Copy((Array)array, 0, (Array)objArray, array.Length - head, tail);
                }
            }

            array = objArray;
            head = 0;
            tail = size == capacity ? 0 : size;
        }

        #endregion Helpers

        /// <summary>
        /// Enumerator for queue 
        /// </summary>
        public struct Enumerator : IEnumerator<T>, IEnumerator
        {
            private Queue<T> q;
            private int index;
            private T currentElement;

            public Enumerator(Queue<T> q)
            {
                this.q = q;
                index = -1;
                currentElement = default(T);
            }

            public T Current
            {
                get
                {
                    if (index < 0)
                    {
                        if (index == -1)
                        {
                            throw new ArgumentNullException(nameof(q));
                        }
                    }

                    return currentElement;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    if (index < 0)
                    {
                        if (index == -1)
                        {
                            throw new ArgumentNullException(nameof(q));
                        }
                    }

                    return (object)currentElement;
                }
            }

            public bool MoveNext()
            {
                if (index == -2)
                {
                    return false;
                }

                index = index + 1;
                if (index == q.size)
                {
                    index = -2;
                    currentElement = default(T);
                    return false;
                }

                currentElement = q.GetElement(index);
                return true;
            }

            void IEnumerator.Reset()
            {
                index = -1;
                currentElement = default(T);
            }

            public void Dispose()
            {
                index = -2;
                currentElement = default(T);
            }
        }
    }
}

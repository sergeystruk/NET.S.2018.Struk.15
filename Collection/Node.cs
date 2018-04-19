using System;
using System.Collections.Generic;

namespace Collection
{
    public class Node<T>
    {
        internal Node<T> left;
        internal Node<T> right;
        public int countNode;
        public T Value { get; }

        public Node(T value)
        {
            Value = value;
            countNode++;
        }
        
    }
}
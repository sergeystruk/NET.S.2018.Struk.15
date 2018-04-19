using System;
using System.Collections.Generic;

namespace Collection
{
    public class BinarySearchTree<T>
    {
        #region Fields

        private Node<T> root;
        private IComparer<T> comparer;

        #endregion

        #region Constructor

        BinarySearchTree(IComparer<T> comp)
        {
            if (ReferenceEquals(comp, null))
            {
                if (root.Value is IComparer<T>)
                {
                    comparer = Comparer<T>.Default;
                }
                else
                {
                    comparer = comp;
                }
            }

            comparer = comp;
        }

        #endregion

        #region API

        public void Insert(T value)
        {
            if (ReferenceEquals(value, null))
            {
                throw new ArgumentNullException(nameof(value));
            }

            Node<T> node = new Node<T>(value);
            if (ReferenceEquals(root, null))
            {
                root = node;
                return;
            }

            AddRecursively(root, node);
        }

        public IEnumerable<T> Preorder()
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            return PreOrder(root);
        }

        public IEnumerable<T> InOrder()
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            return InOrder(root);
        }

        public IEnumerable<T> PostOrder()
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            return PostOrder(root);
        }

        #endregion

        #region Private methods

        private void AddRecursively(Node<T> currentNode, Node<T> addingNode)
        {
            if (ReferenceEquals(addingNode, null))
            {
                throw new ArgumentNullException(nameof(addingNode));
            }
            
            if (comparer.Compare(currentNode.Value, addingNode.Value) < 0)
            {
                if (ReferenceEquals(currentNode.left, null))
                {
                    currentNode.left = addingNode;
                }
                else
                {
                    AddRecursively(currentNode.left, addingNode);
                }
            }
            else if(comparer.Compare(currentNode.Value,addingNode.Value) > 0)
            {
                if (ReferenceEquals(currentNode.right, null))
                {
                    currentNode.right = addingNode;
                }
                else
                {
                    AddRecursively(currentNode.right, addingNode);
                }
            }
            else if (comparer.Compare(currentNode.Value, addingNode.Value) == 0)
            {
                currentNode.countNode++;
            }
        }

        private IEnumerable<T> PreOrder(Node<T> current)
        {
            if (ReferenceEquals(current, null))
            {
                yield return current.Value;
            }
            else
            {
                yield break;
            }

            foreach (T node in PreOrder(current.left))
            {
                yield return node;
            }

            foreach (T node in PreOrder(current.right))
            {
                yield return node;
            }
        }

        private IEnumerable<T> InOrder(Node<T> current)
        {
            if (ReferenceEquals(current, null))
            {
                yield break;
            }

            if (current.left != null)
            {
                foreach (T node in InOrder(current.left))
                {
                    yield return node;
                }
            }

            yield return current.Value;

            if (current.right != null)
            {
                foreach (T node in InOrder(current.right))
                {
                    yield return node;
                }
            }
        }

        private IEnumerable<T> PostOrder(Node<T> current)
        {
            if (ReferenceEquals(current, null))
            {
                yield break;
            }

            if (ReferenceEquals(current.left, null))
            {
                foreach (var node in PostOrder(current.left))
                {
                    yield return node;
                }
            }

            if (ReferenceEquals(current.right, null))
            {
                foreach (var node in PostOrder(current.right))
                {
                    yield return node;
                }
            }

            yield return current.Value;
        }

        #endregion
    }
}
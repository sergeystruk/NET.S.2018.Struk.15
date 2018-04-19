using System;
using System.Collections.Generic;

namespace BinaryAlgorithm
{
    /// <summary>
    /// Provides static method for binary search
    /// </summary>
    public static class FindUtil
    {
        /// <summary>
        /// Binary search for sorted array
        /// </summary>
        /// <typeparam name="T">
        /// Type of elements in array
        /// </typeparam>
        /// <param name="array">
        /// Array for search
        /// </param>
        /// <param name="value">
        /// value to search
        /// </param>
        /// <returns>
        /// Index of element in array(or -1 if value doesn't exist in array)
        /// </returns>
        public static int BinarySearch<T>(T[] array, T value, Comparison<T> comparison)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (comparison == null)
            {
                if (array[0] is IComparable || array[0] is IComparable<T>)
                {
                    comparison = Comparer<T>.Default.Compare;
                }
                else
                {
                    throw new ArgumentNullException(nameof(comparison));
                }
            }

            return BinarySearch<T>(array, value, 0, array.Length - 1, comparison);
        }

        /// <summary>
        /// Binary search for sorted array
        /// </summary>
        /// <typeparam name="T">
        /// Type of elements in array
        /// </typeparam>
        /// <param name="array">
        /// Array for search
        /// </param>
        /// <param name="value">
        /// value to search
        /// </param>
        /// <returns>
        /// Index of element in array(or -1 if value doesn't exist in array)
        /// </returns>
        public static int BinarySearch<T>(T[] array, T value, IComparer<T> comparer)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (comparer == null)
            {
                if (array[0] is IComparer<T> || array[0] is IComparer<T>)
                {
                    comparer = Comparer<T>.Default;
                }
                else
                {
                    throw new ArgumentNullException(nameof(comparer));
                }
            }
            
            return BinarySearch<T>(array, value, 0, array.Length - 1, comparer.Compare);
        }

        /// <summary>
        /// Logic for binary seach for sorted array
        /// </summary>
        /// <typeparam name="T">
        /// Type of elements in array
        /// </typeparam>
        /// <param name="array">
        /// Array for search
        /// </param>
        /// <param name="value">
        /// value to search
        /// </param>
        /// <param name="left">
        /// Left index of array to search
        /// </param>
        /// <param name="right">
        /// Right index of array to search
        /// </param>
        /// <returns>
        /// Index of element in array(or -1 if value doesn't exist in array)
        /// </returns>
        private static int BinarySearch<T>(T[] array, T value, int left, int right, Comparison<T> comparison)
        {
            int mid = left + (right - left) / 2;

            if (left >= right)
            {
                return -1;
            }

            if (comparison(array[mid], value) == 0)
            {
                return mid;
            }

            if (comparison(array[mid], value) > 0)
            {
                return BinarySearch(array, value, left, mid, comparison);
            }

            return BinarySearch(array, value, mid + 1, right, comparison);
        }
    }
}

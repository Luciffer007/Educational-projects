using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortLibrary
{
    public static class SortingAlgorithms
    {
        public enum SortingDirection {Asc = 1, Desc = 2};

        public static double[] BubbleSort(double[] array, SortingDirection direction)
        {
            // A comparison cycle of the i-th element with subsequent elements of the array.
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    // Sort the elements of the array in ascending or descending order depending on the selected sorting direction.
                    switch ((int)direction)
                    {
                        case 1:
                            // If the i-th element of the array is greater than the j-th element.
                            if (array[i] > array[j])
                            {
                                // Swap elements which passed order condition.
                                double temp = array[i];
                                array[i] = array[j];
                                array[j] = temp;
                            }
                            break;

                        case 2:
                            // If the i-th element of the array is less than the j-th element.
                            if (array[i] < array[j])
                            {
                                // Swap elements which passed order condition.
                                double temp = array[i];
                                array[i] = array[j];
                                array[j] = temp;
                            }
                            break;
                    }
                }
            }
            return array;
        }

        public static double[] QuickSort(double[] array, int firstElement, int lastElement)
        {
            // Selecting a supporting element.
            double supportingElemnt = array[(lastElement - firstElement) / 2 + firstElement];
            // Assignment to variable indices of the beginning and end of a sortable array (subarray)
            int i = firstElement;
            int j = lastElement;

            // Checking the correctness of the entered data.
            if (firstElement < 0 || firstElement > array.Length || lastElement < 0 || lastElement > array.Length)
            {
                Console.WriteLine("Incorrect data entered. Sorting is not possible.");
                return array;
            }

            while (i <= j)
            {
                // The search for an array element is less than the supporting element.
                while (array[i] < supportingElemnt && i <= lastElement) i++;

                // The search for an array element is greater than the supporting element.
                while (array[j] > supportingElemnt && j >= firstElement) j--;

                // Swap the element less than the supporting element and the element is greater than the supporting element.
                if (i <= j)
                {
                    double temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;

                }

            }

            // Calling the sort method for subarrays.
            if (i < lastElement) QuickSort(array, i, lastElement);
            if (j > firstElement) QuickSort(array, firstElement, j);

            return array;
        }

    }
}

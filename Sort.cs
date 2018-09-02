using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortLibrary
{
    public static class SortingAlgorithms
    {

        public static double[] BubbleSort(double[] array)
        {
            // A comparison cycle of the i-th element with subsequent elements of the array.
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    // If the i-th element of the array is greater than the j-th element...
                    if (array[i] > array[j])
                    {
                        // swap them.
                        double temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
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

            while (i <= j)
            {
                // The search for an array element is less than the supporting element.
                while (array[i] < supportingElemnt && i <= lastElement) i++;

                // The search for an array element is greater than the supporting element.
                while (array[j] > supportingElemnt && j >= firstElement) j--;

                // Swap elements.
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortLibrary
{
    public static class Sort
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
                        double temp;

                        // swap them.
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }

                }
            }
            return array;
        }

    }
}

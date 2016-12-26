using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class MergeSortClass
    {
        public static void MergeSort(int[] numbers, int left, int right)
        {
            int middle;

            if (right > left)
            {
                middle = (right + left) / 2;
                MergeSort(numbers, left, middle);
                MergeSort(numbers, middle + 1, right);

                DoMerge(numbers, left, (middle + 1), right);
            }
        }

        public static void DoMerge(int[] numbers, int left, int mid, int right)
        {
            int[] temp = new int[10];
            int i, left_end, num_elements, tmp_pos;

            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);

            while ((left <= left_end) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                    temp[tmp_pos++] = numbers[left++];
                else
                    temp[tmp_pos++] = numbers[mid++];
            }

            while (left <= left_end)
                temp[tmp_pos++] = numbers[left++];

            while (mid <= right)
                temp[tmp_pos++] = numbers[mid++];

            for (i = 0; i < num_elements; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }
    }
}

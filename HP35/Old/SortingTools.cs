using System.Security.AccessControl;

namespace HP35;

public static class SortingTools
{
    public static void selection_sort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int candidate = i;
            for (int j = i+1; j < array.Length; j++)
            {
                if (array[j] < array[candidate]) candidate = j;
            }

            if (candidate != i)
            {
                (array[i], array[candidate]) = (array[candidate], array[i]);
            }
        }
    }

    public static void insertion_sort(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            int key = array[i];
            int j;
            for (j = i - 1; j >= 0; j--)
            {
                if (key < array[j])
                {
                    array[j + 1] = array[j];
                }
                else
                {
                    break;
                }
            }
            array[j + 1] = key;
        }
    }

    public static void merge_sort(int[] array)
    {
        if (array.Length < 2)
        {
            return;
        }
        int[] temp = new int[array.Length];
        merge_sort(array, temp, 0,array.Length-1);
    }

    private static void merge_sort(int[] array, int[] temp, int left, int right)
    {
        if (left >= right)
        {
            return;
        }

        int mid = (left + right) / 2;
        merge_sort(array, temp, left, mid);
        merge_sort(array, temp, mid + 1, right);
        merge(array, temp, left, right);
    }

    private static void merge(int[] array, int[] temp, int left, int right)
    {
        int length = right - left + 1;
        int leftIndex = left;
        int index = left;
        int leftEnd = (right + left) / 2;
        int rightIndex = leftEnd + 1;
        int rightEnd = right;

        for (int i = 0; i < length; i++)
        {
            if (leftIndex <= leftEnd && rightIndex <= rightEnd)
            {
                if (array[leftIndex] < array[rightIndex])
                {
                    temp[index] = array[leftIndex];
                    index++;
                    leftIndex++;
                }
                else
                {
                    temp[index] = array[rightIndex];
                    index++;
                    rightIndex++;
                }
            }
            else
            {
                while (leftIndex <= leftEnd)
                {
                    temp[index] = array[leftIndex];
                    index++;
                    leftIndex++;
                }  
                
                while (rightIndex <= rightEnd)
                {
                    temp[index] = array[rightIndex];
                    index++;
                    rightIndex++;
                }

                break;
            }
        }
        
        Array.Copy(temp, left, array, left, length);
    }

    public static void quicksort(int[] array)
    {
        quicksort(array, 0, array.Length-1);
    }

    private static void quicksort(int[] array, int left, int right)
    {
        if (left >= right)
            return;
        int pivot = left + (right - left) / 2;
        partition(array, pivot, left, right);
        ArrayTools.print_array(array);
        quicksort(array, pivot, right);
        quicksort(array, left, pivot-1);
    }

    private static void partition(int[] array, int pivot, int left, int right)
    {
        int pivot_value = array[pivot];
        while (left < right)
        {
            while (array[left] < pivot_value)
            {
                left++;
            }

            while (array[right] > pivot_value)
            {
                right--;
            }

            if (left < right)
            {
                //Swap elements
                (array[left], array[right]) = (array[right], array[left]);
                left++;
                right--;
            }
        }
    }
}
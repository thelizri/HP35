namespace HP35;

public class SearchTools
{
    public SearchTools()
    {
    }

    public bool search_unsorted(int[] array, int key)
    {
        for (int index = 0; index < array.Length; index++)
        {
            if (array[index] == key) return true;
        }

        return false;
    }
    

    public bool binary_search(int[] array, int key)
    {
        int first = 0;
        int last = array.Length - 1;

        while (true)
        {
            int index = (first + last) / 2;

            if (array[index] == key)
            {
                return true;
            }
            else if (key<array[index]&&index<last)
            {
                last = index-1;
            }
            else if (key>array[index]&&index>first)
            {
                first = index+1;
            }
            else
            {
                if (array[first] == key || array[last] == key) return true;
                return false;
            }
        }
    }

    public int[] duplicate_search(int[] array1, int[] array2)
    {
        List<int> result = new List<int>();
        int indexOfFirstArray = 0;
        int indexOfSecondArray = 0;

        while (indexOfFirstArray<array1.Length && indexOfSecondArray<array2.Length)
        {
            if (array1[indexOfFirstArray] == array2[indexOfSecondArray])
            {
                result.Add(array1[indexOfFirstArray]);
                indexOfFirstArray++;
                indexOfSecondArray++;
            }
            else if (array1[indexOfFirstArray] > array2[indexOfSecondArray])
            {
                indexOfSecondArray++;
            }
            else
            {
                indexOfFirstArray++;
            }
        }
        
        return result.ToArray();
    }

    public int[] linear_search(int[] array1, int[] array2)
    {
        List<int> result = new List<int>();
        for (int i = 0; i < array1.Length; i++)
        {
            for (int j = 0; j < array2.Length; j++)
            {
                if (array1[i] == array2[j])
                {
                    result.Add(array1[i]);
                }
            }
        }

        return result.ToArray();
    }

    public int[] binary_search(int[] array1, int[] array2)
    {
        List<int> result = new List<int>();
        for (int i = 0; i < array1.Length; i++)
        {
            int key = array1[i];
            int first = 0;
            int last = array2.Length - 1;

            while (true)
            {
                int index = (first + last) / 2;

                if (array2[index] == key)
                {
                    result.Add(key);
                    break;
                }
                else if (key<array2[index]&&index<last)
                {
                    last = index;
                }
                else if (key>array2[index]&&index>first)
                {
                    first = index;
                }
                else
                {
                    if (array2[first] == key || array2[last] == key)
                    {
                        result.Add(key);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        return result.ToArray();
    }
}
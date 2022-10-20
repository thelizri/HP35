namespace HP35.Current.Hash;

public class Main
{
    static int[] rarray(int size)
    {
        int[] result = new int[size];
        Random random = new Random();
        for (int i = 0; i < size; i++)
        {
            result[i] = random.Next(11111, 99999);
        }

        return result;
    }

    static void benchmark()
    {
        var zip = new ZipOpenAddressing("postnummer.csv", 14616);
        int size = 100000;
        var array = rarray(size);
        for (int i = 0; i < size; i++)
        {
            zip.lookup(array[i]);
        }
        Console.WriteLine((double)zip.sum/size);
    }
}
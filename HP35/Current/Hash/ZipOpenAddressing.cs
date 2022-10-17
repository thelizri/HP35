using System.Text;

namespace HP35.Current.Hash;

public class ZipOpenAddressing
{
    private Node[] data;
    private readonly string fileAddress;
    private readonly int modulo;
    private int numberOfAddresses;
    public int collisions;
    private int max;
    private int min;

    private class Node
    {
        public int zipCode;
        public String cityName;
        public int key;
        public int collisions;

        public Node(int zipCode, string cityName, int key)
        {
            this.zipCode = zipCode;
            this.cityName = cityName;
            this.key = key;
            this.collisions = 1;
        }

        public override string ToString()
        {
            return $"{zipCode}, {cityName}, {key}";
        }
        
    }

    public ZipOpenAddressing(string file, int modulo)
    {
        fileAddress = Path.GetFullPath(file);
        this.modulo = modulo;
        max = Int32.MinValue;
        min = Int32.MaxValue;
        read();
    }

    private void read()
    {
        if (!File.Exists(fileAddress))
        {
            Console.WriteLine("File does not exist");
            return;
        }
        string[] lines = File.ReadAllLines(fileAddress);
        this.data = new Node[modulo];
        numberOfAddresses = lines.Length;
        int total = 0;
        foreach (string line in lines)
        {
            string[] row = line.Split(',');
            int index = this.index(zipCode(row[0]));
            if (data[index] is null)
            {
                data[index] = new Node(zipCode(row[0]), row[1].Trim(), Int32.Parse(row[2]));
            }
            else
            {
                while (data[index] is not null)
                {
                    index++;
                    index %= modulo;
                }
                data[index]= new Node(zipCode(row[0]), row[1].Trim(), Int32.Parse(row[2]));
            }

            min = Math.Min(zipCode(row[0]), min);
            max = Math.Max(zipCode(row[0]), max);
        }
        this.collisions = total;
        Console.WriteLine("Max: "+max);
        Console.WriteLine("Min: "+min);
    }

    public void getCollisions()
    {
        int max = 0;
        foreach (var node in data)
        {
            if (node is null) continue;
            max = Math.Max(max, node.collisions);
        }

        int[] collision_array = new int[max + 1];
        
        foreach (var node in data)
        {
            if (node is null) continue;
            collision_array[node.collisions]++;
        }
        for (int i = 2; i < collision_array.Length; i++)
        {
            if(collision_array[i]==0) continue;
            Console.WriteLine("{0} keys map to the same index occurances: {1}",i,collision_array[i]);
        }
    }

    public string lookup(int zip)
    {
        var index = this.index(zip);
        if (data[index] is null)
            return "No such address";

        var i = 0;
        while (data[index] is not null && zip != data[index].zipCode && i < modulo)
        {
            index++;
            index %= modulo;
            i++;
        }

        if (data[index] is not null && zip == data[index].zipCode) 
            return data[index].ToString();
        return "No such address";
    }

    private int index(int zip)
    {
        int index = zip % modulo;
        return index;
    }

    private int zipCode(string zip)
    {
        return Int32.Parse(zip.Replace(" ",""));
    }

    public int getAmountOfAddresses()
    {
        return numberOfAddresses;
    }
}
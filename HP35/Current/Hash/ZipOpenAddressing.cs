using System.Text;

namespace HP35.Current.Hash;

public class ZipOpenAddressing
{
    private Node[] data;
    private readonly string fileAddress;
    private readonly int modulo;
    private int numberOfAddresses;
    public int sum;

    private class Node
    {
        public int zipCode;
        public String cityName;
        public int population;

        public Node(int zipCode, string cityName, int population)
        {
            this.zipCode = zipCode;
            this.cityName = cityName;
            this.population = population;
        }

        public override string ToString()
        {
            return $"{zipCode}, {cityName}, {population}";
        }
        
    }

    public ZipOpenAddressing(string file, int modulo)
    {
        fileAddress = Path.GetFullPath(file);
        this.modulo = modulo;
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

        sum += (i + 1);
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
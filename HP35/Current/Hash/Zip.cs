namespace HP35.Current.Hash;

public class Zip
{
    private Node[] data;
    private readonly string fileAddress;

    private class Node
    {
        public String zipCode;
        public String cityName;
        public int key;

        public Node(string zipCode, string cityName, int key)
        {
            this.zipCode = zipCode;
            this.cityName = cityName;
            this.key = key;
        }

        public override string ToString()
        {
            return $"{zipCode}, {cityName}, {key}";
        }

        public int getZipCode()
        {
            return Int32.Parse(this.zipCode.Replace(" ",""));
        }
    }

    public Zip(string file)
    {
        fileAddress = Path.GetFullPath(file);
        Console.WriteLine(fileAddress);
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
        int i = 0;
        this.data = new Node[lines.Length];
        foreach (string line in lines)
        {
            string[] row = line.Split(',');
            data[i++] = new Node(row[0], row[1].Trim(), Int32.Parse(row[2]));
        }
    }

    public string linearSearch(string zipCode)
    {
        for (int i = 0; i < data.Length; i++)
        {
            if (zipCode.Equals(data[i].zipCode)) return data[i].ToString();
        }

        return "No results";
    }
    
    public string binary_search(int zipSearch)
    {
        int first = 0;
        int last = data.Length - 1;

        while (true)
        {
            int index = (first + last) / 2;
            string zipCode = data[index].zipCode;
            int zip = Int32.Parse(zipCode.Replace(" ",""));

            if (zip == zipSearch)
            {
                return data[index].ToString();
            }
            else if (zipSearch<zip&&index<last)
            {
                last = index-1;
            }
            else if (zipSearch>zip&&index>first)
            {
                first = index+1;
            }
            else
            {
                if (data[first].key == zipSearch)
                {
                    return data[first].ToString();
                }
                if (data[last].key == zipSearch)
                {
                    return data[last].ToString();
                }
                
            }
        }
    }
}
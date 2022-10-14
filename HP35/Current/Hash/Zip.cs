namespace HP35.Current.Hash;

public class Zip
{
    private Node[] data;
    private readonly string fileAddress;
    private readonly string directory;

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
    }

    public Zip(string file)
    {
        this.data = new Node[10000];
        this.directory = "C:\\Users\\karlw\\Documents\\Code\\C#\\HP35\\HP35\\Current\\Hash\\";
        this.fileAddress = directory + file;
        read();
    }

    private void read()
    {
        if (!File.Exists(fileAddress)) return;
        string[] lines = File.ReadAllLines(fileAddress);
        int i = 0;
        foreach (string line in lines)
        {
            string[] row = line.Split(',');
            data[i++] = new Node(row[0], row[1].Trim(), Int32.Parse(row[2]));
        }
    }

    public string search(string zipCode)
    {
        for (int i = 0; i < data.Length; i++)
        {
            if (zipCode.Equals(data[i].zipCode)) return data[i].ToString();
        }

        return "No results";
    }
}
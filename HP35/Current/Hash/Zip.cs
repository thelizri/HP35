namespace HP35.Current.Hash;

public class Zip
{
    private Node[] data;
    private readonly string fileAddress;
    private readonly string directory;

    private class Node
    {
        private String code;
        private String name;
        private int pop;

        public Node(string code, string name, int pop)
        {
            this.code = code;
            this.name = name;
            this.pop = pop;
        }
    }

    public Zip(string file)
    {
        this.data = new Node[10000];
        this.directory = "C:\\Users\\karlw\\Documents\\Code\\C#\\HP35\\HP35\\Current\\Hash\\";
        this.fileAddress = directory + file;
    }

    public void read()
    {
        if (!File.Exists(fileAddress)) return;
        string[] lines = File.ReadAllLines(fileAddress);
        int i = 0;
        foreach (string line in lines)
        {
            string[] row = line.Split(' ');
            Console.WriteLine($"First: {row[0]}, Second: {row[1]}, Third: {row[2]},");
            data[i++] = new Node(row[0], row[1], Int32.Parse(row[2]));
        }
    }
}
using System.Text;

namespace HP35;

public class Latex
{
    private string table_upper;

    private string table_bottom;

    private List<string> info;

    public Latex()
    {
        table_upper = "\\begin{table}[h]\n" +
                      "\\centering\n" +
                      "\\begin{tabular}{|l|l|l|l|}\n" +
                      "\\hline\n" +
                      "\\textbf{n} & \\multicolumn{1}{c|}{\\textbf{Mean}} &\n" +
                      "\\multicolumn{1}{c|}{\\textbf{Min}} &\n" +
                      "\\multicolumn{1}{c|}{\\textbf{Max}} \\\\ \\hline";
        
        table_bottom = "\\end{tabular}\n" +
                       "\\caption{}\n" +
                       "\\label{tab:my-table}\n" +
                       "\\end{table}";
        info = new List<string>();
    }

    public void addLine(int n, double mean, double min, double max)
    {
        string data = String.Format("{0} & {1} & {2} & {3} \\\\ \\hline", n,
            return_two_sigfigs(mean), return_two_sigfigs(min), return_two_sigfigs(max));
        info.Add(data);
    }

    public void print()
    {
        Console.WriteLine("\nLatex table\n");
        Console.WriteLine(table_upper);
        foreach (string x in info)
        {
            Console.WriteLine(x);
        }
        Console.WriteLine(table_bottom);
    }

    private int return_two_sigfigs(double number)
    {
        int n = (int) Math.Round(number);
        StringBuilder numberString = new StringBuilder(n.ToString());
        if (numberString.Length<=2)
        {
            return n;
        }
        else
        {
            char c = numberString[2];
            int x = (int) Char.GetNumericValue(c);
            if (x < 5)
            {
                int length = numberString.Length - 2;
                numberString.Remove(2, length);
                numberString.Append('0', length);
                return Int32.Parse(numberString.ToString());
            }
            else
            {
                int length = numberString.Length - 2;
                numberString.Remove(2, length);
                numberString.Append('0', length);
                int numberResult = Int32.Parse(numberString.ToString());
                int sum = 1;
                for (int i = 0; i < length; i++)
                {
                    sum *= 10;
                }

                numberResult += sum;
                return numberResult;
            }
        }
    }
}
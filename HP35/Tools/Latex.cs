using System.Text;
using Microsoft.VisualBasic;

namespace HP35;

public static class Latex
{
    private static string table_upper= "\\begin{table}[h]\n" +
                                       "\\centering\n" +
                                       "\\begin{tabular}{|l|l|l|l|}\n" +
                                       "\\hline\n" +
                                       "\\textbf{n} & \\multicolumn{1}{c|}{\\textbf{Mean}} &\n" +
                                       "\\multicolumn{1}{c|}{\\textbf{Min}} &\n" +
                                       "\\multicolumn{1}{c|}{\\textbf{Max}} \\\\ \\hline";

    private static string table_bottom = "\\end{tabular}\n" +
                                         "\\caption{}\n" +
                                         "\\label{tab:my-table}\n" +
                                         "\\end{table}";

    private static List<string> info = new List<string>();
    private static List<string> just_numbers = new List<string>();
    private static List<string> left_columns = new List<string>();
    private static List<string> right_columns = new List<string>();
    private static List<string> left_columns_numbers = new List<string>();
    private static List<string> right_columns_numbers = new List<string>();

    public static void addLine(int n, double mean, double min, double max, bool sigfigs)
    {
        if (sigfigs)
        {
            int tmean = return_two_sigfigs(mean);
            int tmin = return_two_sigfigs(min);
            int tmax = return_two_sigfigs(max);
            string data = String.Format("{0} & {1} & {2} & {3} \\\\ \\hline", n,
                tmean, tmin, tmax);
            info.Add(data);
            data = String.Format("{0} {1} {2} {3}", n,
                tmean, tmin, tmax);
            just_numbers.Add(data);
        }
        else
        {
            string data = String.Format("{0:0.##} & {1:0.##} & {2:0.##} & {3:0.##}\\\\ \\hline", n,
                mean,  min, max);
            info.Add(data);
            data = String.Format("{0:0.##} {1:0.##} {2:0.##} {3:0.##}", n,
                mean,  min, max);
            just_numbers.Add(data);
        }
    }
    
    public static void addLine(int n, double mean, double min, double max, double difference)
    {
        string data = String.Format("{0:0.##} & {1:0.##} & {2:0.##} & {3:0.##} & {4:0.##}\\\\ \\hline", n,
            mean, difference, min, max);
        info.Add(data);
        data = String.Format("{0:0.##} {1:0.##} {2:0.##} {3:0.##} {4:0.##}", n,
            mean, difference, min, max);
        just_numbers.Add(data);
    }

    public static void leftColumns(int n, double mean, double difference)
    {
        string data = String.Format("{0:0.##} & {1:0.##} & {2:0.##} &",n,mean,difference);
        left_columns.Add(data);
    }

    public static void rightColumns(double mean, double difference)
    {
        string data = String.Format("{0:0.##} & {1:0.##}\\\\ \\hline",mean,difference);
        right_columns.Add(data);
    }

    public static void printComparison()
    {
        Console.WriteLine(table_upper);
        for (int i = 0; i < left_columns.Count; i++)
        {
            string s = left_columns[i] + right_columns[i];
            Console.WriteLine(s);
        }
        Console.WriteLine(table_bottom);
    }
    
    public static void print()
    {
        Console.WriteLine("\nLatex table\n");
        Console.WriteLine(table_upper);
        foreach (string x in info)
        {
            Console.WriteLine(x);
        }
        Console.WriteLine(table_bottom);
        
        Console.WriteLine("\n\n\nOnly numbers\n");
        Console.WriteLine("n mean min max");
        foreach (string x in just_numbers)
        {
            Console.WriteLine(x);
        }
    }
    
    private static int return_two_sigfigs(double number)
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
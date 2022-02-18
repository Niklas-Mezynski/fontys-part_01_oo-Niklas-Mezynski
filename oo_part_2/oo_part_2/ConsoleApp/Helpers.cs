namespace oo_part_1.Entities;

public class Helpers
{
    public static int ReadIntFromConsole()
    {
        while (true)
        {
            string? s = Console.ReadLine();
            var i = 0;
            if (Int32.TryParse(s, out i))
            {
                return i;
                break;
            }
            else
            {
                Console.WriteLine("Please enter a valid integer value");
            }
        }
    }
        
    public static double ReadDoubleFromConsole()
    {
        while (true)
        {
            string? s = Console.ReadLine();
            double i = 0;
            if (double.TryParse(s, out i))
            {
                return i;
                break;
            }
            else
            {
                Console.WriteLine("Please enter a valid double value");
            }
        }
    }

    public static DateOnly ReadDateOnlyFromConsole()
    {
        while (true)
        {
            string? s = Console.ReadLine();
            DateOnly date;
            if (DateOnly.TryParseExact(s,"yyyy-MM-dd", out date))
            {
                return date;
                break;
            }
            else
            {
                Console.WriteLine("Please enter a valid date please [YYYY-MM-DD]");
            }
        }
    }
}
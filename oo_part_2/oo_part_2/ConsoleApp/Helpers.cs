namespace oo_part_1.Entities;

public class Helpers
{
    public static readonly Dictionary<Type, Func<string, Object>> typeParser = new()
    {
        {typeof(int), s => int.Parse(s)},
        {typeof(DateOnly), s => DateOnly.Parse(s)},
        {typeof(double), s => double.Parse(s)},
    };
    
    //List of all types of users
    public static IEnumerable<Type> userTypes = AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(s => s.GetTypes())
        .Where(p => typeof(IUser).IsAssignableFrom(p) && !p.IsInterface);

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
            if (DateOnly.TryParseExact(s, "yyyy-MM-dd", out date))
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
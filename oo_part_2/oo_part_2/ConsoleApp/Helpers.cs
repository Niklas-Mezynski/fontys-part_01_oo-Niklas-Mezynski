using oo_part_2.Persistence;

namespace oo_part_1.Entities;

public class Helpers
{
    public static readonly Dictionary<Type, Func<string, Object>> typeParser = new()
    {
        {typeof(int), s => int.Parse(s)},
        {typeof(DateOnly), s => DateOnly.Parse(s)},
        {typeof(double), s => double.Parse(s)},
        {typeof(Email), Email.Parse},
    };
    
    //List of all types of users
    public static IEnumerable<Type> userTypes = AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(s => s.GetTypes())
        .Where(p => typeof(IUser).IsAssignableFrom(p) && !p.IsInterface);
    
    public static IEnumerable<Type> factoryTypes = AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(s => s.GetTypes())
        .Where(p => typeof(IDbFactory).IsAssignableFrom(p) && !p.IsInterface);

    public static int ReadIntFromConsole()
    {
        while (true)
        {
            string? s = Console.ReadLine();
            int i;
            if (Int32.TryParse(s, out i))
            {
                return i;
            }
            Console.WriteLine("Please enter a valid integer value");
        }
    }
}
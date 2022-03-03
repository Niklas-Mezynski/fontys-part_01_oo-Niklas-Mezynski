using oo_part_1.Entities;
using oo_part_2.Persistence;

namespace oo_part_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Starting the console simulation
            Console.WriteLine("Starting program");
            var abstractDbFactory = new AbstractDBFactory();
            var consoleSimulation = new ConsoleSimulation(abstractDbFactory);
            consoleSimulation.StartSimulation();
        }
    }
}
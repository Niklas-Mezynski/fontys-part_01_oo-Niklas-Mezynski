using oo_part_1.Entities;
using oo_part_2.Persistence;

namespace oo_part_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting program");
            var abstractDbFactory = new AbstractDBFactory();
            var consoleSimulation = new ConsoleSimulation(abstractDbFactory);
            consoleSimulation.StartSimulation();
            // var xmlPersistence = new XMLPersistence();
            // var student = new Student(xmlPersistence.GetNextId(), "Felix", "Pralle", "pralle@gmail.com", "deutsch", "Fontys", "7", "SE");
            // xmlPersistence.AddUser(student);
            // var allUsers = xmlPersistence.GetAllUsers();
            // allUsers.ForEach(user => Console.WriteLine("------\n" + user.GetDetailedStringRepresentation()));
            // Console.Out.WriteLine("Completed");
        }
    }
}
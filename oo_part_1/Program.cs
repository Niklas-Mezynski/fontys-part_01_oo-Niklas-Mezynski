using System;
using oo_part_1.App;

namespace oo_part_1
{
    internal class Program
    {
        private static ConsoleSimulation simulation = new ConsoleSimulation();
        
        public static void Main(string[] args)
        {
            Console.Out.WriteLine("Starting program");
            simulation.startSimulation();
        }
        
        public static VehicleManager GetVehicleManager() {
            return simulation.GetVehicleManager();
        }
    }
    
     
}
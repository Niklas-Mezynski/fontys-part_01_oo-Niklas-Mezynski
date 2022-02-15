using System;

namespace oo_part_1.App
{
    public class ConsoleSimulation
    {
        private VehicleManager manager;

        public ConsoleSimulation()
        {
            manager = new VehicleManager();
        }

        public void startSimulation()
        {
            while (true)
            {
                Console.WriteLine("\nWhich action do you want to perform? Enter the number please\n" +
                                  "0 - exit\n" +
                                  "1 - Add a car\n" +
                                  "2 - print all cars\n" +
                                  "3 - get the number of vehicles\n" +
                                  "4 - get the price of all vehicles\n" +
                                  "5 - increase the price of all vehicles\n" +
                                  "6 - search a vehicle by ID\n" +
                                  "7 - search a vehicle by licence plate");
                int action = readIntFromConsole();

                switch (action)
                {
                    case 1:
                        addCar();
                        break;
                    case 2:
                        manager.printAllVehicles();
                        break;
                    case 3:
                        Console.Out.WriteLine("The total No of vehicles in Stock: " + manager.getNumberOfVehicles());
                        break;
                    case 4:
                        Console.Out.WriteLine("The total price of all vehicles is: " + manager.getTotalPriceOfVehicles());
                        break;
                    case 5:
                        Console.Out.WriteLine("Enter the percentage amount by which u wanna increase the prices: ");
                        manager.increasePriceOfAllVehicles(readIntFromConsole());
                        break;
                    case 6:
                        Console.Out.WriteLine("Enter the ID of the vehicle you search: ");
                        var vehicle = manager.searchVehicleById(readIntFromConsole());
                        Console.Out.WriteLine(vehicle);
                        break;
                    case 7:
                        Console.Out.WriteLine("Enter the licence plate of the vehicle you search: ");
                        var vehicle2 = manager.searchVehicleByLicencePlate(Console.ReadLine());
                        Console.Out.WriteLine(vehicle2);
                        break;
                    default:
                        action = 0;
                        break;
                }
                
                if (action == 0)
                {
                    break;
                }
                
            }

            Console.WriteLine("End of program");
        }

        public VehicleManager GetVehicleManager()
        {
            return manager;
        }

        private void addCar()
        {
            Console.Out.WriteLine("Which type of car do you want to add? (Default car)\n" +
                                  "1 - Car\n" +
                                  "2 - Truck\n" +
                                  "3 - Motorcycle");
            int type = readIntFromConsole();
            
            Console.Out.WriteLine("Enter a price:");
            double price = readDoubleFromConsole();

            Console.Out.WriteLine("Enter the licence plate:");
            string licence = Console.ReadLine();
            
            Console.Out.WriteLine("Enter the top speed (in km/h):");
            int topSpeed = readIntFromConsole();
            
            switch (type)
            {
                case 2:
                    Console.Out.WriteLine("Enter a max weight for the trailer (in kg):");
                    int maxWeight = readIntFromConsole();
                    Vehicle truck = manager.addTruck(price, licence, topSpeed, maxWeight);
                    Console.Out.WriteLine("Truck created successfully!");
                    Console.Out.WriteLine(truck.ToString());
                    break;
                case 3:
                    Console.Out.WriteLine("Enter the level of coolness of the motorcycle:");
                    int coolness = readIntFromConsole();
                    Vehicle mc = manager.addMotorcycle(price, licence, topSpeed, coolness);
                    Console.Out.WriteLine("Motorcycle created successfully!");
                    Console.Out.WriteLine(mc.ToString());
                    break;
                default:
                    Console.Out.WriteLine("Enter the number of seats:");
                    int seats = readIntFromConsole();
                    Vehicle car = manager.addCar(price, licence, topSpeed, seats);
                    Console.Out.WriteLine("Car created successfully!");
                    Console.Out.WriteLine(car.ToString());
                    break;
            }
        }

        private int readIntFromConsole()
        {
            int i = 0;
            while (true)
            {
                string s = Console.ReadLine();
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
        
        private double readDoubleFromConsole()
        {
            double i = 0;
            while (true)
            {
                string s = Console.ReadLine();
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
    }
    
}
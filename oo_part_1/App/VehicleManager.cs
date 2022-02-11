using System;
using System.Collections.Generic;

namespace oo_part_1.App
{
    public class VehicleManager
    {
        private List<Vehicle> vehicles;
        private int nextId;

        public VehicleManager()
        {
            this.vehicles = new List<Vehicle>();
        }

        public void printAllVehicles()
        {
            foreach (Vehicle vehicle in vehicles)
            {
                Console.Out.WriteLine(vehicle.ToString());
            }
        }

        public void addVehicle(Vehicle vehicle)
        {
            this.vehicles.Add(vehicle);
        }

        public void increasePriceOfAllVehicles(double perc)
        {
            foreach (var vehicle in vehicles)
            {
                vehicle.increasePricePerc(perc);
            }
        }

        public int getNumberOfVehicles()
        {
            return vehicles.Count;
        }
        
        public double getTotalPriceOfVehicles()
        {
            double sum = 0;
            foreach (var vehicle in vehicles)
            {
                sum += vehicle.Price;
            }
            return sum;
        }

        public Vehicle searchVehicleById(int id)
        {
            Vehicle vehicle = null;
            foreach (var vehicle1 in vehicles)
            {
                if (vehicle1.Id == id)
                    vehicle = vehicle1;
            }
            return vehicle;
        }
        
        public Vehicle searchVehicleByLicencePlate(String plate)
        {
            Vehicle vehicle = null;
            foreach (var vehicle1 in vehicles)
            {
                if (vehicle1.LicencePlate.ToLower().Trim().Equals(plate.ToLower().Trim()))
                    vehicle = vehicle1;
            }
            return vehicle;
        }

        public Vehicle addCar(double price, string licencePlate, int topSpeed, int noOfSeatsVehicle)
        {
            var car = new Car(price, licencePlate, topSpeed, noOfSeatsVehicle);
            vehicles.Add(car);
            return car;
        }
        
        public Vehicle addTruck(double price, string licencePlate, int topSpeed, int maxTrailerWeight)
        {
            var vehicle = new Truck(price, licencePlate, topSpeed, maxTrailerWeight);
            vehicles.Add(vehicle);
            return vehicle;
        }
        
        public Vehicle addMotorcycle(double price, string licencePlate, int topSpeed, int coolness)
        {
            var motorcycle = new Motorcycle(price, licencePlate, topSpeed, coolness);
            vehicles.Add(motorcycle);
            return motorcycle;
        }

        public int GetNextId()
        {
            int maxId = 0;
            foreach (var vehicle in vehicles)
            {
                if (vehicle.Id > maxId)
                    maxId = vehicle.Id;
            }
            return maxId++;
        }
    }
}
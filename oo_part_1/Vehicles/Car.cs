using System;

namespace oo_part_1
{
    public class Car : Vehicle
    {
        private int noOfSeats;
        public Car(double price, string licencePlate, int topSpeed, int noOfSeats) : base(price, licencePlate, topSpeed)
        {
            this.noOfSeats = noOfSeats;
        }

        public override string ToString()
        {
            return $"Type:{this.GetType().Name}. " + base.ToString() + ", noOfSeats=" + noOfSeats;
        }
    }
    
    
}
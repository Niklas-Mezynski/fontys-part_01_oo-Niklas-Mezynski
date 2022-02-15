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

        public int NoOfSeats
        {
            get { return noOfSeats; }
        }

        public override string ToString()
        {
            return $"Type:{this.GetType().Name}. " + base.ToString() + ", noOfSeats=" + noOfSeats;
        }

        protected bool Equals(Car other)
        {
            return base.Equals(other) && noOfSeats == other.noOfSeats;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Car) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ noOfSeats;
            }
        }
    }
    
    
}
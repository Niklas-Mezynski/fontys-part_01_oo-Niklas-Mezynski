namespace oo_part_1
{
    public class Truck : Vehicle
    {
        private int maxTrailerWeight;
        public Truck(double price, string licencePlate, int topSpeed, int maxTrailerWeight) : base(price, licencePlate, topSpeed)
        {
            this.maxTrailerWeight = maxTrailerWeight;
        }
        
        public int MaxTrailerWeight
        {
            get { return maxTrailerWeight; }
        }


        public override string ToString()
        {
            return $"Type:{this.GetType().Name}. " + base.ToString() + ", maxTrailerWeight=" + maxTrailerWeight;
        }

        protected bool Equals(Truck other)
        {
            return base.Equals(other) && maxTrailerWeight == other.maxTrailerWeight;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Truck) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ maxTrailerWeight;
            }
        }
    }
    
    
}
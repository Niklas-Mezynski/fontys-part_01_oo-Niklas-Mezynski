namespace oo_part_1
{
    public class Truck : Vehicle
    {
        private int maxTrailerWeight;
        public Truck(double price, string licencePlate, int topSpeed, int maxTrailerWeight) : base(price, licencePlate, topSpeed)
        {
            this.maxTrailerWeight = maxTrailerWeight;
        }

        public override string ToString()
        {
            return $"Type:{this.GetType().Name}. " + base.ToString() + ", maxTrailerWeight=" + maxTrailerWeight;
        }
    }
    
    
}
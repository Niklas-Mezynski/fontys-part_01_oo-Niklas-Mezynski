namespace oo_part_1
{
    public class Motorcycle : Vehicle
    {
        private int levelOfCoolness { get; }
        public Motorcycle(double price, string licencePlate, int topSpeed, int levelOfCoolness) : base(price, licencePlate, topSpeed)
        {
            this.levelOfCoolness = levelOfCoolness;
        }
        
        public int LevelOfCoolness
        {
            get { return levelOfCoolness; }
        }

        protected bool Equals(Motorcycle other)
        {
            return base.Equals(other) && levelOfCoolness == other.levelOfCoolness;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Motorcycle) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ levelOfCoolness;
            }
        }

        public override string ToString()
        {
            return $"Type:{this.GetType().Name}. " + base.ToString() + ", levelOfCoolness=" + levelOfCoolness;
        }
    }
    
    
}
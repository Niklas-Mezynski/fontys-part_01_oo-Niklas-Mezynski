namespace oo_part_1
{
    public class Motorcycle : Vehicle
    {
        private int levelOfCoolness { get; }
        public Motorcycle(double price, string licencePlate, int topSpeed, int levelOfCoolness) : base(price, licencePlate, topSpeed)
        {
            this.levelOfCoolness = levelOfCoolness;
        }
        
        

        public override string ToString()
        {
            return $"Type:{this.GetType().Name}. " + base.ToString() + ", levelOfCoolness=" + levelOfCoolness;
        }
    }
    
    
}
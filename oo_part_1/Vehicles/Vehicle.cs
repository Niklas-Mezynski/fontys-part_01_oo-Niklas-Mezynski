using System;

namespace oo_part_1
{
    public abstract class Vehicle : IVehicle
    {
        private int id;

        private double price;

        private string licencePlate;

        private int topSpeed;

        protected Vehicle(double price, string licencePlate, int topSpeed)
        {
            Id = Program.getVehicleManager().GetNextId();
            Price = price;
            LicencePlate = licencePlate;
            TopSpeed = topSpeed;
        }

        public int Id
        {
            get { return this.id;}
            set { this.id = value; }
        }

        public double Price{
            get { return this.price;}
            set { this.price = value; }
        }

        public string LicencePlate{
            get { return this.licencePlate;}
            set { this.licencePlate = value; }
        }

        public int TopSpeed{
            get { return this.topSpeed;}
            set { this.topSpeed = value; }
        }

        public void increasePricePerc(double percentage)
        {
            this.price = this.price * percentage / 100;
        }

        public override string ToString()
        {
            return String.Format("The properties are: ID={0}, price={1}, licence_plate={2}, top_speed={3}", Id, Price, LicencePlate, TopSpeed);
        }
    }
}
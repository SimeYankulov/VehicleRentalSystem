namespace VehicleRentalSystem.Entities
{
    public abstract class Vehicle
    {
        public string? Brand { get; set; }
        public string? Model { get; set;}
        public double Value { get; set;}
       
        public virtual decimal InsuranceCostPerDay => 0m;
        public virtual decimal RentalCost => 0m;
        public virtual decimal RentalCostWithDiscount => 0m;
        public virtual decimal Percent => 0m;
        protected Vehicle(string _Brand, string _Model, double _Value)
        {
            this.Value = _Value;
            this.Brand = _Brand;
            this.Model = _Model;
        }

        public abstract decimal GetRentalCost(int RentalDays);
        public abstract decimal GetInsuranceCostPerDay();
        public abstract decimal GetPercent();
    }
}

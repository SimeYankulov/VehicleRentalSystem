namespace VehicleRentalSystem.Entities
{
    public class Motorcycle : Vehicle
    {
        public override decimal InsuranceCostPerDay => 0.02m / 100;
        public override decimal RentalCost => 15.00m;
        public override decimal RentalCostWithDiscount => 10.00m;
        public override decimal Percent => 0.20m;
        public Motorcycle(string _VehicleBrand, string _VehicleModel, double _VehicleValue) : base(_VehicleBrand, _VehicleModel, _VehicleValue)
        {
        }

        public override decimal GetInsuranceCostPerDay()
        {
            return (decimal)Value * InsuranceCostPerDay;
        }

        public override decimal GetRentalCost(int RentalDays)
        {
            if(RentalDays <= 7)
            {
                return RentalCost;
            }
            else
            {
                return RentalCostWithDiscount;
            }
        }

        public override decimal GetPercent()
        {
            return Percent;
        }
    }
}

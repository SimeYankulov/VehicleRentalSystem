namespace VehicleRentalSystem.Entities
{
    public class CargoVan : Vehicle
    {
        public override decimal InsuranceCostPerDay => 0.03m / 100;
        public override decimal RentalCost => 50.00m;
        public override decimal RentalCostWithDiscount => 40.00m;
        public override decimal Percent => 0.15m;
 
        public CargoVan(string _VehicleBrand, string _VehicleModel, double _VehicleValue) 
            : base(_VehicleBrand, _VehicleModel, _VehicleValue)
        {
        }

        public override decimal GetInsuranceCostPerDay()
        {
            return (decimal)Value * InsuranceCostPerDay;
        }
       
        public override decimal GetRentalCost(int RentalDays)
        {
            if(RentalDays <= 7) {
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

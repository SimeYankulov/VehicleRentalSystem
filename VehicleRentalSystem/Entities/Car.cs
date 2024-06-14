using System.ComponentModel.DataAnnotations;

namespace VehicleRentalSystem.Entities
{
    public class Car:Vehicle
    {
        public override decimal InsuranceCostPerDay => 0.01m / 100;
        public override decimal RentalCost => 20.00m;
        public override decimal RentalCostWithDiscount => 15.00m;
        public override decimal Percent => 0.10m;
        [Range(1,5)]
        public int SafetyRating { get; set; }
        public Car(string _VehicleBrand, string _VehicleModel, double _VehicleValue, int _SafetyRating) 
            : base(_VehicleBrand, _VehicleModel, _VehicleValue)
        {
            SafetyRating = _SafetyRating;

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

        public override decimal GetInsuranceCostPerDay()
        {
            return (decimal)Value * InsuranceCostPerDay;
        }

        public int GetSafetyRating()
        {
            return SafetyRating;
        }
        public override decimal GetPercent()
        {
            return Percent;
        }
    }
}

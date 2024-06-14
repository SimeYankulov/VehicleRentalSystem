namespace VehicleRentalSystem.Entities
{
    public class Rental
    {
        private DateOnly Date { get; set; }
        private Vehicle Vehicle { get; set; } 
        private Customer Customer { get; set; }
        private DateTime ReservationStartDate { get; set; }
        private DateTime ReservationEndDate { get; set; }
        private int ReservedRentalDays { get; set; }

        private DateTime ActualReturnDate { get; set; }
        private int ActualRentalDays { get; set; }

        private decimal RentalCostPerDay { get; set; }
        private decimal InsuranceCostPerDay { get; set; }
        private decimal ActualInsurance { get; set; }
        private decimal InsuranceAddition { get; set; }
        private decimal InsuranceDiscount { get; set; }

        private decimal RentDeduction { get; set; } = 0;
        private decimal InsuranceDeduction { get; set; } = 0;
       
        private decimal Total { get; set; }
        private decimal TotalRent { get; set; }
        private decimal TotalInsurance { get; set; }
 
        public Rental(DateOnly _Date, Vehicle _Vehicle, Customer _Customer,
            DateTime _ReservationStartDate, DateTime _ReservationEndDate, DateTime _ActualReturnDate)
        {
            Date = _Date;
            Vehicle = _Vehicle;
            Customer = _Customer;
            ReservationStartDate = _ReservationStartDate;
            ReservationEndDate = _ReservationEndDate;

            ReservedRentalDays = GetDifferenceInDays(ReservationEndDate, ReservationStartDate);

            ActualReturnDate = _ActualReturnDate;

            if(ReservationEndDate != ActualReturnDate)
            {
                ActualRentalDays = GetDifferenceInDays(ActualReturnDate , ReservationStartDate);
            }
            else
            {
                ActualRentalDays = ReservedRentalDays;
            }

        }

        public void PrintInfo()
        { 
            PrintBaseInfo();

            PrintCosts();
            
            PrintTotals();
            
        }

        private void PrintBaseInfo()
        {
            Console.WriteLine("XXXXXXXXXXX");
            Console.WriteLine("Date: " + Date.ToString("yyyy-MM-dd"));
            Console.WriteLine("Customer Name: " + Customer.GetName());
            Console.WriteLine("Rented Vehicle: " + Vehicle.Brand + " " + Vehicle.Model + "\n");

            Console.WriteLine("Reservation start date: " + ReservationStartDate.ToString("yyyy-MM-dd"));
            Console.WriteLine("Reservation end date: " + ReservationEndDate.ToString("yyyy-MM-dd"));
            Console.WriteLine("Reserved rental days: " + ReservedRentalDays + "\n");

            Console.WriteLine("Actual return date: " + ActualReturnDate.ToString("yyyy-MM-dd"));
            Console.WriteLine("Actual rental days: " + ActualRentalDays + "\n");
        }
        private void PrintCosts()
        {
            RentalCostPerDay = Vehicle.GetRentalCost(ActualRentalDays);
            Console.WriteLine("Rental cost per day: $" + RentalCostPerDay
                                                        .ToInvariantString());

            InsuranceCostPerDay = Vehicle.GetInsuranceCostPerDay();

            //Gets the discounts 
            GetDiscount();

            //Whether there is a discount or addition it prints it out 
            if (InsuranceDiscount > 0 || InsuranceAddition > 0)
            {
                Console.WriteLine("Initial Insurance per day: $" + InsuranceCostPerDay.ToInvariantString());

                if (InsuranceDiscount > 0)
                {

                    Console.WriteLine("Insurance discount per day: $" + InsuranceDiscount.ToInvariantString());

                }
                else if (InsuranceAddition > 0)
                {
                    Console.WriteLine("Insurance addition per day: $" + InsuranceAddition.ToInvariantString());

                }
            }

            Console.WriteLine("Insurance per day: $" + ActualInsurance.ToInvariantString() + "\n");

            if (ActualReturnDate != ReservationEndDate)
            {
                CalculateReturnDiscounts();
            }
            // Wheter there is rent or insurance deduction prints them out
            if (RentDeduction > 0 || InsuranceDeduction > 0)
            {
                Console.WriteLine("Early return discount for rent: $" + RentDeduction.ToInvariantString());
                Console.WriteLine("Early return discount for insurance: $" + InsuranceDeduction.ToInvariantString() + "\n");
            }

        }
        private void PrintTotals()
        {
            TotalRent = (ReservedRentalDays * RentalCostPerDay) - RentDeduction;
            TotalInsurance = (ReservedRentalDays * ActualInsurance) - InsuranceDeduction;
            Total = TotalRent + TotalInsurance;

            Console.WriteLine("Total rent: $" + TotalRent.ToInvariantString());
            Console.WriteLine("Total Insurance: $" + TotalInsurance.ToInvariantString());
            Console.WriteLine("Total: $" + Total.ToInvariantString());
            Console.WriteLine("XXXXXXXXXXX");
        }

        private int GetDifferenceInDays(DateTime reservationEndDate, DateTime reservationStartDate)
        {
            TimeSpan difference = reservationEndDate - reservationStartDate;
            return difference.Days;
        }
        // Determines wheter a discount or addtion should be given
        private void GetDiscount()
        {
            if (Vehicle is Car car && car.GetSafetyRating() > 3)
            {
                CalculateAdditionOrDiscount();
            }
            else if (Vehicle is CargoVan && Customer.GetExperience() > 5)
            {
                CalculateAdditionOrDiscount();
            }
            else if (Vehicle is Motorcycle && Customer.GetAge() < 25)
            {
                CalculateAdditionOrDiscount();
            }
            else
            {
                ActualInsurance = InsuranceCostPerDay;
            }
        }
        // Calculates the discount or addition and applies it to the Insurance
        private void CalculateAdditionOrDiscount()
        {
            if (Vehicle is Motorcycle motorcycle)
            {
                InsuranceAddition = motorcycle.GetPercent() * InsuranceCostPerDay;
                ActualInsurance = InsuranceCostPerDay + InsuranceAddition;

            }
            else
            {
                InsuranceDiscount = Vehicle.GetPercent() * InsuranceCostPerDay;
                ActualInsurance = InsuranceCostPerDay - InsuranceDiscount;
            }
        }
        // Calculates how much to deduct from the rent and insurance and stores them in variables
        private void CalculateReturnDiscounts()
        {
            int days = GetDifferenceInDays(ReservationEndDate, ActualReturnDate);

            RentDeduction = days * RentalCostPerDay / 2;
            InsuranceDeduction = days * ActualInsurance;

        }
    }
}

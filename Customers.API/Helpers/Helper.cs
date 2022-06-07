using Customers.API.Models;

namespace Customers.API.Helpers
{
    internal static class Helper
    {
        public static double ReturnDiscountCost(Customer customer, Purshace purshace)
        {
            int purshaces = customer.Purshaces.Count;

            switch (purshaces)
            {
                case 1:
                    return purshace.Amount;

                case >= 1 and <= 2:
                    return Math.Round(purshace.Amount - purshace.Amount * 0.01, 2);

                case >= 3 and <= 5:
                    return Math.Round(purshace.Amount - purshace.Amount * 0.02, 2);

                case >= 5 and <= 10:
                    return Math.Round(purshace.Amount - purshace.Amount * 0.05, 2);

                case >= 10:
                    return Math.Round(purshace.Amount - purshace.Amount * 0.1, 2);

                default:
                    return 0;
            }
        }
    }
}
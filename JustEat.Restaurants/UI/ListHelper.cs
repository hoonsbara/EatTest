using System.Collections.Generic;
using System.Linq;
using System.Text;
using JustEat.Restaurants.DTO;

namespace JustEat.Restaurants.UI
{
    public static class ListHelper
    {
        public static string ToCusineList(this IList<CuisineType> cuisineTypes)
        {
            var cusines = new StringBuilder(100);
            foreach (var cusinetype in cuisineTypes)
            {
                if (cusines.Length == 0)
                    cusines.Append(cusinetype.Name);
                else
                    cusines.Append(", " + cusinetype.Name);

            }
            return cusines.ToString();
        }
    }
}

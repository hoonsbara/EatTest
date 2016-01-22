using System.Collections.Generic;

namespace JustEat.Restaurants.Service
{
    public class JustEatHeader
    {
        private static Dictionary<string, string> _instance;
        public static Dictionary<string, string> Instance
        {
            get
            {
                return _instance ?? (_instance = new Dictionary<string, string>
                {
                    {"Accept-Tenant", "uk"},
                    {"Accept-Language", "en-GB"},
                    {"Authorization", "Basic VGVjaFRlc3RBUEk6dXNlcjI="},
                    {"Host", "public.je-apis.com"}
                });
            }
        }
    }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using AirNB.Model;

namespace AirNB.Services
{
    public class SearchService
    {
        // Currently I've hardcoded the list of searches here. But they could be
        // stored in a database or fetched via a remote service. 
        private List<Properties> _searches = new List<Properties>{
                new Properties{ID=1,Name="Hanoi",Price=34.67,Location="Vietnam",ImageUrl="https://lorempixel.com/100/100/city/1/"},
                new Properties{ID=2,Name="Rome",Price=51.67,Location="Italy",ImageUrl="https://lorempixel.com/100/100/city/2/"},
                new Properties{ID=3,Name="London",Price=14.67,Location="England",ImageUrl="https://lorempixel.com/100/100/city/3/"},
                new Properties{ID=4,Name="Siem Reap",Price=14.67,Location="Cambodia",ImageUrl="https://lorempixel.com/100/100/city/4/"},
               new Properties{ID=5,Name="Prague",Price=14.67,Location="Czech republic",ImageUrl="https://lorempixel.com/100/100/city/5/"},

            };
    
        public IEnumerable<Properties> GetRecentSearches(string filter = null)
        {
            if (String.IsNullOrWhiteSpace(filter))
                return _searches;

            // Note that I've used StringComparison.CurrentCultureIgnoreCase 
            // so searching is case-insensitive.
            return _searches.Where(s => s.Location.StartsWith(filter, StringComparison.CurrentCultureIgnoreCase)||s.Name.StartsWith(filter,StringComparison.CurrentCultureIgnoreCase));
        }
        public void DeleteSearch(int searchId)
        {
            _searches.Remove(_searches.Single(s => s.ID == searchId));
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> hotelIDs = new HotelRatings().GetHotels(4);

            new RatingsCalcs().GetHotels(RatingsCalcs.hotels, 6);

            new UserPaths().SetBasePaths();

            new SiteMap().SetSiteMap();
        }
    }
}

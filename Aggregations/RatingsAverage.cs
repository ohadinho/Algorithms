using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregations
{
    public class HotelRating
    {
        public int HotelID { get; set; }
        public int UserID { get; set; }
        public int Rating { get; set; }

        public HotelRating(int hotelID, int userID, int rating)
        {
            this.HotelID = hotelID;
            this.UserID = userID;
            this.Rating = rating;
        }
    }
    
    public class HotelSum
    {        
        public int Count { get; set; }
        public int Sum { get; set; }

        public HotelSum(int count,int sum)
        {
            this.Count = count;
            this.Sum = sum;
        }
    }    

    public class RatingsCalcs
    {
        public static HotelRating[] hotels = new HotelRating[] { new HotelRating(1,1,6), new HotelRating(2,1,8), new HotelRating(1,2,9),
        new HotelRating(2,2,3),new HotelRating(2,3,1) };

        public List<int> GetHotels(HotelRating[] hotelsReq,int minAvg)
        {
            Dictionary<int, HotelSum> hotelsDicAverage = new Dictionary<int, HotelSum>();
            for(int i=0;i<hotels.Length; i++)
            {
                HotelRating currentHotelRating = hotels[i];
                if (hotelsDicAverage.Keys.Contains(currentHotelRating.HotelID))
                {
                    hotelsDicAverage[currentHotelRating.HotelID].Count += 1;
                    hotelsDicAverage[currentHotelRating.HotelID].Sum += currentHotelRating.Rating;
                }
                else
                {
                    HotelSum hs = new HotelSum(1,currentHotelRating.Rating);
                    hotelsDicAverage[currentHotelRating.HotelID] = hs;
                }
            }

            List<int> returnList = new List<int>();
            foreach(int hotelID in hotelsDicAverage.Keys)
            {
                int currentAvg = hotelsDicAverage[hotelID].Sum / hotelsDicAverage[hotelID].Count;
                if (currentAvg > minAvg)
                    returnList.Add(hotelID);
            }

            return returnList;
        }
    }
}

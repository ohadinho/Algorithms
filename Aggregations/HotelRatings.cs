using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aggregations
{
    public class Hotel
    {
        public string HotelID { get; set; }
        public string UserID { get; set; }
        public int Score { get; set; }
    }

    public class HotelAvg
    {        
        public int Sum { get; set; }
        public int Count { get; set; }
    }

    public class HotelRatings
    {
        private List<Hotel> userRatings;

        public HotelRatings()
        {
            this.userRatings.Add(new Hotel() { HotelID = "1001", UserID = "501", Score = 7 });
            this.userRatings.Add(new Hotel() { HotelID = "1001", UserID = "502", Score = 7 });
            this.userRatings.Add(new Hotel() { HotelID = "1001", UserID = "503", Score = 7 });
            this.userRatings.Add(new Hotel() { HotelID = "2001", UserID = "504", Score = 10 });
            this.userRatings.Add(new Hotel() { HotelID = "3001", UserID = "505", Score = 5 });
            this.userRatings.Add(new Hotel() { HotelID = "2001", UserID = "505", Score = 5 });
        }

        // Implement a function, get_hotels(scores, min_avg_score) that returns a list of hotel ids that have average score equal to or higher than min_avg_score.
        public List<string> GetHotels(int minAvgScore)
        {
            Dictionary<string, HotelAvg> hotelIDAverage = new Dictionary<string, HotelAvg>();
            List<string> hotelIDBiggerThanMin = new List<string>();

            foreach (Hotel h in this.userRatings)
            {
                if (!hotelIDAverage.ContainsKey(h.HotelID))
                {
                    HotelAvg havg = new HotelAvg() { Count = 0, Sum = 0 };
                    hotelIDAverage.Add(h.HotelID, havg);
                }

                hotelIDAverage[h.HotelID].Count++;
                hotelIDAverage[h.HotelID].Sum += h.Score;
            }

            foreach (KeyValuePair<string,HotelAvg> pair in hotelIDAverage)
            {
                float currentAvg = pair.Value.Sum / pair.Value.Count;
                if (currentAvg > minAvgScore)
                    hotelIDBiggerThanMin.Add(pair.Key);               
            }

            return hotelIDBiggerThanMin;
        }
    }
}

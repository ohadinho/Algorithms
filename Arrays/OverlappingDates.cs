using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arrays
{    
    //You are building a small command-line application to calculate hotel 

    //availability for a city. Your application reads in two (2) data files, and 

    //outputs its answer to STDOUT. 
    //Your application will read in: 
    //· a list of hotels along with how many rooms each contains (in no particular 

    //order) 
    //· a list of bookings that have been made (in no particular order) 
    //Your application will then print the list of all hotels which have 

    //availability for check-in and check- out date range, if any. 
    //Do not worry about whether a specific room is available in a hotel for the 

    //entire booking period without switching rooms: availability is defined as the 

    //hotel having at least one (1) available room for each night of the target 

    //stay, regardless of whether it's the same room from day to day. 

    //Data Files 
    //hotels.csv 
    //# Name, Rooms 
    //Westin, 10 
    //Best Western, 20 
    //Hilton, 10 
    //... 

    //bookings.csv 
    //# Name, Checkin, Checkout 
    //Hilton, 2015-04-02, 2015-04-03 
    //Hilton, 2015-04-02, 2015-04-04 
    //Westin, 2015-05-01, 2015-05-20    
    public class OverlappingDates
    {
        public class Book
        {
            public DateTime CheckIn { get; set; }
            public DateTime CheckOut { get; set; }
            public int CurrentAvailability { get; set; }
        }

        private List<Book> bookings = new List<Book>();
        private Dictionary<string, List<Book>> hotels = new Dictionary<string, List<Book>>();
        private Dictionary<string, int> hotelMaxAvailability = new Dictionary<string, int>();

        public OverlappingDates()
        {
            bookings.Add(new Book() { CheckIn = new DateTime(2015, 04, 02), CheckOut = new DateTime(2015, 04, 03) });
            bookings.Add(new Book() { CheckIn = new DateTime(2015, 04, 02), CheckOut = new DateTime(2015, 04, 04) });
            bookings.Add(new Book() { CheckIn = new DateTime(2015, 04, 03), CheckOut = new DateTime(2015, 04, 05) });
            bookings.Add(new Book() { CheckIn = new DateTime(2015, 04, 01), CheckOut = new DateTime(2015, 04, 05) });
            bookings.Add(new Book() { CheckIn = new DateTime(2015, 04, 09), CheckOut = new DateTime(2015, 04, 10) });
            hotels.Add("Hilton", bookings);
            hotelMaxAvailability.Add("Hilton", 5);
        }

        public void Init()
        {
            for(int i = 0;i<hotels.Count;i++)
            {
                string hotelName = hotels.ElementAt(i).Key;
                hotels[hotelName] = hotels[hotelName].OrderBy(y => y.CheckIn).ToList();

                // Init with max current availability                
                hotels[hotelName].ElementAt(0).CurrentAvailability = hotelMaxAvailability[hotelName] - 1;
                for (int j = 1; j < hotels[hotelName].Count; j++)
                {
                    Book previousBook = hotels[hotelName].ElementAt(j - 1);
                    Book currentBook = hotels[hotelName].ElementAt(j);     
                    
                    // Example:
                    // 1, 5
                    // 2, 3
                    // 2, 4
                    // 3, 5
                    // 9, 10
                    // If 2 < 5 then availabilty for this date should decrease by 1
                    if (currentBook.CheckIn < previousBook.CheckOut)
                        currentBook.CurrentAvailability = previousBook.CurrentAvailability - 1;
                    else
                    {
                        currentBook.CurrentAvailability = hotelMaxAvailability[hotelName] - 1;
                    }
                }
            }            
        }

        public bool CheckHotelAvailability(string hotelName, DateTime checkIn, DateTime checkOut)
        {
            List<Book> currentHotelBooks = hotels[hotelName];
            // Find start index of relevant date
            int i;
            for (i = 0; i < currentHotelBooks.Count; i++)
            {
                if (checkIn <= currentHotelBooks[i].CheckIn)
                    break;
            }

            while (checkIn >= currentHotelBooks[i].CheckIn && checkOut <= currentHotelBooks[i].CheckOut)            
                i++;            

            if (currentHotelBooks[i - 1].CurrentAvailability == 0)
                return false;

            return true;
        }
    }

    public class OverlappingDatesMatrix
    {
        public const int Days = 31;
        public const int Months = 12;

        public class BookingDetails
        {
            public int OrderNo { get; set; }   
        }

        public class HotelBooking
        {
            // Each matrix cell is a dictionary:
            // Key = hotel name
            // Value = list of bookings
            public Dictionary<string, List<BookingDetails>> hotelBookingDic { get; set; }
        }
              
        // Rows - Months
        // Columns - Days
        public HotelBooking[,] matrix = new HotelBooking[Months,Days];

        public Dictionary<string, int> hotelRooms = new Dictionary<string, int>();

        public OverlappingDatesMatrix()
        {            
            hotelRooms.Add("Hilton", 3);
            Init();
            this.Add("Hilton", new DateTime(2015, 04, 02), new DateTime(2015, 04, 03), new BookingDetails() { OrderNo = 1 });
            this.Add("Hilton", new DateTime(2015, 04, 02), new DateTime(2015, 04, 04), new BookingDetails() { OrderNo = 2 });
            this.Add("Hilton", new DateTime(2015, 04, 03), new DateTime(2015, 04, 05), new BookingDetails() { OrderNo = 3 });
            this.Add("Hilton", new DateTime(2015, 04, 01), new DateTime(2015, 04, 05), new BookingDetails() { OrderNo = 4 });
            this.Add("Hilton", new DateTime(2015, 04, 09), new DateTime(2015, 04, 10), new BookingDetails() { OrderNo = 5 });
        }

        public void Add(string hotelName, DateTime checkIn, DateTime checkOut, BookingDetails bd)
        {
            // Getting current day hotels list
            HotelBooking currentDayBooking = matrix[checkIn.Month, checkIn.Day];            
            // Add the booking details to requested hotel bookings list
            currentDayBooking.hotelBookingDic[hotelName].Add(bd);            
        }

        public void Init()
        {
            for (int i = 0; i < Months; i++)
            {                
                for (int j = 0; j < Days; j++)
                {                    
                    matrix[i, j] = new HotelBooking();

                    // For each hotel we create a dictionary in a day
                    // Key - Hotel name
                    // Value - Bookings list
                    foreach (KeyValuePair<string, int> hotelRoom in hotelRooms)
                    {
                        matrix[i,j].hotelBookingDic = new Dictionary<string, List<BookingDetails>>();
                        matrix[i, j].hotelBookingDic.Add(hotelRoom.Key, new List<BookingDetails>());
                    }
                }
            }
        }

        public bool CheckHotelAvailability(string hotelName, DateTime checkIn, DateTime checkOut)
        {
            for (DateTime currentDate = checkIn; checkIn < checkOut; currentDate = currentDate.AddDays(1))
            {
                // Get all the bookings for the current date of hotel
                List<BookingDetails> currentDayBookingsForHotel = matrix[checkIn.Month-1,checkIn.Day - 1].hotelBookingDic[hotelName];
                // Getting maximum of requested hotel rooms
                // For instance: Hilton got 5 rooms
                int maxRoomsAvailableForHotel = hotelRooms[hotelName];
                // If we cannot add another booking
                if (currentDayBookingsForHotel.Count == maxRoomsAvailableForHotel)
                    return false;
            }

             return false;
        }
    }
}

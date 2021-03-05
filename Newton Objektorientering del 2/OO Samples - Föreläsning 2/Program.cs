using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_Samples___Föreläsning_2
{

    //Service BookingService
    //Interface IBookingService
    enum BookingStatus
    {
        Created = 1,
        Pending = 2,
        Accepted = 3,
        Cancelled = 4,
        Deleted = 5
    }

    interface IBookable
    {

        string BookingNumber { get; set; }
        string CreatedDate { get; set; }
        string CustomerName { get; set; }
        void CreateBooking();
        void CancelBooking();
        void DeleteBooking();
        BookingStatus GetBookingStatus();
    }


    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
    }


    public abstract class Booking
    {


    }


    public class FerryBooking
    {

    }


    public class FreightBooking
    {

    }

    public class AirlineBooking
    {

    }






    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

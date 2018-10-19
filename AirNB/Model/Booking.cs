using System;
namespace AirNB.Model
{
    public class Booking
    {
        public Properties Properties { get; set; }
        public DateTime startDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Period
        {
            get
            {
                return String.Format("{0} - {1}",
                                     startDate.ToString("MMM d, yyyy"),
                                     EndDate.ToString("MMM d, yyyy"));
            }
        }
    }
}

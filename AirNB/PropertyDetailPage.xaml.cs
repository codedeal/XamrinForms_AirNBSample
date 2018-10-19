using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using AirNB.Model;
using Xamarin.Forms;

namespace AirNB
{
    public partial class PropertyDetailPage : ContentPage
    {
        static Booking booking;
        public PropertyDetailPage(Properties properties)
        {
          
            if (properties != null)
            {
                booking = new Booking();

                InitializeComponent();
                booking.Properties = properties;
                booking.startDate = startDatePicker.Date;
                booking.EndDate = endDatePicker.Date;
                BindingContext = setImageUrl(properties);
            }
        }

        public Properties setImageUrl(Properties properties)
        {
        //https://lorempixel.com/100/100/city/1/
            string input = properties.ImageUrl;
            string pattern = @"\b100\b";
            string replace = "300";
            string result = Regex.Replace(input, pattern, replace);

            properties.ImageUrl = result;

            return properties;

        }

        async void BookClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new PaymentPage(booking));
        }

        void StartDateSelected(object sender, Xamarin.Forms.DateChangedEventArgs e)
        {
            Console.WriteLine(e.NewDate);
            booking.startDate = e.NewDate;
        }

        void EndDateSelected(object sender, Xamarin.Forms.DateChangedEventArgs e)
        {
            Console.WriteLine(e.NewDate);
            booking.EndDate = e.NewDate;
        }
    }
}

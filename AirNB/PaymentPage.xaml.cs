using System;
using System.Collections.Generic;
using AirNB.Model;
using Xamarin.Forms;

namespace AirNB
{
    public partial class PaymentPage : ContentPage
    {
        public PaymentPage(Booking booking)
        {
            InitializeComponent();
            BindingContext = booking;
        }

        async void PaymentClicked(object sender, System.EventArgs e)
        {
            DisplayAlert("Congrats", "Booking is Confirmed", "OK");
            await Navigation.PushAsync(new HomePage());
        }
    }
}

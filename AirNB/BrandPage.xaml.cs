using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AirNB
{
    public partial class BrandPage : ContentPage
    {
        public BrandPage()
        {
            InitializeComponent();
        }

        void LoginClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }
        void RegisterClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

    }
}

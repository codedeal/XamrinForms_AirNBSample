using System;
using System.Collections.Generic;
using AirNB.Model;
using Xamarin.Forms;

namespace AirNB
{
    public partial class LoginPage : ContentPage
    {
        

        public LoginPage()
        {
           
            InitializeComponent();  
          
        }


        async void LoginClicked(object sender, System.EventArgs e)
        {
            if (Email.Text == " " || Password.Text == " ")
            {
                await DisplayAlert("Error", "Fields are blank Login, try again", "OK");

            }
            else
            {
                if (Email.Text == "abc" && Password.Text == "abc")
                    App.Current.MainPage = new NavigationPage(new HomePage());
                   // await Navigation.PushAsync(new HomePage());
                else
                    await DisplayAlert("Error", "Invalid Login, try again", "OK");
            }

          
        }
    }
}

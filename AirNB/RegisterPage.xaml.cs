using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AirNB
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        void SignUpClicked(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Email.Text) && !string.IsNullOrWhiteSpace(Password.Text) && !string.IsNullOrWhiteSpace(ConfirmPassword.Text))
            {
                if (Password.Text == ConfirmPassword.Text)
                {
                    Console.WriteLine("Sign Up");
                    App.Current.MainPage = new NavigationPage(new HomePage());
                }
                else
                    DisplayAlert("Error", "Passsword and Confirm Password not matches", "OK");

            }
            else
                DisplayAlert("Error", "Error in Entry Try Again!", "OK");
        }
    }
}

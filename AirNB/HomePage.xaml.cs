using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AirNB.Model;
using AirNB.Services;
using Xamarin.Forms;

namespace AirNB
{
    public partial class HomePage : ContentPage
    {
        private SearchService searchServices;
        private List<PropertyGroup> _propertyGroup;
        public HomePage()
        {
            searchServices = new SearchService();
            InitializeComponent();
            PopulateListView(searchServices.GetRecentSearches());
        }
        // Note that we have re-used this method twice in this class. I noticed
        // I always had to set _searchGroups and immediately set listView.ItemsSource
        // together. So, I decided to refactor these few lines into a separate
        // method (PopulateListView) to make the code cleaner.
        public void PopulateListView(IEnumerable<Properties> searches)
        {
            _propertyGroup = new List<PropertyGroup> { 
                new PropertyGroup("Recent Searches", searches)
            };
            locationList.ItemsSource = _propertyGroup;
            //locationList.ItemsSource=new List<Properties>{
            //    new Properties{ID=1,Name="San De Mountain",Price=34.67,Location="South California",ImageUrl="https://lorempixel.com/100/100/city/1/"},
            //    new Properties{ID=2,Name="Les Pa Cino",Price=51.67,Location="Los Angles",ImageUrl="https://lorempixel.com/100/100/city/2/"},
            //    new Properties{ID=3,Name="Do Ja Gointo",Price=14.67,Location="Debuta",ImageUrl="https://lorempixel.com/100/100/city/3/"},

            //};
                
        }
      

        void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            PopulateListView(searchServices.GetRecentSearches(e.NewTextValue));
        }

        void Delete_Clicked(object sender, System.EventArgs e)
        {
            var property = (sender as MenuItem).CommandParameter as Properties;
            // Locally remove the search from search groups. Since SearchGroup
            // is an ObservableCollection, this will make the search item disappear
            // from the ListView immediately. 
            _propertyGroup[0].Remove(property);

            // But we should also update the backend. So, we use SearchService for that.
            searchServices.DeleteSearch(property.ID);
        }

        async void PropertySelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            var property = e.SelectedItem as Properties;
           await Navigation.PushAsync(new PropertyDetailPage(property));
            locationList.SelectedItem = null;
                          
        }

        void LogOutClicked(object sender, System.EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new BrandPage());
        }
    }
}

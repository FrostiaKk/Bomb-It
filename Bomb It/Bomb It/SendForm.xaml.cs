using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Bomb_It
{
    [DesignTimeVisible(false)]
    public partial class SendForm : ContentPage
    {
        private int Score;
        private string country;
        public SendForm(string score)
        {
            InitializeComponent();
            Score = Int32.Parse(score);
        }

        async void SendClicked(object sender, EventArgs e)
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                var lat = location.Latitude;
                var lon = location.Longitude;

                var placemarks = await Geocoding.GetPlacemarksAsync(lat, lon);

                var placemark = placemarks?.FirstOrDefault();
                country = placemark.CountryName;
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                // Handle exception that may have occurred in geocoding
            }
            var url = "https://addtodatabase20200620205018.azurewebsites.net/" +
                $"api/AddToDatabase?code=iL0EyW6eV7ZLdlX7eNVS3giwL4AhC9XtyhN8zeZoyYFIkBhFylV00w==&name={Nick.Text}&score={Score}&country={country}";
            var client = new HttpClient();
            try
            {
                var result = await client.GetStringAsync(url);
                Console.WriteLine(result);
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }
            await Navigation.PopToRootAsync();
        }

    }

}
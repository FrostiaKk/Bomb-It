using Newtonsoft.Json;
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
    public partial class MainPage : ContentPage
    {
        static string bomb = new Random().Next(1, 5).ToString();
        static int Scores = 0;
        public MainPage()
        {
            InitializeComponent();
        }

        async void ButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button.Text == bomb)
            {
                Vibration.Vibrate();
                bomb = new Random().Next(1, 5).ToString();
                await Navigation.PushAsync(new GameOver(Scores),false);
                //await DisplayAlert("Bomba wybuchła", "Koniec gry", "Zagraj jeszcze raz");
                Scores = 0;
            }
            else
            {
                Scores += 1;
                await DisplayAlert("Bomba rozbrojona", "Wynik: " + Scores, "Kontynuuj");
                bomb = new Random().Next(1, 5).ToString();
            }
        }

        async void RankingClicked(object sender, EventArgs e)
        {
            var url = "https://retrievedatabase20200620234523.azurewebsites.net/api/RetrieveDatabase?code=QHe/84XZV2IrMQ4tFuPFtStsQH3OvkldV7Hr9bzrS/wWzJcf0r0/8Q==";
            var client = new HttpClient();
            try
            {
                //HttpResponseMessage response = await client.GetAsync(url);
                var json = await client.GetStringAsync(url);
                dynamic data = JsonConvert.DeserializeObject(json);
                await Navigation.PushAsync(new Ranking(data), false);
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }
            
        }

        
    }
}

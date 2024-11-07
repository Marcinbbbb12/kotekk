using System.Net;
using System.Net.Http;
using System.Text.Json;
using Microsoft.Maui.Controls;
using System.Collections.Generic;

namespace kotekk
{
    public partial class MainPage : ContentPage
    {
        public class Catfact
        {
            public int current_page { get; set; }
            public IList<Facts> data { get; set; } 
        }

        public class Facts 
        {
            public string fact { get; set; }
            public int length { get; set; }
        }

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            string json;
            string url = "https://catfact.ninja/facts?max_length=100&limit=10";
            using (var webClient = new WebClient())
            {
                json = webClient.DownloadString(url);
            }
            var response = JsonSerializer.Deserialize<Catfact>(json);
            input.Text = response.data[0].fact.ToString(); 
        }
    }
}
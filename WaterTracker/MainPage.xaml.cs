using Microsoft.Maui.Storage;
namespace WaterTracker
{
    public partial class MainPage : ContentPage
    {
        int lacznie_wypito = 0;
        int cel = 2000;
        int progres = 0;
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            cel = Preferences.Get("CelMl", 2000);
            lacznie_wypito = Preferences.Get("LacznieWypito", 0);
            progres = Preferences.Get("Progres", 0);

            woda_progres.Text = $"{progres}%";
            ile_wypito.Text = $"wypito {lacznie_wypito}ml z {cel}ml";

            AktualizujWiadra();
        }


        private void Button_ml_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            string text = button.Text;
            if (text == "50ml")
            {
                lacznie_wypito += 50;
            }
            else if (text == "100ml")
            {
                lacznie_wypito += 100;
            }
            else if (text == "250ml")
            {
                lacznie_wypito += 250;
            }
            else if (text == "300ml")
            {
                lacznie_wypito += 300;
            }
            progres = (int)((double)lacznie_wypito / cel * 100); ;
            woda_progres.Text = $"{progres}%";

            ile_wypito.Text = $"wypito {lacznie_wypito}ml z {cel}ml";

            Preferences.Set("LacznieWypito", lacznie_wypito);
            Preferences.Set("Progres", progres);
            AktualizujWiadra();
        }

        void AktualizujWiadra()
        {
            wiadroA.Source = lacznie_wypito >= cel * 0.2 ? "wiadro_1.png" : "wiadro_0.png";
            wiadroB.Source = lacznie_wypito >= cel * 0.4 ? "wiadro_1.png" : "wiadro_0.png";
            wiadroC.Source = lacznie_wypito >= cel * 0.6 ? "wiadro_1.png" : "wiadro_0.png";
            wiadroD.Source = lacznie_wypito >= cel * 0.8 ? "wiadro_1.png" : "wiadro_0.png";
            wiadroE.Source = lacznie_wypito >= cel ? "wiadro_1.png" : "wiadro_0.png";
        }

        

        async void settings_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(settingsPage));

        }

    }
}

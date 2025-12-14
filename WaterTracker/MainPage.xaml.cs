namespace WaterTracker
{
    public partial class MainPage : ContentPage
    {
        int lacznie_wypito = 0;
        int cel = 2000; //2l
        int progres = 0;
        public MainPage()
        {
            InitializeComponent();
            woda_progres.Text = $"{lacznie_wypito}%";
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

            ile_wypito.Text = $"wypito {lacznie_wypito}ml z 2l";

            if(lacznie_wypito >= cel * 0.2)
            {
                wiadroA.Source = "wiadro_1.png";
            }
            if (lacznie_wypito >= cel * 0.4)
            {
                wiadroB.Source = "wiadro_1.png";
            }
            if (lacznie_wypito >= cel * 0.6)
            {
                wiadroC.Source = "wiadro_1.png";
            }
            if (lacznie_wypito >= cel * 0.8)
            {
                wiadroD.Source = "wiadro_1.png";
            }
            if (lacznie_wypito >= cel)
            {
                wiadroE.Source = "wiadro_1.png";
            }
        }
    }
}

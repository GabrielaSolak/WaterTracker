namespace WaterTracker;
using Plugin.LocalNotification;
using Microsoft.Maui.Storage;

public partial class settingsPage : ContentPage
{
	public settingsPage()
	{
		InitializeComponent();
        RequestPermission();
    }
    async void RequestPermission()
    {
        await LocalNotificationCenter.Current.RequestNotificationPermission();
    }

    void zapiszZmiany_Clicked(object sender, EventArgs e)
    {

        if (int.TryParse(liczbaMl.Text, out int ml) || string.IsNullOrWhiteSpace(liczbaMl.Text))
        {
            if (ml > 1)
                Preferences.Set("CelMl", ml);

            //powiadomienie
            var selectedTime = timePicker.Time;
            var now = DateTime.Now;

            var notifyDateTime = DateTime.Today.Add(selectedTime);
            if (notifyDateTime <= now)
                notifyDateTime = notifyDateTime.AddDays(1);

            var notification = new NotificationRequest
            {
                NotificationId = 200,
                Title = "Przypomnienie",
                Description = "Pamiętaj o stałym nawadnianiu",
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = notifyDateTime,
                    RepeatType = NotificationRepeat.Daily
                }
            };
            LocalNotificationCenter.Current.Show(notification);
            Shell.Current.GoToAsync("..");

        }
        else
        {
            bledy.Text = "Wprowadź poprawną liczbę.";
            return;
        }
    }

    private void Cofnij_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (!e.Value)
            return;

        int lacznie = Preferences.Get("LacznieWypito", 0);
        int cel = Preferences.Get("CelMl", 2000);
        int progres = Preferences.Get("Progres", 0);

        var progres_info = new NotificationRequest
        {
            NotificationId = 100,
            Title = "Pamiętaj o nawadnianiu",
            Description = $"Udało ci się wypić {lacznie}ml z {cel}ml. To już {progres}%",
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = DateTime.Now.AddSeconds(2)
            }
        };

        LocalNotificationCenter.Current.Show(progres_info);
    }

    private async void Wyczysc_Clicked(object sender, EventArgs e)
    {
        Preferences.Set("LacznieWypito", 0);
        Preferences.Set("CelMl", 2000);
        Preferences.Set("Progres", 0);

        await DisplayAlert("Reset", "Progres został wyzerowany", "OK");
        await Shell.Current.GoToAsync("..");
    }
}
using Plugin.LocalNotification;
namespace WaterTracker;

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
        if (!string.IsNullOrWhiteSpace(liczbaMl.Text))

        {
            if (int.TryParse(liczbaMl.Text, out int Ml))
			{
				
			}
			else
			{
				bledy.Text = "Wprowadzono niepoprawne dane.";
			}
		}

        //powiadomienie
        var selectedTime = timePicker.Time;
        var now = DateTime.Now;

        // Ustal datę pierwszego powiadomienia
        var notifyDateTime = DateTime.Today.Add(selectedTime);
        //if (notifyDateTime <= now)
            //notifyDateTime = notifyDateTime.AddDays(1);

        // Stwórz powiadomienie
        var notification = new NotificationRequest
        {
            NotificationId = 200,
            Title = "Przypomnienie",
            Description = "Pamiętaj o stałym nawadnianiu",
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = notifyDateTime,
            }
        };

        LocalNotificationCenter.Current.Show(notification);
    }
}
using CommunityToolkit.Maui.Alerts;

namespace ColorMaker
{
    public partial class MainPage : ContentPage
    {
        string hexValue;
        bool isRandom = false;
        public MainPage()
        {
            InitializeComponent();
        }

        private void slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (!isRandom)
            {
                var red = sldRed.Value;
                var green = sldGreen.Value;
                var blue = sldBlue.Value;

                Color color = Color.FromRgb(red, green, blue);

                SetColor(color);
            }
        }

        private void SetColor(Color color)
        {
            btnRandom.BackgroundColor = color;
            btnRandom.TextColor = 
                color.ToHex() == "#FFFFFF" 
                ? Color.FromArgb("#000000")
                : Color.FromArgb("#FFFFFF");
            Container.BackgroundColor = color;
            hexValue = color.ToHex();
            lblHex.Text = hexValue;
        }

        private void btnRandom_Clicked(object sender, EventArgs e)
        {
            isRandom = true;
            var random = new Random();
            var randomColor1 = random.Next(0, 256);
            var randomColor2 = random.Next(0, 256);
            var randomColor3 = random.Next(0, 256);

            var color = Color.FromRgb(
                randomColor1,
                randomColor2,
                randomColor3);

            SetColor(color);

            sldRed.Value = color.Red;
            sldGreen.Value = color.Green;
            sldBlue.Value = color.Blue;
            isRandom = false;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(hexValue);
            var toast = Toast.Make("Color copied",
                CommunityToolkit.Maui.Core.ToastDuration.Short,
                12);
            await toast.Show();
        }
    }
}
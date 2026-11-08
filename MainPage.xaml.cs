namespace Emajstor
{
    public partial class MainPage : ContentPage
    {
       
        public MainPage()
        {
            InitializeComponent();
        }

        private async void NavigationOnClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(Profile));
        }
    }
}

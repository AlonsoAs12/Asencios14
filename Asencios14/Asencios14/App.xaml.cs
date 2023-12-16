
using Asencios14.Views;
using Xamarin.Forms;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new NavigationPage(new EstudiantePage());
    }
}

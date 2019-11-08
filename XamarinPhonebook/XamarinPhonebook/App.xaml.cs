using Xamarin.Forms;
using XamarinPhonebook.Models;
using XamarinPhonebook.Services;
using XamarinPhonebook.Services.Abstact;
using XamarinPhonebook.Views;

namespace XamarinPhonebook
{
    public partial class App : Application
    {
        public static IDataStorage<Contact> RandomUserDataStorage { get; private set; }
        public App()
        {
            InitializeComponent();
            DependencyService.Register<RandomUserDataStorage>();
            MainPage = new NavigationPage(new PhonebookPage());
            RandomUserDataStorage = new RandomUserDataStorage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
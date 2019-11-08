using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinPhonebook.Models;
using XamarinPhonebook.ViewModels;

namespace XamarinPhonebook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Phonebook : ContentPage
    {
        public PhonebookViewModel PhonebookViewModel { get; set; }

        public Phonebook()
        {
            PhonebookViewModel = new PhonebookViewModel();
            InitializeComponent();
            BindingContext = PhonebookViewModel;
            PhoneList.ItemsSource = PhonebookViewModel.Contacts;
        }

        protected override void OnAppearing()
        {
            if (!PhonebookViewModel.Contacts.Any())
                PhonebookViewModel.LoadContactsCommand.Execute(null);
            base.OnAppearing();
        }

        private async void PhoneList_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var contact = e.Item as Contact;
            await Navigation.PushAsync(new ContactInfoPage(new ContactViewModel {Contact = contact}));
        }
    }
}
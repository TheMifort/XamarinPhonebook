using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinPhonebook.Models;
using XamarinPhonebook.ViewModels;

namespace XamarinPhonebook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhonebookPage : ContentPage
    {
        public PhonebookViewModel PhonebookViewModel { get; set; }

        public PhonebookPage()
        {
            PhonebookViewModel = new PhonebookViewModel();
            InitializeComponent();
            BindingContext = PhonebookViewModel;
            PhoneList.ItemsSource = PhonebookViewModel.Contacts;
        }

        protected override void OnAppearing()
        {
            PhonebookViewModel.LoadContactsCommand.Execute(null);
            MessagingCenter.Subscribe<PhonebookViewModel>(this,"ScrollToTop", e =>
            {
                PhoneList.ScrollTo(e.Contacts.FirstOrDefault(), ScrollToPosition.MakeVisible,
                    false);
            });
            base.OnAppearing();
        }

        private async void PhoneList_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var contact = e.Item as Contact;
            await Navigation.PushAsync(new ContactInfoPage(new ContactViewModel {Contact = contact}));
        }

        private void PhoneList_OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            if (PhonebookViewModel.Contacts.Count == 0)
                return;

            if (e.Item == PhonebookViewModel.Contacts[PhonebookViewModel.Contacts.Count - 1])
            {
                PhonebookViewModel.LoadContactsCommand.Execute(null);
            }
        }
    }
}
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinPhonebook.ViewModels;

namespace XamarinPhonebook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactInfoPage : ContentPage
    {
        private ContactViewModel _contactViewModel;

        public ContactInfoPage(ContactViewModel contactViewModel)
        {
            _contactViewModel = contactViewModel;
            InitializeComponent();
            BindingContext = _contactViewModel;
        }
    }
}
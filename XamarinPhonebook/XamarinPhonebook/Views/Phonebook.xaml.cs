using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
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
    }
}
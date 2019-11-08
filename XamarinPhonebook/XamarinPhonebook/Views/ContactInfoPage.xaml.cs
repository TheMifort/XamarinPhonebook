using System;
using System.Collections.Generic;
using Stormlion.PhotoBrowser;
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
                //Call.Icon = Iconize.FindIconForKey("fas-address-book").Key;
        }

        private void ImageTapped(object sender, EventArgs e)
        {
            new PhotoBrowser
            {
                Photos = new List<Photo>
                {
                    new Photo
                    {
                        URL = _contactViewModel.Contact.PhotoLargeUrl,
                        Title = _contactViewModel.Contact.FullName
                    }
                },
                EnableGrid = true
            }.Show();
        }
    }
}
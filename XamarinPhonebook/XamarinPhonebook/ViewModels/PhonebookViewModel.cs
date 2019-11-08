using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using RandomUserSharp;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using XamarinPhonebook.Models;

namespace XamarinPhonebook.ViewModels
{
    public class PhonebookViewModel : BaseViewModel
    {
        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();
        public ICommand LoadContactsCommand { get; set; }
        
        public PhonebookViewModel()
        {
            LoadContactsCommand = new Command(async () =>
            {
                var contacts = await new RandomUserClient().GetRandomUsersAsync(1000);
                var mappedContacts = contacts.Select(e => new Contact
                {
                    Email = e.Email,
                    FirstName = e.Name.First,
                    LastName = e.Name.Last,
                    PhoneNumber = e.Phone,
                    PhotoThumbnailUrl = e.PictureInfo.Thumbnail.AbsoluteUri,
                    PhotoMediumUrl = e.PictureInfo.Medium.AbsoluteUri,
                    PhotoLargeUrl = e.PictureInfo.Large.AbsoluteUri
                }); //TODO Automapper

                Contacts.Clear();
                mappedContacts.ForEach(e => Contacts.Add(e));
            });
        }
    }
}
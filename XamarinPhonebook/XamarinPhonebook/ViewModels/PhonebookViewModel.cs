using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinPhonebook.Models;
using XamarinPhonebook.Services.Abstact;

namespace XamarinPhonebook.ViewModels
{
    public class PhonebookViewModel : BaseViewModel
    {
        private string _searchText;
        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();
        public ICommand LoadContactsCommand { get; }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                Contacts.Clear();
                LoadContactsCommand.Execute(null);
                MessagingCenter.Send(this, "ScrollToTop");
            }
        }

        public PhonebookViewModel()
        {
            LoadContactsCommand = new Command(async () =>
            {
                var dataStorage = DependencyService.Get<IDataStorage<Contact>>();
                if (!dataStorage.IsLoaded)
                    await dataStorage.LoadAsync(1000);

                var contacts = await dataStorage.GetAsync(40, SearchText);
                contacts.ForEach(e => Contacts.Add(e));
            });
        }
    }
}
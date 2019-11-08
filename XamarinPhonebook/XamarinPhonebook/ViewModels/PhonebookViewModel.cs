using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinPhonebook.Models;
using XamarinPhonebook.Services.Abstact;

namespace XamarinPhonebook.ViewModels
{
    public class PhonebookViewModel : BaseViewModel
    {
        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();
        public ICommand LoadContactsCommand { get; }

        public PhonebookViewModel()
        {
            LoadContactsCommand = new Command(async () =>
            {
                var dataStorage = DependencyService.Get<IDataStorage<Contact>>(DependencyFetchTarget.GlobalInstance);
                if (!dataStorage.IsLoaded)
                    await dataStorage.LoadAsync(1000);

                var contacts = await dataStorage.GetAsync(40);
                contacts.ForEach(e => Contacts.Add(e));
            });
        }
    }
}
using XamarinPhonebook.Models;

namespace XamarinPhonebook.ViewModels
{
    public class ContactViewModel : BaseViewModel
    {
        public Contact Contact { get; set; }

        public ContactViewModel()
        {
            Title = "Контакт";
        }
    }
}
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinPhonebook.Models;

namespace XamarinPhonebook.ViewModels
{
    public class ContactViewModel : BaseViewModel
    {
        public Contact Contact { get; set; }
        public ICommand Call { get; }
        public ICommand Sms { get; }

        public ContactViewModel()
        {
            Call = new Command(async () => { await Launcher.OpenAsync($"tel:{Contact.PhoneNumber}"); });
            Sms = new Command(async () => { await Launcher.OpenAsync($"sms:{Contact.PhoneNumber}"); });
        }
    }
}
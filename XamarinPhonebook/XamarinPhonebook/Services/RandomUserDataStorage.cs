using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RandomUserSharp;
using XamarinPhonebook.Models;
using XamarinPhonebook.Services.Abstact;

namespace XamarinPhonebook.Services
{
    public class RandomUserDataStorage : IDataStorage<Contact>
    {
        private List<Contact> _contacts;
        private int _currentNumber;

        public bool IsLoaded { get; private set; }

        public async Task LoadAsync(int count)
        {
            using (var randomUserClient = new RandomUserClient())
            {
                var contacts = await randomUserClient.GetRandomUsersAsync(count);
                _contacts = contacts.Select(e => new Contact
                {
                    Email = e.Email,
                    FirstName = e.Name.First,
                    LastName = e.Name.Last,
                    PhoneNumber = e.Phone,
                    PhotoThumbnailUrl = e.PictureInfo.Thumbnail.AbsoluteUri,
                    PhotoMediumUrl = e.PictureInfo.Medium.AbsoluteUri,
                    PhotoLargeUrl = e.PictureInfo.Large.AbsoluteUri
                }).ToList(); //TODO Automapper
            }
            IsLoaded = true;
        }

        public Task<List<Contact>> GetAsync(int count)
        {
            var result = _contacts.Skip(_currentNumber).Take(count).ToList();
            _currentNumber += count;
            return Task.FromResult(result);
        }
    }
}
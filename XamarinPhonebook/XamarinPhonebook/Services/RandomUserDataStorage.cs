using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RandomUserSharp;
using XamarinPhonebook.Helpers;
using XamarinPhonebook.Models;
using XamarinPhonebook.Services.Abstact;

namespace XamarinPhonebook.Services
{
    public class RandomUserDataStorage : IDataStorage<Contact>
    {
        private List<Contact> _contacts;
        private int _currentNumber;
        private string _currentSearch;
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

        public Task<List<Contact>> GetAsync(int count, string search = default)
        {
            if (_currentSearch != search)
            {
                _currentNumber = 0;
                _currentSearch = search;
            }


            var result = _contacts.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                var splitted = search.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
                result = splitted.Aggregate(result, (current, searchEntry) => current.Where(e => e.FirstName.ContainsIgnoreCasing(searchEntry) || e.LastName.ContainsIgnoreCasing(searchEntry)));
            }

            result = result.Skip(_currentNumber).Take(count);

            _currentNumber += count;
            return Task.FromResult(result.ToList());
        }
    }
}
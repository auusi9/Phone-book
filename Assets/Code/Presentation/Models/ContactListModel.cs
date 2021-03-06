using System.Collections.Generic;
using System.Linq;
using Code.Data.Vo;
using Code.Presentation.Notifications;
using Zenject;

namespace Code.Presentation.Models
{
    public class ContactListModel : IContactListModel
    {
        [Inject] private SignalBus _signalBus;
        private SortType _currentSortType = SortType.Alphabet;
        private List<ContactVo> _contacts = new List<ContactVo>();

        public void SetUserContacts(ContactVo[] contacts)
        {
            if (contacts == null || contacts.Length == 0)
            {
                return;
            }
            
            _contacts = new List<ContactVo>(contacts);

            SortByCurrentSortType();
        }

        private void SortByCurrentSortType(List<ContactVo> contacts = null)
        {            
            switch (_currentSortType)
            {
                case SortType.Alphabet:
                    SortContactsByAlphabet(contacts);
                    break;
                case SortType.Date:
                    SortContactsByDate(contacts);
                    break;
            }
        }

        public void SortContactsByAlphabet(List<ContactVo> contacts = null)
        {
            if (contacts == null)
            {
                contacts = _contacts;
            }
            
            _currentSortType = SortType.Alphabet;
            _signalBus.Fire(new ContactListRefreshedNotification(contacts.OrderBy(x => x.Name).ToArray()));
        }

        public void SortContactsByDate(List<ContactVo> contacts = null)
        {
            if (contacts == null)
            {
                contacts = _contacts;
            }
            
            _currentSortType = SortType.Date;
            _signalBus.Fire(new ContactListRefreshedNotification(contacts.OrderByDescending(x => x.DateAdded).ToArray()));
        }

        public bool SaveContactIfValid(ContactVo contact)
        {
            if (!contact.IsValid())
            {
                _signalBus.Fire(new ContactDetailsNotValidNotification(contact.GetMissingDetails()));
                return false;
            }
            
            ContactVo savedContact = _contacts.FirstOrDefault(x => x.Id == contact.Id);
            
            if (savedContact == null)
            {
                int maxId = 0;
                if (_contacts.Count > 0)
                {
                    maxId = _contacts.Max(x => x.Id) + 1;
                }
                
                ContactVo newContact = new ContactVo(maxId, contact);
                _contacts.Add(newContact);
                SortByCurrentSortType();
                return true;
            }
            
            savedContact.Name = contact.Name;
            savedContact.LastName = contact.LastName;
            savedContact.Email = contact.Email;
            savedContact.Description = contact.Description;
            savedContact.PhoneNumber = contact.PhoneNumber;
            savedContact.TwitterHandle = contact.TwitterHandle;
            SortByCurrentSortType();

            return true;
        }

        public bool RemoveContact(int contactContactId)
        {
            ContactVo savedContact = _contacts.FirstOrDefault(x => x.Id == contactContactId);

            if (savedContact == null)
            {
                return false;
            }

            _contacts.Remove(savedContact);
            
            SortByCurrentSortType();
            return true;
        }

        public void SearchContact(string search)
        {
            List<ContactVo> contactsFound = _contacts.Where(x => x.Name.Contains(search) || x.LastName.Contains(search)).ToList();
            SortByCurrentSortType(contactsFound);
        }

        public void CancelSearch()
        {
            SortByCurrentSortType();
        }

        public ContactVo[] GetContacts()
        {
            return _contacts.ToArray();
        }

        private enum SortType
        {
            Alphabet,
            Date
        }
    }
}
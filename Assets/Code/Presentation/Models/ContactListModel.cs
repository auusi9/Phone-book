using System.Collections.Generic;
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
            _contacts = new List<ContactVo>(contacts);

            switch (_currentSortType)
            {
                case SortType.Alphabet:
                    SortContactsByAlphabet();
                    break;
                case SortType.Date:
                    SortContactsByDate();
                    break;
            }
        }

        public void SortContactsByAlphabet()
        {
            _currentSortType = SortType.Alphabet;
            _signalBus.Fire(new ContactListRefreshedNotification(_contacts.ToArray()));
        }

        public void SortContactsByDate()
        {
            _currentSortType = SortType.Date;
            _signalBus.Fire(new ContactListRefreshedNotification(_contacts.ToArray()));
        }
        
        private enum SortType
        {
            Alphabet,
            Date
        }
    }
}
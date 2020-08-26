using System.Collections.Generic;
using Code.Data.Vo;

namespace Code.Presentation.Models
{
    public interface IContactListModel
    {
        void SetUserContacts(ContactVo[] contacts);
        void SortContactsByAlphabet(List<ContactVo> contacts = null);
        void SortContactsByDate(List<ContactVo> contacts = null);
        bool SaveContactIfValid(ContactVo contact);
        bool RemoveContact(int contactContactId);
        void SearchContact(string search);
        void CancelSearch();
        ContactVo[] GetContacts();
    }
}
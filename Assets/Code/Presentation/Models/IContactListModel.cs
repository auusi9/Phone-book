using Code.Data.Vo;

namespace Code.Presentation.Models
{
    public interface IContactListModel
    {
        void SetUserContacts(ContactVo[] contacts);
        void SortContactsByAlphabet();
        void SortContactsByDate();
        bool SaveContactIfValid(ContactVo contact);
        bool RemoveContact(int contactContactId);
        ContactVo[] GetContacts();
    }
}
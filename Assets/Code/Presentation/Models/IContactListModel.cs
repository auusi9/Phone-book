using Code.Data.Vo;

namespace Code.Presentation.Models
{
    public interface IContactListModel
    {
        void SetUserContacts(ContactVo[] contacts);
        void SortContactsByAlphabet();
        void SortContactsByDate();
    }
}
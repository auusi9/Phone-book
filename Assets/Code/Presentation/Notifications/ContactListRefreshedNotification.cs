using Code.Data.Vo;

namespace Code.Presentation.Notifications
{
    public class ContactListRefreshedNotification
    {
        public ContactVo[] Contacts { get; }

        public ContactListRefreshedNotification(ContactVo[] contacts)
        {
            Contacts = contacts;
        }
    }
}
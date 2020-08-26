using Code.Data.Vo;

namespace Code.Presentation.Notifications
{
    public class ContactDetailsNotValidNotification
    {
        public ContactMissingRequiredDetailsDto MissingDetails { get; }

        public ContactDetailsNotValidNotification(ContactMissingRequiredDetailsDto missingDetails)
        {
            MissingDetails = missingDetails;
        }
    }
}
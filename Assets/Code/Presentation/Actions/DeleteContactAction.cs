namespace Code.Presentation.Actions
{
    public class DeleteContactAction
    {
        public int ContactId { get; }

        public DeleteContactAction(int contactId)
        {
            ContactId = contactId;
        }
    }
}
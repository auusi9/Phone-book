using Code.Presentation.Actions;
using Code.Presentation.Models;
using Zenject;

namespace Code.Presentation.Controllers
{
    public class DeleteContactController : IController<DeleteContactAction>
    {
        [Inject] private IContactListModel _contactListModel;
        
        public void Execute(DeleteContactAction contact)
        {
            if (_contactListModel.RemoveContact(contact.ContactId))
            {
                //REMOVE FROM PERSISTENCE
            }
        }
    }
}
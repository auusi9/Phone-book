using Code.Data.Ports;
using Code.Presentation.Actions;
using Code.Presentation.Models;
using Zenject;

namespace Code.Presentation.Controllers
{
    public class DeleteContactController : IController<DeleteContactAction>
    {
        [Inject] private IContactListModel _contactListModel;
        [Inject] private IPersistance _persistance;
        
        public void Execute(DeleteContactAction contact)
        {
            if (_contactListModel.RemoveContact(contact.ContactId))
            {
                _persistance.Save(_contactListModel.GetContacts());
            }
        }
    }
}
using Code.Data.Ports;
using Code.Data.Vo;
using Code.Presentation.Actions;
using Code.Presentation.Models;
using Zenject;

namespace Code.Presentation.Controllers
{
    public class SaveContactController : IController<SaveContactAction>
    {
        [Inject] private IContactListModel _contactListModel;
        [Inject] private IPersistance _persistance;
        
        public void Execute(SaveContactAction saveAction)
        {
            if (_contactListModel.SaveContactIfValid(saveAction.ContactVo))
            {
                _persistance.Save(_contactListModel.GetContacts());
            }
        }
    }
}
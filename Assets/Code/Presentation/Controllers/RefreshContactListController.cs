using System;
using Code.Data.Ports;
using Code.Data.Vo;
using Code.Presentation.Models;
using Zenject;

namespace Code.Presentation.Controllers
{
    public class RefreshContactListController : IController
    {
        [Inject] private IContactListModel _contactListModel;
        [Inject] private IPersistance _persistance;
        
        public async void Execute()
        {
            ContactVo[] contacts = await _persistance.Load<ContactVo[]>();
            
            _contactListModel.SetUserContacts(contacts);
        }

        private ContactVo CreateContactVo(int id)
        {
            return new ContactVo(id, "asdads", "asdasdasd", "sadasda", "asdasdasd", "asdasdasd",
                "asdasddasd", DateTime.Now);
        }
    }
}
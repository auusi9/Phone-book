using System;
using Code.Data.Vo;
using Code.Presentation.Models;
using Zenject;

namespace Code.Presentation.Controllers
{
    public class RefreshContactListController : IController
    {
        [Inject] private IContactListModel _contactListModel;
        
        public void Execute()
        {
            ContactVo[] contacts = new ContactVo[100];

            for (int i = 0; i < contacts.Length; i++)
            {
                contacts[i] = CreateContactVo(i);
            }
            
            _contactListModel.SetUserContacts(contacts);
        }

        private ContactVo CreateContactVo(int id)
        {
            return new ContactVo(id, "asdads", "asdasdasd", "sadasda", "asdasdasd", "asdasdasd",
                "asdasddasd", DateTime.Now);
        }
    }
}
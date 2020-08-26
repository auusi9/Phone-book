using Code.Presentation.Models;
using Zenject;

namespace Code.Presentation.Controllers
{
    public class CancelSearchController : IController
    {
        [Inject] private IContactListModel _contactListModel;
        
        public void Execute()
        {
            _contactListModel.CancelSearch();
        }
    }
}
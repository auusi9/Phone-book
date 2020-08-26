using Code.Presentation.Models;
using Zenject;

namespace Code.Presentation.Controllers
{
    public class SortContactsByAlphabetController : IController
    {
        [Inject] private IContactListModel _contactListModel;
        
        public void Execute()
        {
            _contactListModel.SortContactsByAlphabet();
        }
    }
}
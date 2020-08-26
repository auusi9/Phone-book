using Code.Presentation.Actions;
using Code.Presentation.Models;
using Zenject;

namespace Code.Presentation.Controllers
{
    public class SearchContactController : IController<SearchContactAction>
    {
        [Inject] private IContactListModel _contactListModel;
        public void Execute(SearchContactAction contact)
        {
            if (string.IsNullOrWhiteSpace(contact.Search))
            {
                _contactListModel.CancelSearch();
                return;
            }
            
            _contactListModel.SearchContact(contact.Search);
        }
    }
}
using Code.Data.Vo;
using Code.Presentation.Views.EditContact;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Presentation.Views.ContactList
{
    public class AddNewContactView : MonoBehaviour
    {
        [Inject] private EditContactMediator.Factory _factory;
        
        [SerializeField] private Button _button;
        
        void Start()
        {
            _button.onClick.AddListener(AddButtonPressed);   
        }

        private void AddButtonPressed()
        {
            _factory.Create(ContactVo.Empty());
        }

        void OnDestroy()
        {
            _button.onClick.RemoveListener(AddButtonPressed);   
        }
    }
}
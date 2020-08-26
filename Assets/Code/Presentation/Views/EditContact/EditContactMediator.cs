using Code.Data.Vo;
using Code.Presentation.Actions;
using Code.Presentation.Notifications;
using Code.Presentation.Views.EditContact.Details;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Presentation.Views.EditContact
{
    public class EditContactMediator : MonoBehaviour
    {
        [SerializeField] private ContactDetailElement _nameDetailElement;
        [SerializeField] private ContactDetailElement _lastNameDetailElement;
        [SerializeField] private ContactDetailElement _phoneDetailElement;
        [SerializeField] private ContactDetailElement _emailDetailElement;
        [SerializeField] private ContactDetailElement _twitterDetailElement;
        [SerializeField] private ContactDetailElement _descriptionDetailElement;
        [SerializeField] private Button _deleteContact;
        [SerializeField] private Button _saveContact;
        [SerializeField] private Button _cancelEditContact;

        [Inject] private SignalBus _signalBus;

        private ContactVo _editingContact;
        
        [Inject]
        public void Construct(ContactVo contactDetails)
        {
            _editingContact = contactDetails;
            SetData();
            
            _deleteContact.onClick.AddListener(DeleteContact);
            _saveContact.onClick.AddListener(SaveContact);
            _cancelEditContact.onClick.AddListener(CancelEdit);
            
            _signalBus.Subscribe<ContactListRefreshedNotification>(ContactListRefreshed);
            _signalBus.Subscribe<ContactDetailsNotValidNotification>(ContactDetailsNotValid);
        }

        private void OnDestroy()
        {
            _deleteContact.onClick.RemoveListener(DeleteContact);
            _saveContact.onClick.RemoveListener(SaveContact);
            _cancelEditContact.onClick.RemoveListener(CancelEdit);
            
            _signalBus.Unsubscribe<ContactListRefreshedNotification>(ContactListRefreshed);
            _signalBus.Unsubscribe<ContactDetailsNotValidNotification>(ContactDetailsNotValid);
        }

        private void CancelEdit()
        {
            Close();
        }
        
        private void ContactListRefreshed()
        {
            Close();
        }

        private void Close()
        {
            Destroy(gameObject);
        }

        private void ContactDetailsNotValid(ContactDetailsNotValidNotification contactDetailsNotValid)
        {
            if (contactDetailsNotValid.MissingDetails.Name)
            {
                _nameDetailElement.TriggerRequired();
            } 
            
            if (contactDetailsNotValid.MissingDetails.LastName)
            {
                _lastNameDetailElement.TriggerRequired();
            }
            
            if (contactDetailsNotValid.MissingDetails.PhoneNumber)
            {
                _phoneDetailElement.TriggerRequired();
            }
            
            if (contactDetailsNotValid.MissingDetails.Email)
            {
                _emailDetailElement.TriggerRequired();
            } 
            
            if (contactDetailsNotValid.MissingDetails.TwitterHandle)
            {
                _twitterDetailElement.TriggerRequired();
            }
            
            if (contactDetailsNotValid.MissingDetails.Description)
            {
                _descriptionDetailElement.TriggerRequired();
            }
        }

        private void SaveContact()
        {
            _editingContact.Name = _nameDetailElement.GetData();
            _editingContact.LastName = _lastNameDetailElement.GetData();
            _editingContact.PhoneNumber = _phoneDetailElement.GetData();
            _editingContact.Email = _emailDetailElement.GetData();
            _editingContact.TwitterHandle = _twitterDetailElement.GetData();
            _editingContact.Description = _descriptionDetailElement.GetData();
            
            _signalBus.Fire(new SaveContactAction(_editingContact));
        }

        private void DeleteContact()
        {
            _signalBus.Fire(new DeleteContactAction(_editingContact.Id));
        }

        private void SetData()
        {
            _nameDetailElement.SetData(_editingContact.Name);
            _lastNameDetailElement.SetData(_editingContact.LastName);
            _phoneDetailElement.SetData(_editingContact.PhoneNumber);
            _emailDetailElement.SetData(_editingContact.Email);
            _twitterDetailElement.SetData(_editingContact.TwitterHandle);
            _descriptionDetailElement.SetData(_editingContact.Description);
        }

        public class Factory : PlaceholderFactory<ContactVo, EditContactMediator>
        {
            
        }
    }
}
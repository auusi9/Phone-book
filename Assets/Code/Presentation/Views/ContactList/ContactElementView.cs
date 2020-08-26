using Code.Data.Vo;
using Code.Presentation.Views.EditContact;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Presentation.Views.ContactList
{
    public class ContactElementView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textMeshProUgui;
        [SerializeField] private Button _button;

        [Inject] private EditContactMediator.Factory _factory;

        private Transform _originalParent;
        private ContactVo _p;

        private void Awake()
        {
            _originalParent = transform.parent;
            _button.onClick.AddListener(ContactElementClicked);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(ContactElementClicked);
        }

        private void ContactElementClicked()
        {
            _factory.Create(_p);
        }

        private void Reset(Transform parent)
        {
            transform.SetParent(parent, false);
        }
    
        public void SetData(ContactVo p)
        {
            _p = p;
            _textMeshProUgui.SetText(p.Name + " " + p.LastName);
        }
    
        private void Despawn()
        {
            transform.SetParent(_originalParent, false);
            gameObject.SetActive(false);
        }
    
        public class Pool : MonoMemoryPool<Transform, ContactElementView>
        {
            protected override void Reinitialize(Transform transform, ContactElementView contactElement)
            {
                contactElement.Reset(transform);
            }

            protected override void OnDespawned(ContactElementView contactElement)
            {
                contactElement.Despawn();
            }
        }
    }
}

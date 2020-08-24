using System.Collections.Generic;
using System.Linq;
using Code.Data.Vo;
using Code.Presentation.Actions;
using Code.Presentation.Notifications;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Presentation.Views
{
    public class ContactListScrollRect : LoopVerticalScrollRect
    {
        [Inject] private LoopScrollContactElementPrefabSource _contactElementPrefabSource;
        [Inject] private SignalBus _signalBus;
        private List<ContactElementView> _spawnedContactElements = new List<ContactElementView>();
        private LoopScrollContactDataArraySource<ContactVo> _data; 
        
        public override LoopScrollPrefabSource prefabSource
        {
            get { return _contactElementPrefabSource; }
        }

        protected override void Start()
        {
            base.Start();
            _signalBus.Subscribe<ContactListRefreshedNotification>(ContactListRefreshed);
            
            _signalBus.Fire<RefreshContactListAction>();
        }

        private void OnDestroy()
        {
            _signalBus.Unsubscribe<ContactListRefreshedNotification>(ContactListRefreshed);
        }

        private void ContactListRefreshed(ContactListRefreshedNotification obj)
        {
            _data = new LoopScrollContactDataArraySource<ContactVo>(obj.Contacts);
            totalCount = obj.Contacts.Length;
            RefillCells(0, true);
        }

        protected override void ReturnObject(Transform transform)
        {
            ContactElementView contactElement = _spawnedContactElements.FirstOrDefault(x => x.transform == transform);

            if (contactElement == null)
            {
                return;
            }

            _spawnedContactElements.Remove(contactElement);
            _contactElementPrefabSource.ReturnObject(contactElement);
        }
        
        protected override RectTransform InstantiateNextItem(int itemIdx)
        {            
            ContactElementView contactElement = _contactElementPrefabSource.GetObject(content);
            _spawnedContactElements.Add(contactElement);
            _data.ProvideData(contactElement, itemIdx);
            contactElement.gameObject.SetActive(true);
            
            return contactElement.transform as RectTransform;
        }

        protected override void ProvideData(Transform transform, int idx)
        {
            ContactElementView contactElement = _spawnedContactElements.FirstOrDefault(x => x.transform == transform);

            if (contactElement == null)
            {
                return;
            }
            
            _data.ProvideData(contactElement, idx);
        }
    }
}
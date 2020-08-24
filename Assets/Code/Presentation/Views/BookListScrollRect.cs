using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Presentation.Views
{
    public class BookListScrollRect : LoopVerticalScrollRect
    {
        [Inject] private LoopScrollContactElementPrefabSource _contactElementPrefabSource;

        private List<ContactElementView> _spawnedContactElements = new List<ContactElementView>();
        private LoopScrollContactDataArraySource<object> _data; 
        
        public override LoopScrollPrefabSource prefabSource
        {
            get { return _contactElementPrefabSource; }
        }

        protected override void Start()
        {
            base.Start();
            
            
            string[] strings = new string[100];

            for (int i = 0; i < strings.Length; i++)
            {
                strings[i] = "Bing Bong " + i;
            }
            _data = new LoopScrollContactDataArraySource<object>(strings);
            totalCount = strings.Length;
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
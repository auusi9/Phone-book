using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Presentation.Views.ContactList
{
    public class LoopScrollContactElementPrefabSource : LoopScrollPrefabSource
    {
        [Inject] private ContactElementView.Pool _pool;
        
        public ContactElementView GetObject(Transform parent)
        {
            return _pool.Spawn(parent);
        }

        public void ReturnObject(ContactElementView go)
        {
            _pool.Despawn(go);
        }
    }
}
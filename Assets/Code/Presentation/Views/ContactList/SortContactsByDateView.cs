using Code.Presentation.Actions;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Presentation.Views.ContactList
{
    public class SortContactsByDateView : MonoBehaviour
    {
        [Inject] private SignalBus _signalBus;
        [SerializeField] private Button _button;
        
        void Start()
        {
            _button.onClick.AddListener(SortByDate);   
        }

        private void SortByDate()
        {
            _signalBus.Fire<SortContactsByDateAction>();
        }

        void OnDestroy()
        {
            _button.onClick.RemoveListener(SortByDate);   
        }
    }
}
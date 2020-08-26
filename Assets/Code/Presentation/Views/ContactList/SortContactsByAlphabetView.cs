using Code.Presentation.Actions;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Presentation.Views.ContactList
{
    public class SortContactsByAlphabetView : MonoBehaviour
    {
        [Inject] private SignalBus _signalBus;
        [SerializeField] private Button _button;
        
        void Start()
        {
            _button.onClick.AddListener(SortByAlphabet);   
        }

        private void SortByAlphabet()
        {
            _signalBus.Fire<SortContactsByAlphabetAction>();
        }

        void OnDestroy()
        {
            _button.onClick.RemoveListener(SortByAlphabet);   
        }
    }
}
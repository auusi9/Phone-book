using Code.Presentation.Actions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Presentation.Views.ContactList
{
    public class SearchButtonView : MonoBehaviour
    {
        [Inject] private SignalBus _signalBus;
        [SerializeField] private Button _button;
        [SerializeField] private TMP_InputField _tmpInputField;
        [SerializeField] private Animator _animator;

        private bool _searching = false;
        private int _searchingHash = Animator.StringToHash("Searching");
        private int _directionHash = Animator.StringToHash("Direction");
        
        void Start()
        {
            _button.onClick.AddListener(SearchButtonPressed); 
            _tmpInputField.onValueChanged.AddListener(Search);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(SearchButtonPressed); 
            _tmpInputField.onValueChanged.RemoveListener(Search);
        }

        private void Search(string arg0)
        {
            _signalBus.Fire(new SearchContactAction(arg0));
        }

        private void SearchButtonPressed()
        {
            _searching = !_searching;
        
            _animator.SetBool(_searchingHash, _searching);
        
            float direction = 1.0f;
            if (!_searching)
            {
                CancelSearch();
                direction = -1.0f;
            }
        
            _signalBus.Fire(new SearchContactAction(_tmpInputField.text));
            _animator.SetFloat(_directionHash, direction);
        }

        private void CancelSearch()
        {
            _tmpInputField.SetTextWithoutNotify(string.Empty);
            _signalBus.Fire<CancelSearchAction>();
        }
    }
}

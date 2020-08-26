using TMPro;
using UnityEngine;

namespace Code.Presentation.Views.EditContact.Details
{
    public class ContactDetailElement : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private Animator _animator;
        
        private string _value;
        private int _requiredTrigger = Animator.StringToHash("RequiredElement");
        
        private void Start()
        {
            _inputField.onValueChanged.AddListener(ValueChanged);
        }

        private void OnDestroy()
        {
            _inputField.onValueChanged.RemoveListener(ValueChanged);
        }

        private void ValueChanged(string value)
        {
            _value = value;
        }

        public void TriggerRequired()
        {
            _animator.SetTrigger(_requiredTrigger);
        }

        public void SetData(string data)
        {
            _value = data;
            _inputField.SetTextWithoutNotify(_value);
        }

        public string GetData()
        {
            return _value;
        }
    }
}
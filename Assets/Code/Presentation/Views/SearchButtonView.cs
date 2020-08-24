using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchButtonView : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Animator _animator;

    private bool _searching = false;
    private int _searchingHash = Animator.StringToHash("Searching");
    private int _directionHash = Animator.StringToHash("Direction");
    void Start()
    {
        _button.onClick.AddListener(SearchButtonPressed);   
    }

    private void SearchButtonPressed()
    {
        _searching = !_searching;
        
        _animator.SetBool(_searchingHash, _searching);
        
        float direction = 1.0f;
        if (!_searching)
        {
            direction = -1.0f;
        }
        
        _animator.SetFloat(_directionHash, direction);
    }
}

using System;
using Code.Data.Vo;
using TMPro;
using UnityEngine;
using Zenject;

public class ContactElementView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshProUgui;

    private Transform _originalParent;

    private void Awake()
    {
        _originalParent = transform.parent;
    }

    private void Reset(Transform parent)
    {
        transform.SetParent(parent, false);
    }
    
    public void SetData(ContactVo p)
    {
        _textMeshProUgui.SetText(p.Name + p.Id);
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

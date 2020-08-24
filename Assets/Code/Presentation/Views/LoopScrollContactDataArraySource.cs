using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Presentation.Views
{
    public class LoopScrollContactDataArraySource<T> : LoopScrollArraySource<T> where T : class
    {
        public LoopScrollContactDataArraySource(T[] objectsToFill) : base(objectsToFill)
        {
            
        }

        public void ProvideData(ContactElementView contactElementView, int idx)
        {
            contactElementView.SetData(objectsToFill[idx] as String);
        }
    }
}
using System;
using Code.Data.Vo;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Presentation.Views
{
    public class LoopScrollContactDataArraySource<T> : LoopScrollArraySource<T> where T : ContactVo
    {
        public LoopScrollContactDataArraySource(T[] objectsToFill) : base(objectsToFill)
        {
            
        }

        public void ProvideData(ContactElementView contactElementView, int idx)
        {
            contactElementView.SetData(objectsToFill[idx]);
        }
    }
}
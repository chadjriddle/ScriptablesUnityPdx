using System;
using Scriptables.References;
using UnityEngine;

namespace Demos.MeterGame.Components
{
    public class SetYFromPercentOfParent : MonoBehaviour
    {

        [SerializeField] private FloatReference _percentOfParent;

        private RectTransform _parentRectTransform;

        // Use this for initialization
        void Start ()
        {
            _parentRectTransform = transform.parent.GetComponent<RectTransform>();

            if (_parentRectTransform == null)
            {
                throw new Exception("Parent must have a RectTransform");
            }

            SetPosition();
            _percentOfParent.ValueChanged += SetPosition;
        }

        private void SetPosition()
        {
            var parentHeight = transform.parent.GetComponent<RectTransform>().rect.height;
            var newPosY = parentHeight * _percentOfParent;
            var rectTrans = GetComponent<RectTransform>();
            rectTrans.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, newPosY, rectTrans.rect.height);
        }
    }
}

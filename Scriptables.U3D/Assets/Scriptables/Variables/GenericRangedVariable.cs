using UnityEngine;

namespace Scriptables.Variables
{
    public abstract class GenericRangedVariable<T> : GenericVariable<T>
    {
        [SerializeField] private bool _useRange;
        [SerializeField] private T _minValue;
        [SerializeField] private T _maxValue;

        public T MinValue
        {
            get { return _minValue; }
            set { _minValue = value; }
        }

        public T MaxValue
        {
            get { return _maxValue; }
            set { _maxValue = value; }
        }

        public bool UseRange
        {
            get { return _useRange; }
            set { _useRange = value; }
        }

        public void SetRange(T min, T max)
        {
            _useRange = true;
            _minValue = min;
            _maxValue = max;
        }

        public override void SetValue(T value)
        {
            if (_useRange)
            {
                value = ClampValue(value);
            }

            base.SetValue(value);
        }

        public abstract T ClampValue(T value);

        public override void OnValidate()
        {
            // call SetValue to ensure clamping is applied
            SetValue(Value);
            // Need to manunally call OnValueChanged since the backing field is set by the inspector
            OnValueChanged();
        }
    }
}
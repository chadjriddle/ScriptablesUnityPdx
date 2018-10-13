using System;
using UnityEngine;

namespace Scriptables.Variables
{
    public abstract class GenericVariable<T> : ScriptableObject
    {
        [SerializeField]
        private T _value;

        public T Value => _value;

        public event Action ValueChanged;

        public virtual void SetValue(T value)
        {
            if (!Equals(_value, value))
            {
                _value = value;
                OnValueChanged();
            }
        }

        public void SetValue(GenericVariable<T> value)
        {
            SetValue(value.Value);
        }

        public static implicit operator T(GenericVariable<T> variable)
        {
            return variable.Value;
        }

        public virtual void ApplyChange(T amount)
        {
            SetValue(amount);
        }

        public virtual void ApplyChange(GenericVariable<T> amount)
        {
            SetValue(amount);
        }

        public virtual void OnValidate()
        {
            OnValueChanged();
        }

        protected void OnValueChanged()
        {
            var handler = ValueChanged;
            handler?.Invoke();
        }
    }
}
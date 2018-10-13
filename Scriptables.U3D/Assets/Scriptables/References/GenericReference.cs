using System;
using Scriptables.Variables;
using UnityEngine;

namespace Scriptables.References
{
    [Serializable]
    public abstract class GenericReference<T, TV> :
        ISerializationCallbackReceiver
        where TV : GenericVariable<T>
    {
        public event Action ValueChanged;

        [SerializeField]
        private bool _useConstant = true;

        [SerializeField]
        private T _constantValue;

        [SerializeField]
        private TV _variable;

        [SerializeField]
        public bool DebugEnabled = true;

        public bool IsConstant => _useConstant;

        public T ConstantValue
        {
            get { return _constantValue; }
            set
            {
                _useConstant = true;
                _constantValue = value;
            }
        }

        public TV Variable
        {
            get { return _variable; }
            set
            {
                if (_variable != null)
                {
                    _variable.ValueChanged -= OnValueChanged;
                }

                _variable = value;
                if (_variable != null)
                {
                    _useConstant = false;
                    _variable.ValueChanged += OnValueChanged;
                }
                else
                {
                    _useConstant = true;
                }
            }
        }

        protected GenericReference()
        { }

        protected GenericReference(T value)
        {
            _useConstant = true;
            _constantValue = value;
        }

        protected GenericReference(TV variable)
        {
            Variable = variable;
        }

        public T Value => _useConstant ? _constantValue : (_variable != null ? _variable.Value : default(T));

        public static implicit operator T(GenericReference<T, TV> reference)
        {
            return reference.Value;
        }

        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {
            if (_variable != null)
            {
                _variable.ValueChanged -= OnValueChanged;
                _variable.ValueChanged += OnValueChanged;
            }
        }

        public void SetValue(T value)
        {
            if (Equals(value, Value) == false)
            {
                if (_useConstant)
                {
                    _constantValue = value;
                    OnValueChanged();
                }
                else
                {
                    if (DebugEnabled && _variable == null)
                    {
                        Debug.LogErrorFormat("{0} Attempt to set value when Variable is NULL", GetType().Name);
                    }

                    _variable?.SetValue(value);
                }
            }
        }

        public void SetValue(TV value)
        {
            SetValue(value.Value);
        }

        public virtual void ApplyChange(T amount)
        {
            if (_useConstant)
            {
                ApplyChangeToConstant(amount);
            }
            else
            {
                _variable.ApplyChange(amount);
            }
        }

        public virtual void ApplyChange(TV amount)
        {
            if (_useConstant)
            {
                ApplyChangeToConstant(amount.Value);
            }
            else
            {
                _variable.ApplyChange(amount);
            }
        }

        protected virtual void ApplyChangeToConstant(T amount)
        {
            _constantValue = amount;
        }

        protected void OnValueChanged()
        {
            var handler = ValueChanged;
            handler?.Invoke();
        }
    }
}
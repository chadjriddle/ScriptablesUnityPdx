using System;
using Scriptables.Variables;
using UnityEngine;

namespace Scriptables.References
{
    [Serializable]
    public class ColorReference : GenericReference<Color, ColorVariable>
    {
        public ColorReference() : base()
        {
        }

        public ColorReference(Color constant) : base(constant)
        {
        }

        public ColorReference(ColorVariable variable) : base(variable)
        {
        }
    }
}
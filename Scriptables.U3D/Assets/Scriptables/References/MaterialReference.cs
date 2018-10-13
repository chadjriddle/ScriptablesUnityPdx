using System;
using Scriptables.Variables;
using UnityEngine;

namespace Scriptables.References
{
    [Serializable]
    public class MaterialReference : GenericReference<Material, MaterialVariable>
    {
        public MaterialReference() : base()
        {
        }

        public MaterialReference(Material constant) : base(constant)
        {
        }

        public MaterialReference(MaterialVariable variable) : base(variable)
        {
        }
    }
}
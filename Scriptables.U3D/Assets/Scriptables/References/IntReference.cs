using System;
using Scriptables.Variables;

namespace Scriptables.References
{
    [Serializable]
    public class IntReference : GenericReference<int, IntVariable>
    {
        public IntReference() : base()
        {
        }

        public IntReference(int constant) : base(constant)
        {
        }

        public IntReference(IntVariable variable) : base(variable)
        {
        }
    }
}
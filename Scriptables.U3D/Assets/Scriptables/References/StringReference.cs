using System;
using Scriptables.Variables;

namespace Scriptables.References
{
    [Serializable]
    public class StringReference : GenericReference<string, StringVariable>
    {
        public StringReference() : base()
        {
        }

        public StringReference(string constant) : base(constant)
        {
        }

        public StringReference(StringVariable variable) : base(variable)
        {
        }
    }
}
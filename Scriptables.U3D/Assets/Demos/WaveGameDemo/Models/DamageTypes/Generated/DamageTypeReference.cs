using System;
using Scriptables.References;
using Demos.WaveGameDemo.Models.DamageTypes;


namespace Demos.WaveGameDemo.Models.DamageTypes.Generated
{
    [Serializable]
    public class DamageTypeReference : GenericReference<DamageType, DamageTypeVariable>
    {
        public DamageTypeReference() : base()
        {
        }

        public DamageTypeReference(DamageType constant) : base(constant)
        {
        }

        public DamageTypeReference(DamageTypeVariable variable) : base(variable)
        {
        }
    }
}
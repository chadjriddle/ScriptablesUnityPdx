using Scriptables.References;
using UnityEngine;

namespace Scriptables.Components
{
    public class ActiveByBoolReference : MonoBehaviour
    {

        public BoolReference IsActive;
        public BoolReference InvertIsActive;
        public GameObject TargetGameObject;

        // Update is called once per frame
        void Update () {
            if (TargetGameObject != null)
            {
                if (InvertIsActive == false)
                {
                    TargetGameObject.SetActive(IsActive.Value);
                }
                else
                {
                    TargetGameObject.SetActive(!IsActive.Value);
                }
            }
        }
    }
}

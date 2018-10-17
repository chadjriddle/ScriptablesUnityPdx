using UnityEngine;

namespace Demos.WaveGameDemo.Components
{
    public class Billboard : MonoBehaviour
    {
        Camera cameraToUse;

        void Start()
        {
            cameraToUse = Camera.main;
        }

        void Update()
        {
            transform.LookAt(transform.position + cameraToUse.transform.rotation * Vector3.forward, cameraToUse.transform.rotation * Vector3.up);
        }
    }
}

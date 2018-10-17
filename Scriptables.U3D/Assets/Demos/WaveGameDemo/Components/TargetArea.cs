using UnityEngine;

namespace Demos.WaveGameDemo.Components
{
    public class TargetArea : MonoBehaviour {

        public Vector2 areaSize = new Vector2(10, 30);

        public Vector3 GetRandomWorldLocation()
        {
            var x = Random.Range(areaSize.x / 2, -areaSize.x / 2) + transform.position.x;
            var z = Random.Range(areaSize.y / 2, -areaSize.y / 2) + transform.position.z;
            var target = new Vector3(x, transform.position.y, z);

            return target;
        }

        public Vector3 GetWithinBounds(Vector3 original)
        {
            var bounds = new Bounds(transform.position, new Vector3(areaSize.x, 0.1f, areaSize.y));
            return bounds.ClosestPoint(original);
        }


        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(transform.position, new Vector3(areaSize.x, 0.2f, areaSize.y));
        }
    }
}

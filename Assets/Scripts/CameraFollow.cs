using UnityEngine;


namespace ColorSwitch.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        
        private void Update()
        {
            if (target.position.y > transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
            }
        }
    }
}

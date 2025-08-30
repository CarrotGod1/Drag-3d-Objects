using UnityEngine;

namespace Scripts.Drag
{
    [RequireComponent(typeof(Rigidbody))]
    public class DragObject : MonoBehaviour, IDraggable
    {
        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void OnDrag(Transform target)
        {
            rb.MovePosition(target.position);
            //rb.MoveRotation(target.rotation);
        }
    }
}

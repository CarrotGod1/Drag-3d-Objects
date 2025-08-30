using UnityEngine;

namespace Scripts.Drag
{
    [RequireComponent(typeof(Rigidbody))]
    public class DragObject : MonoBehaviour, IDragHandler
    {
        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void OnDrag(Transform target)
        {
            rb.MovePosition(target.position);
            rb.MoveRotation(target.rotation);
        }
    }
}
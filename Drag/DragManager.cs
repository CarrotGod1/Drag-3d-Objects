using UnityEngine;

namespace Scripts.Drag
{
    public class DragManager : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private KeyCode dragKey = KeyCode.Mouse0;
        [SerializeField] private float reachDistance = 10f;
        [SerializeField] private Transform dragPosition;

        private IDraggable dragHandler;
        private bool isDragging = false;

        private void Awake()
        {
            if (mainCamera == null)
            {
                mainCamera = Camera.main;
                Debug.LogWarning($"WARN: Camera was missing, new camera is {mainCamera?.name}");
            }
        }

        private void Update()
        {
            if (Input.GetKey(dragKey) && mainCamera != null && dragPosition != null)
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, reachDistance))
                {
                    if (hit.collider.TryGetComponent(out IDraggable _dragHandler) && !isDragging)
                    {
                        dragHandler = _dragHandler;
                        isDragging = true;
                        dragHandler.OnBeginDrag();
                    }
                }
            }

            if (Input.GetKeyUp(dragKey) && dragHandler != null)
            {
                dragHandler.OnEndDrag();
                dragHandler = null;
                isDragging = false;
            }
        }

        private void FixedUpdate()
        {
            if (dragHandler != null && Input.GetKey(dragKey) && dragPosition != null)
            {
                dragHandler.OnDrag(dragPosition);
            }
        }
    }
}

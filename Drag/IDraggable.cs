using UnityEngine;

namespace Scripts.Drag
{
    public interface IDraggable
    {
        void OnDrag(Transform target);

    void OnBeginDrag() { }
    void OnEndDrag() { }
    }
}

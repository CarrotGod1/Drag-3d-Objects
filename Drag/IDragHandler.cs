using UnityEngine;

namespace Scripts.Drag
{
    public interface IDragHandler
    {
        void OnDrag(Transform target);

    void OnBeginDrag() { }
    void OnEndDrag() { }
    }
}
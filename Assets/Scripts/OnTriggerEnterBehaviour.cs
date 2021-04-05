using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnterBehaviour : MonoBehaviour
{
    [SerializeField] private LayerMask layer;
    [SerializeField] private UnityEvent OnTriggerEnterEvent = default;

    private void OnTriggerEnter(Collider other)
    {   
        if(layer.InsideLayerMask(other.gameObject))
        {
            OnTriggerEnterEvent.Invoke();
        }
    }
}

public static class LayerMaskExtensions
{
    public static bool InsideLayerMask(this LayerMask layer, GameObject obj)
    {
        return (layer.value & (2 << (obj.layer - 1))) != 0;
    }
}

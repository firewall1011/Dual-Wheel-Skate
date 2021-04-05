using UnityEngine;

public class PlayerLift : MonoBehaviour
{
    public void Lift()
    {
        var rotation = transform.rotation;
        rotation.eulerAngles = new Vector3(rotation.eulerAngles.x, rotation.eulerAngles.y, 0f);
        transform.rotation = rotation;
    }
}
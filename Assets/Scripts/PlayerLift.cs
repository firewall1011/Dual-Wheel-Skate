using UnityEngine;

public class PlayerLift : MonoBehaviour
{
    [SerializeField] private KeyCode liftKey = KeyCode.LeftShift;

    private PlayerStats playerStats = default;

    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(liftKey) && !playerStats.IsPlayerInAir)
        {
            Lift();
        }
    }

    public void Lift()
    {
        var rotation = transform.rotation;
        rotation.eulerAngles = new Vector3(rotation.eulerAngles.x, rotation.eulerAngles.y, 0f);
        transform.rotation = rotation;
    }
}
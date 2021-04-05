using UnityEngine;

public class PlayerStats : MonoBehaviour
{
   public Rigidbody playerRigidbody = default;
        
    [Header("Ground Detection")]
    [SerializeField] private Vector3 offset = Vector3.zero;
    [SerializeField] private Vector3 halfExtents = Vector3.zero;
    [SerializeField] private LayerMask mask;

    [Header("Configurations")]
    [SerializeField] private float minVelocity = 5f;
    [SerializeField] private float maxVelocity = 15f;

    public bool IsPlayerAtMinVel => playerRigidbody.velocity.magnitude >= minVelocity;
    public bool IsPlayerAtMaxVel => playerRigidbody.velocity.magnitude >= maxVelocity;

    public bool IsPlayerInAir => !GroundCheck();


    private Vector3 center => transform.position + offset;
        
    private bool GroundCheck()
    {
        return Physics.CheckBox(center, halfExtents, transform.rotation, mask);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = GroundCheck() ? Color.green : Color.red;
        Gizmos.DrawCube(center, halfExtents * 2f);
    }
}

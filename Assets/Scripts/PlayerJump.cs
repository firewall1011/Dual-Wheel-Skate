using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO PlayerJumpChannel;
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    [SerializeField] private float jumpMagnitude = 30f;

    private PlayerStats playerStats;
    private bool canJump = true;

    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            Jump();
        }
    }

    public void Jump()
    {
        if (canJump && playerStats.IsPlayerAtMinVel && !playerStats.IsPlayerInAir)
        {
            StartCoroutine(CanJumpCooldown());
            PlayerJumpChannel?.RaiseEvent();
        }
    }

    public void JumpAction()
    {
        playerStats.playerRigidbody.AddRelativeForce(Vector3.up * jumpMagnitude);
    }

    private IEnumerator CanJumpCooldown()
    {
        canJump = false;
        yield return new WaitForSeconds(1f);
        canJump = true;
    }
}

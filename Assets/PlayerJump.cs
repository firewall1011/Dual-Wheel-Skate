using System;
using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
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

    private void Jump()
    {
        Debug.Log("Try Jumping");
        if (canJump && playerStats.IsPlayerAtMinVel && !playerStats.IsPlayerInAir)
        {
            Debug.Log("Jumping");
            playerStats.playerRigidbody.AddRelativeForce(Vector3.up * jumpMagnitude);
            StartCoroutine(CanJumpCooldown());
        }
    }

    private IEnumerator CanJumpCooldown()
    {
        canJump = false;
        yield return new WaitForSeconds(1f);
        canJump = true;
    }
}

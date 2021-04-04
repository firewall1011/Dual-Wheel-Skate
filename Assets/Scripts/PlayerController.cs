using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody = default;
    [SerializeField] private float angularSpeed = 10f;
    [SerializeField] private float maxSpeed = 30f;

    [SerializeField] private AnimationCurve velocityCurve = default;


    public float EvaluateSpeed => velocityCurve.Evaluate(_timer) * maxSpeed;

    private float lastDirection = 0f;
    private float _timer = 0f;

    private void FixedUpdate()
    {
        float currentDirection = Input.GetAxisRaw("Horizontal");

        if(lastDirection != currentDirection)
        {
            _timer = 0f;
        }
        else
        {
            _timer += Time.deltaTime;
        }

        
        _rigidbody.velocity = transform.forward * EvaluateSpeed;
        _rigidbody.angularVelocity = transform.up * currentDirection * angularSpeed;


        lastDirection = currentDirection;
    }
}

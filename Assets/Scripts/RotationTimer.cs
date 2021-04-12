using UnityEngine;

[System.Serializable]
public class RotationTimer
{
	[SerializeField] private AnimationCurve velocityCurve = default;
	[SerializeField] private FloatVariable timer = default;
    
	private float _lastDirection = 1f;

    public float GetEvaluatedTorque(float maxTorque)
    {
		float evaluatedTorque = velocityCurve.Evaluate(timer.Value);
        return evaluatedTorque * maxTorque;
    }

    public void TimeStep(float horizontalAxis)
	{		
		float normalizedHorizontalAxis = horizontalAxis < 0f ? -1f : 1f;

		if (_lastDirection != normalizedHorizontalAxis && !Mathf.Approximately(horizontalAxis, 0f))
        {
				timer.Value = 0f;
				_lastDirection = normalizedHorizontalAxis;
        }
		else
			timer.Value += Time.deltaTime;

	}
}

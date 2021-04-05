using UnityEngine;

[System.Serializable]
public class RotationTimer
{
	[SerializeField] private AnimationCurve velocityCurve = default;
	[SerializeField] private FloatVariable timer = default;
    
	private float _lastDirection = 1f;

    public float GetEvaluatedTorque(float maxTorque)
    {
        return velocityCurve.Evaluate(timer) * maxTorque;
    }

    public void TimeStep(float horizontalAxis)
	{
		horizontalAxis = horizontalAxis < 0f ? -1f : 1f;

		if (_lastDirection != horizontalAxis)
			timer.Value = 0f;
		else
			timer.Value += Time.deltaTime;

		_lastDirection = horizontalAxis;
	}
}

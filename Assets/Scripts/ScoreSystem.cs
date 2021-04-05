using System;
using UnityEngine;

public partial class ScoreSystem : MonoBehaviour
{
    public event Action<float> OnScoreUpdate = default;

    [SerializeField] private PlayerStats playerStats = default;
    [SerializeField] private FloatEventChannelSO ScoreIncreasedChannel = default;
    [SerializeField] private FloatEventChannelSO ScoreDecreasedChannel = default;


    public float Score
    {
        get => _score;
        set
        {
            _score = Mathf.Clamp(value, 0f, Mathf.Infinity);
            OnScoreUpdate?.Invoke(_score);
        }
    }
    public float Multiplier => _multiplier;

    private float _score = 0f;
    private float _multiplier = 0f;
    private float _time = 0f;

    private float CalculateMultiplier()
    {
        float multiplier = 0f;

        if (playerStats.IsPlayerAtMinVel)
            multiplier += 1f;

        if (playerStats.IsPlayerAtMaxVel)
            multiplier += .2f;

        if (playerStats.IsPlayerInAir)
            multiplier += .5f;

        return multiplier;
    }

    private void Update()
    {
        _multiplier = CalculateMultiplier();

        _time += Time.deltaTime;
        if (_time >= 1f)
        {
            _time = 0f;
            EvaluateScore();
        }
    }

    private void EvaluateScore()
    {
        IncreaseScore(100 * _multiplier);
    }

    public void IncreaseScore(float amount)
    {
        Score += Mathf.Abs(amount);
        ScoreIncreasedChannel?.RaiseEvent(amount);
    }
    public void DecreaseScore(float amount)
    {
        Score -= Mathf.Abs(amount);
        ScoreDecreasedChannel?.RaiseEvent(amount);
    }

}

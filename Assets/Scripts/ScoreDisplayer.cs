using UnityEngine;
using TMPro;

public class ScoreDisplayer : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI scoreDisplayMesh = default;
    [SerializeField] private TextMeshProUGUI multiplierDisplayMesh = default;
    [SerializeField] private ScoreSystem scoreSystem = default;

    [Header("Score Displayed Text")]
    [SerializeField] private string score_context = "Score: ";
    [SerializeField] private string score_format = "F2";
    
    [Header("Multiplier Displayed Text")]
    [SerializeField] private string multiplier_context = "x";
    [SerializeField] private string multiplier_format = "F1";

    private void UpdateScoreText(float score)
    {
        scoreDisplayMesh.SetText(score_context + score.ToString(score_format));
    }

    private void Update()
    {
        multiplierDisplayMesh.SetText(scoreSystem.Multiplier.ToString(multiplier_format) + multiplier_context);
    }

    private void OnEnable() => scoreSystem.OnScoreUpdate += UpdateScoreText;
    private void OnDisable() => scoreSystem.OnScoreUpdate -= UpdateScoreText;
}

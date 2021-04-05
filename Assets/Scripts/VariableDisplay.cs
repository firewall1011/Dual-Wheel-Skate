using UnityEngine;
using TMPro;
using System;

public class VariableDisplay : MonoBehaviour
{
    [SerializeField] private FloatVariable amount;
    [SerializeField] private string context;
    [SerializeField] private string format;

    private TextMeshProUGUI _textMesh;

    private void Awake()
    {
        _textMesh = GetComponent<TextMeshProUGUI>();
        UpdateText();

    }

    private void OnEnable() => amount.OnValueChange += UpdateText;
    private void OnDisable() => amount.OnValueChange -= UpdateText;

    public void UpdateText()
    {
        _textMesh.SetText(context + ((float)amount).ToString(format));
    }
}

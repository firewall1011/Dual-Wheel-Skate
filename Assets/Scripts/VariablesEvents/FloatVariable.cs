
using UnityEngine;
[CreateAssetMenu(fileName = " Float", menuName = "Variables / Primitive / float")]
public class FloatVariable : ScriptableObject
{
    [SerializeField] private float _value = default;
    public event System.Action OnValueChange;

    public float Value { get => _value; set { _value = value; OnValueChange?.Invoke(); } }

    public static implicit operator float(FloatVariable target) => target.Value;
}
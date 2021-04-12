using UnityEngine;

[CreateAssetMenu(menuName = "SkateMaterial/material")]
public class SkateMaterial : ScriptableObject
{
    public Material Board = default;
    public Material Wheels = default;
    public Material Metal = default;
}

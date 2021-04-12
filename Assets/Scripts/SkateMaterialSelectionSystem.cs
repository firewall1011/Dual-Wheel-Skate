using System;
using UnityEngine;

[CreateAssetMenu(menuName = "SkateMaterial/SelectionSystem")]
public class SkateMaterialSelectionSystem : ScriptableObject
{
    #region Public Properties
    public SkateMaterial SelectedMaterial => skateMaterials[index];
    #endregion

    #region Public Fields
    public SkateMaterial[] skateMaterials = new SkateMaterial[0];
    #endregion

    public event Action<SkateMaterial> SkateMaterialChanged;

    private int index = 0;
    
    public void SelectNextMaterial()
    {
        index = (index + 1) % skateMaterials.Length;
        SkateMaterialChanged?.Invoke(SelectedMaterial);
    }

    public void SelectPreviousMaterial()
    {
        index = (index - 1) == -1 ? skateMaterials.Length - 1 : index - 1;
        SkateMaterialChanged?.Invoke(SelectedMaterial);
    }


}

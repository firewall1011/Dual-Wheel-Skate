using UnityEngine;

public class SkateMaterialApplier : MonoBehaviour
{
    [SerializeField] private SkateMaterialSelectionSystem selectionSystem = default;

    private MeshRenderer meshRenderer = default;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnEnable() => selectionSystem.SkateMaterialChanged += ApplyMaterial;
    private void OnDisable() => selectionSystem.SkateMaterialChanged -= ApplyMaterial;

    public void ApplyMaterial()
    {
        if(selectionSystem.SelectedMaterial != null)
            ApplyMaterial(selectionSystem.SelectedMaterial);
    }

    public void ApplyMaterial(SkateMaterial skateMaterial)
    {
        if (meshRenderer == null)
            return;

        Material[] materialsList = new Material[3] { skateMaterial.Wheels, skateMaterial.Board, skateMaterial.Metal };
        meshRenderer.sharedMaterials = materialsList;
    }
}

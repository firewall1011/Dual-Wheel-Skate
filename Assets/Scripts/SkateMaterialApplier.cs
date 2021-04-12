using UnityEngine;

public class SkateMaterialApplier : MonoBehaviour
{
    [SerializeField] private SkateMaterialSelectionSystem selectionSystem = default;

    private Renderer meshRenderer = default;

    private void Awake()
    {
        meshRenderer = GetComponent<Renderer>();
        ApplyMaterial();
    }

    private void OnEnable() => selectionSystem.SkateMaterialChanged += ApplyMaterial;
    private void OnDisable() => selectionSystem.SkateMaterialChanged -= ApplyMaterial;

    [ContextMenu("Apply")]
    public void ApplyMaterial()
    {
        if(selectionSystem.SelectedMaterial != null)
        {
            ApplyMaterial(selectionSystem.SelectedMaterial);
            Debug.Log($"Applying {selectionSystem.SelectedMaterial.name}");
        }
    }

    public void ApplyMaterial(SkateMaterial skateMaterial)
    {
        if (meshRenderer == null)
            return;

        Material[] materialsList = new Material[3] { skateMaterial.Wheels, skateMaterial.Board, skateMaterial.Metal };
        meshRenderer.sharedMaterials = materialsList;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class HoverAndDisappear : MonoBehaviour
{
    public GameObject gloves;
    public Toggle glovesToggle;
    public GameObject objectToChangeMaterial1;
    public GameObject objectToChangeMaterial2;

    [Header("Materials")]
    public Material targetMaterial1;
    public Material targetMaterial2;

    private Material originalMaterial1;
    private Material originalMaterial2;

    private void Start()
    {
        // Subscribe to the OnValueChanged event of the Toggle
        glovesToggle.onValueChanged.AddListener(OnToggleValueChanged);

        // Store the original materials
        originalMaterial1 = GetMaterial(objectToChangeMaterial1);
        originalMaterial2 = GetMaterial(objectToChangeMaterial2);
    }

    private void OnToggleValueChanged(bool isOn)
    {
        // Check if the toggle is on
        if (isOn)
        {
            // Set the gloves GameObject to active
            if (gloves != null)
            {
                gloves.SetActive(true);
            }

            // Change the material of the first object
            SetMaterial(objectToChangeMaterial1, targetMaterial1);

            // Change the material of the second object
            SetMaterial(objectToChangeMaterial2, targetMaterial2);
        }
        else
        {
            // Set the gloves GameObject to inactive
            if (gloves != null)
            {
                gloves.SetActive(false);
            }

            // Reset the material of the first object
            SetMaterial(objectToChangeMaterial1, originalMaterial1);

            // Reset the material of the second object
            SetMaterial(objectToChangeMaterial2, originalMaterial2);
        }
    }

    private Material GetMaterial(GameObject obj)
    {
        if (obj != null)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null && renderer.material != null)
            {
                return renderer.material;
            }
        }
        return null;
    }

    private void SetMaterial(GameObject obj, Material material)
    {
        if (obj != null)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = material;
            }
        }
    }
}

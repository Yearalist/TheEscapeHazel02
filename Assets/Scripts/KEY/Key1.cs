using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key1 : MonoBehaviour, IInteractable, ICollectable
{
    private PickUpObject pickUpObjectScript;
    private InspectObject inspectObjectScript;
    private Material originalMaterial;
    public Material hoverMaterial;

    void Start()
    {
        pickUpObjectScript = FindObjectOfType<PickUpObject>();
        inspectObjectScript = FindObjectOfType<InspectObject>();
        originalMaterial = GetComponent<Renderer>().material;
    }

    private void OnMouseEnter()
    {
        if (!pickUpObjectScript.isHolding && !inspectObjectScript.isInspecting)
        {
            GetComponent<Renderer>().material = hoverMaterial;
        }
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material = originalMaterial;  
    }

    public void Interactable()
    {
        // Etkileşim sırasında yapılacak işlemler buraya gelebilir
    }

    public void InteractableObjects()
    {
        // Anahtarın etkileşimi burada işleniyor
        Interactable();
    }

    public void Collectable()
    {
        // Toplanabilir özellik burada işlenebilir
    }

    public void CollectableObjects()
    {
        // Anahtarın toplanabilirliği burada işleniyor
        Collectable();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table1 : MonoBehaviour, IInteractable, ICollectable
{
    private PickUpObject pickUpObjectScript;
    private InspectObject inspectObjectScript;

    private GameObject openTable;
    private GameObject normalTable;

    private Material originalMaterial;
    public Material hoverMaterial;

    private bool isCollect;

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
        else
        {
            GetComponent<Renderer>().material = originalMaterial;
        }
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material = originalMaterial;
    }

   

    // Interfaces
    public void Interactable()
    {
        // Interactable işlevselliği eklenebilir.
    }

    public void InteractableObjects()
    {
        Interactable();
    }

    public void Collectable()
    {
        // Collectable işlevselliği eklenebilir.
    }

    public void CollectableObjects()
    {
        Collectable();
    }
}

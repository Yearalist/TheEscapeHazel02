using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Book1 : MonoBehaviour, IInteractable, ICollectable
{
    private PickUpObject pickUpObjectScript;
    private InspectObject inspectObjectScript;

    private GameObject openBook;
    private GameObject normalBook;

    private Material originalMaterial;
    public Material hoverMaterial;

    private bool isCollect;

    void Start()
    {
        pickUpObjectScript = FindObjectOfType<PickUpObject>();
        inspectObjectScript = FindObjectOfType<InspectObject>();
        openBook = GameObject.FindWithTag("book_open");
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

    void Update()
    {
        // Update işlevselliği eklenebilir.
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


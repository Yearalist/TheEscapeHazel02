using System.Collections;
using System.Collections.Generic;
using SecretCloset;
using UnityEngine.UI;
using UnityEngine;




    

    

public class PickUpObject : MonoBehaviour
{
    private InspectObject inspectObjectScript;
    private Inventory inventoryScript;
    public Transform handPosition; // Elin olması gereken pozisyon
    private Rigidbody holdingObjectRigidbody; // Eldeki objenin Rigidbodysi
    public GameObject holdingObject; // Eldeki obje
    private Sprite spriteY;
    private string spriteYName = "SpriteY";
    public bool isHolding = false; // Elimde obje var mı
    public ShelfManager shelfManager; // ShelfManager referansı
    //BookCheck CheckBooks = FindObjectOfType<BookCheck>();
    [SerializeField] private BookPlacment bookPlacement;
    

    void Start()
    {
        inspectObjectScript = FindObjectOfType<InspectObject>();
        inventoryScript = FindObjectOfType<Inventory>();
        string scriptName = this.GetType().Name;
        Debug.Log("Hello There is " + scriptName);
        Debug.Log("Holding Control " + isHolding);
        spriteY = Resources.Load<Sprite>(spriteYName);
    }

    void Update()
    {
        if (!isHolding && !inspectObjectScript.isInspecting)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.TryGetComponent(out IInteractable interactObject))
                    {
                        interactObject.InteractableObjects();
                        holdingObject = hit.collider.gameObject;
                        PickUpItem();
                    }
                }
            }
        }
        else if (isHolding && !inspectObjectScript.isInspecting)
        {
            if (Input.GetMouseButtonDown(0))
            {
                DropItem();
            }
        }
    }

    private void FixedUpdate()
    {
        if (isHolding && !inspectObjectScript.isInspecting)
        {
            var holdingObjectCollider = holdingObject.GetComponent<Collider>();
            if (holdingObjectCollider.enabled == false)
            {
                holdingObjectCollider.enabled = true;
            }
            holdingObject.transform.position = handPosition.transform.position;
            var rigidBody = holdingObject.GetComponent<Rigidbody>();
            var moveTo = handPosition.transform.position;
            var differance = moveTo - holdingObject.transform.position;
            rigidBody.AddForce(differance * 500);
            holdingObject.transform.rotation = handPosition.rotation;
        }
    }

    void PickUpItem()
    {
        Debug.Log("Aldin");
        Debug.Log(holdingObject.name);
        isHolding = true;
        holdingObject.transform.position = Vector3.Lerp(holdingObject.transform.position, handPosition.transform.position, 0.4f);
        holdingObjectRigidbody = holdingObject.GetComponent<Rigidbody>();
        holdingObjectRigidbody.constraints = RigidbodyConstraints.FreezeRotation; // Rotasyonunu dondur
        holdingObjectRigidbody.drag = 25f;
        holdingObjectRigidbody.useGravity = false;
    }

    void DropItem()
    {
        BookInfo bookInfo = holdingObject.GetComponent<BookInfo>();
        if (bookPlacement.TryPlaceBook(bookInfo))
        {
            holdingObjectRigidbody.constraints = RigidbodyConstraints.None; // Rotasyon sınırlamalarını kaldır
            holdingObjectRigidbody.drag = 1f;
            holdingObjectRigidbody.useGravity = true;
            isHolding = false;
            holdingObject = null;
        }
        else
        {
            // Eğer slot bulunamazsa veya doluysa kitabı normal bir şekilde bırak
            var rigidBody = holdingObject.GetComponent<Rigidbody>();
            rigidBody.drag = 1f;
            rigidBody.useGravity = true;
            rigidBody.constraints = RigidbodyConstraints.None;
            holdingObject.transform.SetParent(null);
            holdingObject = null;
            isHolding = false;
            Debug.Log("Kitap bırakıldı.");
        }
        // RaycastHit hit;
        // if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        // {
        //     
        //     //BookInfo bookInfo = holdingObject.GetComponent<BookInfo>();
        //     if (slot != null && !slot.isOccupied && slot.slotCode == bookInfo.slotCode)
        //     {
        //         slot.isOccupied = true;
        //         //CheckBooks.CheckBooks();
        //         holdingObject.transform.SetParent(slot.slotTransform);
        //         holdingObject.transform.localPosition = Vector3.zero;  // Kitabın slot içinde düzgün yerleşmesini sağlamak için
        //         holdingObject.transform.localRotation = Quaternion.identity;
        //
        //         // Kitabın pozisyonunu ve rotasyonunu slotun pozisyonu ve rotasyonuna ayarla
        //         holdingObject.transform.position = slot.slotTransform.position;
        //         holdingObject.transform.rotation = slot.slotTransform.rotation;
        //
        //         holdingObjectRigidbody.constraints = RigidbodyConstraints.None; // Rotasyon sınırlamalarını kaldır
        //         holdingObjectRigidbody.drag = 1f;
        //         holdingObjectRigidbody.useGravity = true;
        //         isHolding = false;
        //         holdingObject = null;
        //         Debug.Log($"Kitap kodu {slot.slotCode} olan slota yerleştirildi.");
        //         
        //         // Slotları kontrol et ve rafı hareket ettir
        //         if (shelfManager != null)
        //         {
        //             shelfManager.CheckAndMoveShelf();
        //         }
        //         else
        //         {
        //             Debug.LogError("ShelfManager is not assigned!");
        //         }
        //         return;
        //     }
        // }
        //
        // // Eğer slot bulunamazsa veya doluysa kitabı normal bir şekilde bırak
        // var rigidBody = holdingObject.GetComponent<Rigidbody>();
        // rigidBody.drag = 1f;
        // rigidBody.useGravity = true;
        // rigidBody.constraints = RigidbodyConstraints.None;
        // holdingObject.transform.SetParent(null);
        // holdingObject = null;
        // isHolding = false;
        // Debug.Log("Kitap bırakıldı.");
    } 
    }


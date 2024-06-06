using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   private CollectObject collectObjectScript;
    private InspectObject inspectObjectScript;
    private PickUpObject pickUpObjectScript;
    
    public List<GameObject> envanterSlotsList = new List<GameObject>(); // Envanter slotlarını tutan liste

    private string collectingItemSpriteName;

    private MeshRenderer meshRenderer;
    
    public Color activeColor = Color.yellow; // Aktif slotun rengi
    public Color inactiveColor = Color.white; // Pasif slotların rengi

    private int currentSlotIndex = -1; // Başlangıçta aktif slot yok
    public int inventorySlotsNumber;
    public int i = 0;
    
    private Transform envanterSlot;

    void Start()
    {
        collectObjectScript= FindObjectOfType<CollectObject>();
        inspectObjectScript = FindObjectOfType<InspectObject>();
        pickUpObjectScript = FindObjectOfType<PickUpObject>();
        
        inventorySlotsNumber = 3;
        Debug.Log(inventorySlotsNumber);
        
        GameObject parentInvantoryObject=GameObject.FindWithTag("Inventory");
        foreach (Transform child in parentInvantoryObject.transform)
        {
            envanterSlotsList.Add(child.gameObject);
        }
        
        foreach (GameObject slot in envanterSlotsList)
        {
            //Debug.Log("Child Name: " + slot.name);
            slot.GetComponent<Image>().color = inactiveColor;
        }
    }

    
    void Update()
    {
        if (!inspectObjectScript.isInspecting)
        {
            NavigatingBetweenInventorySlots();
        }
       
    }
    
    public void ShowSpriteCollectedItemOnInventory()
    {
        Debug.Log(envanterSlotsList[i].name);
        Debug.Log(collectObjectScript.collectingItem.name);
       
       collectingItemSpriteName = collectObjectScript.collectingItem.name;
       Sprite loadedSprite = Resources.Load<Sprite>(collectingItemSpriteName);
       Image collectedItemImage = envanterSlotsList[i].GetComponent<Image>();
       collectedItemImage.sprite = loadedSprite;
       meshRenderer = collectObjectScript.collectingItem.GetComponent<MeshRenderer>();
       collectObjectScript.collectingItem.GetComponent<Collider>().enabled = false;
       meshRenderer.enabled = false;
       
       collectObjectScript.collectingItem = null;
       inventorySlotsNumber--;
       i++;
       Debug.Log("Aldin" + i);
    }
    private void NavigatingBetweenInventorySlots()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0)
        {
            
            if (currentSlotIndex == -1)
            {
                currentSlotIndex = 0;
                envanterSlotsList[currentSlotIndex].GetComponent<Image>().color = activeColor;
                return;
            }

            
            envanterSlotsList[currentSlotIndex].GetComponent<Image>().color = inactiveColor;

            if (scroll > 0)
            {
                currentSlotIndex++;
                if (currentSlotIndex >= envanterSlotsList.Count)
                {
                    currentSlotIndex = 0; // Başa dön
                }
                Debug.Log(envanterSlotsList[currentSlotIndex]);
                ShowSpriteOnInventorySlot();
            }
            else if (scroll < 0)
            {
                currentSlotIndex--;
                if (currentSlotIndex < 0)
                {
                    currentSlotIndex = envanterSlotsList.Count - 1; // Sona dön
                }
                ShowSpriteOnInventorySlot();
            }

           
            envanterSlotsList[currentSlotIndex].GetComponent<Image>().color = activeColor;
            
          
            
        }
    }

    private void ShowSpriteOnInventorySlot()
    {
        Image onSlotItemImage = envanterSlotsList[currentSlotIndex].GetComponent<Image>();
        string onSlotItemName = onSlotItemImage.sprite.name;
        Debug.Log(onSlotItemName);

        if (onSlotItemName!="Background"||onSlotItemName!="SpriteY")
        {
            GameObject onSlotGameObject = GameObject.Find(onSlotItemName);
           
            if (onSlotGameObject != null)
            {
                if (pickUpObjectScript.isHolding)
                {
                    string holdingObjectName = pickUpObjectScript.holdingObject.name;
                    Sprite holdingObectSprite = Resources.Load<Sprite>(holdingObjectName);
                    onSlotItemImage.sprite = holdingObectSprite;
                    meshRenderer = pickUpObjectScript.holdingObject.GetComponent<MeshRenderer>();
                    meshRenderer.enabled = false;
                    
                    pickUpObjectScript.holdingObject = onSlotGameObject;
                    meshRenderer = pickUpObjectScript.holdingObject.GetComponent<MeshRenderer>();
                    meshRenderer.enabled = true;
                    

                }
                else if (!pickUpObjectScript.isHolding)
                {
                    meshRenderer=onSlotGameObject.GetComponent<MeshRenderer>();
                    meshRenderer.enabled = true;
                    onSlotGameObject.transform.position = pickUpObjectScript.handPosition.transform.position;
                    pickUpObjectScript.holdingObject = onSlotGameObject;
                    pickUpObjectScript.isHolding = true;
                    

                }
            }
            else
            {
                Debug.Log("null");
            }
        }
        
        
    }
}

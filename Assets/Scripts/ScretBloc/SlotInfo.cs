using UnityEngine;

using UnityEngine;

public class SlotInfo : MonoBehaviour
{ public string slotCode;  // Slotun kodu
    public Transform slotTransform;  // Slotun transformu
    public bool isOccupied;
    
    private void Awake()
    {
        slotTransform = transform;  // Slotun transformunu ayarla
        Debug.Log($"Slot oluşturuldu: {slotCode}");
    }

    private void OnMouseEnter()
    {
        Debug.Log($"Slot {slotCode} üzerine gelindi.");
    }

    private void OnMouseExit()
    {
        Debug.Log($"Slot {slotCode} üzerinden çıkıldı.");
    }
}


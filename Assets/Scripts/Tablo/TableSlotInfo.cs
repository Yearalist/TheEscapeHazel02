using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSlotInfo : MonoBehaviour
{
    
    public string tableSlotCode;  // Slotun kodu
    public Transform tableSlotTransform;  // Slotun transformu
    public bool isOccupied;

    private void Awake()
    {
        tableSlotTransform = transform;  // Slotun transformunu ayarla
        Debug.Log($"Slot oluşturuldu: {tableSlotCode}");
    }

    private void OnMouseEnter()
    {
        Debug.Log($"Slot {tableSlotCode} üzerine gelindi.");
    }

    private void OnMouseExit()
    {
        Debug.Log($"Slot {tableSlotCode} üzerinden çıkıldı.");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablePlacement : MonoBehaviour
{ public List<TableSlotInfo> shelves; // Rafların listesi
   // public TableSlotManager shelfManager;
        
    // Kitabı doğru slota yerleştirme işlemini gerçekleştirir
    public bool TryPlaceTable(TableInfo table)
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            TableSlotInfo slot = hit.collider.GetComponent<TableSlotInfo>();
            if (slot != null && !slot.isOccupied && slot.tableSlotCode == table.slotCode)
            {
                slot.isOccupied = true;
                //CheckBooks.CheckBooks();
                table.transform.SetParent(slot.tableSlotTransform);
                table.transform.localPosition = Vector3.zero;  // Kitabın slot içinde düzgün yerleşmesini sağlamak için
                table.transform.localRotation = Quaternion.identity;

                // Kitabın pozisyonunu ve rotasyonunu slotun pozisyonu ve rotasyonuna ayarla
                table.transform.position = slot.tableSlotTransform.position;
                table.transform.rotation = slot.tableSlotTransform.rotation;
                
                Debug.Log($"table  kodu {slot.tableSlotCode} olan slota yerleştirildi.");
                    
                // Slotları kontrol et ve rafı hareket ettir
               // if (TableSlotManager != null)
                {
                   // shelfManager.CheckAndMoveShelf();
                }
              //  else
                {
                    //Debug.LogError("ShelfManager is not assigned!");
                }
            }

            return true;
        }

        return false;
    }
}


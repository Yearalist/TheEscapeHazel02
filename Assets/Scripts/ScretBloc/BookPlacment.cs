 
using System.Collections.Generic;
using UnityEngine;

namespace SecretCloset
{
    public class BookPlacment : MonoBehaviour
    {
        public List<ShelfInfo> shelves; // Rafların listesi
        public ShelfManager shelfManager;
        
        // Kitabı doğru slota yerleştirme işlemini gerçekleştirir
        public bool TryPlaceBook(BookInfo book)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                SlotInfo slot = hit.collider.GetComponent<SlotInfo>();
                if (slot != null && !slot.isOccupied && slot.slotCode == book.slotCode)
                {
                    slot.isOccupied = true;
                    //CheckBooks.CheckBooks();
                    book.transform.SetParent(slot.slotTransform);
                    book.transform.localPosition = Vector3.zero;  // Kitabın slot içinde düzgün yerleşmesini sağlamak için
                    book.transform.localRotation = Quaternion.identity;

                    // Kitabın pozisyonunu ve rotasyonunu slotun pozisyonu ve rotasyonuna ayarla
                    book.transform.position = slot.slotTransform.position;
                    book.transform.rotation = slot.slotTransform.rotation;
                
                    Debug.Log($"Kitap kodu {slot.slotCode} olan slota yerleştirildi.");
                    
                    // Slotları kontrol et ve rafı hareket ettir
                    if (shelfManager != null)
                    {
                        shelfManager.CheckAndMoveShelf();
                    }
                    else
                    {
                        Debug.LogError("ShelfManager is not assigned!");
                    }
                    return true;
                }

            }

            return false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using SecretCloset;
using UnityEngine;

public class ShelfManager : MonoBehaviour
{ public List<ShelfInfo> shelves; // Yönetilecek rafların listesi
    public float moveDistance = 1.0f; // Rafın hareket edeceği mesafe

    // Raflardaki slotların doluluk durumunu kontrol et ve gerekirse rafı hareket ettir
    public void CheckAndMoveShelf()
    {
        foreach (ShelfInfo shelf in shelves)
        {
            bool allSlotsFilled = true;

            foreach (SlotInfo slot in shelf.slots)
            {
                if (slot.slotTransform.childCount == 0)
                {
                    allSlotsFilled = false;
                    break;
                }
            }

            if (allSlotsFilled)
            {
                MoveShelf(shelf);
                // Hareket ettikten sonra slotların doluluğunu kontrol etmeye devam etmemize gerek yok
                // Bu yüzden break ile döngüden çıkıyoruz
                break;
            }
        }
    }

    // Rafı hareket ettir
    private void MoveShelf(ShelfInfo shelf)
    {
        Vector3 newPosition = shelf.transform.position;
        newPosition.x += moveDistance;
        shelf.transform.position = newPosition;
        Debug.Log($"Shelf {shelf.shelfCode} moved to {newPosition}");
    }
}





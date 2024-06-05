using System.Collections;
using System.Collections.Generic;
using SecretCloset;
using Unity.VisualScripting;
using UnityEngine;

public class ShelfManager : MonoBehaviour
{ 
    
    public List<ShelfInfo> shelves; // Yönetilecek rafların listesi
    public float moveDistance = 1.0f; // Rafın hareket edeceği mesafe

    // Raflardaki slotların doluluk durumunu kontrol et ve gerekirse rafı hareket ettir
    public void CheckAndMoveShelf()
    {
        foreach (ShelfInfo shelf in shelves)
        {
            bool allSlotsFilled = true;
            Debug.Log($"Checking shelf: {shelf.shelfCode}");

            for (int i = 0; i < shelf.slots.Count; i++)
            {
                if (!shelf.slots[i].isOccupied)
                {
                    allSlotsFilled = false;
                }
            }
            // foreach (SlotInfo slot in shelf.slots)
            // {
            //     if (slot.slotTransform.childCount == 0)
            //     {
            //         allSlotsFilled = false;
            //         Debug.Log($"Slot {slot.slotCode} in shelf {shelf.shelfCode} is empty.");
            //         break;
            //     }
            //     else
            //     {
            //         Debug.Log($"Slot {slot.slotCode} in shelf {shelf.shelfCode} is filled.");
            //     }
            // }

            if (allSlotsFilled)
            {
                StartCoroutine(MoveShelfSmoothly(shelf));
                // Hareket ettikten sonra slotların doluluğunu kontrol etmeye devam etmemize gerek yok
                // Bu yüzden break ile döngüden çıkıyoruz
                break;
            }
        }
    }

    private IEnumerator MoveShelfSmoothly(ShelfInfo shelf)
    {
        Vector3 startPosition = shelf.transform.position;
        Vector3 endPosition = startPosition;
        endPosition.z += moveDistance;
        float duration = 2.0f; // Hareketin süresi (saniye)
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            shelf.transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        shelf.transform.position = endPosition;
        Debug.Log($"Shelf {shelf.shelfCode} moved to {endPosition}");
    }
}





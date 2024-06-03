using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using SecretCloset;  // Book sınıfının bulunduğu namespace'i ekliyoruz

namespace SecretCloset
{
    
public class BookPlacment : MonoBehaviour
{
    
    public ShelfInfo shelf;  // Tek bir rafı tutar

    // Kitabı doğru slota yerleştirme işlemini gerçekleştirir
    public void PlaceBook(BookInfo book)
    {
        // Kitabın yerleştirileceği hedef slotu bul
        SlotInfo targetSlot = shelf.slots.FirstOrDefault(slot => slot.slotCode == book.slotCode);

        // Eğer hedef slot bulunamadıysa veya slot doluysa uyarı ver
        if (targetSlot != null && targetSlot.slotTransform.childCount == 0)
        {
            // Kitabı hedef slota yerleştir ve pozisyonunu ayarla
            book.transform.SetParent(targetSlot.slotTransform);
            book.transform.localPosition = Vector3.zero; // Kitabın slot içinde düzgün yerleşmesini sağlamak için
            Debug.Log($"Book with code {book.slotCode} placed in slot {targetSlot.slotCode}");
        }
        else
        {
            Debug.LogWarning("No suitable slot found or slot is not empty!");
        }
    }
}
}
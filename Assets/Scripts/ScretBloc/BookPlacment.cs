 
using System.Collections.Generic;
using UnityEngine;

namespace SecretCloset
{
    public class BookPlacment : MonoBehaviour
    {
        public List<ShelfInfo> shelves; // Rafların listesi

        // Kitabı doğru slota yerleştirme işlemini gerçekleştirir
        public void PlaceBook(BookInfo book)
        {
            bool bookPlaced = false;

            foreach (ShelfInfo shelf in shelves)
            {
                foreach (SlotInfo slot in shelf.slots)
                {
                    if (slot.slotTransform.childCount == 0 && slot.slotCode == book.slotCode)
                    {
                        // Slotun konum ve rotasyon bilgilerini al
                        Vector3 slotPosition = slot.slotTransform.position;
                        Quaternion slotRotation = slot.slotTransform.rotation;

                        // Kitabı hedef slota yerleştir ve pozisyonunu ve rotasyonunu ayarla
                        book.transform.SetParent(slot.slotTransform);
                        book.transform.localPosition = Vector3.zero;
                        book.transform.localRotation = Quaternion.Euler(Vector3.zero);

                        // Slotun dünya konum ve rotasyonunu al
                        Vector3 worldSlotPosition = slot.slotTransform.TransformPoint(slotPosition);
                        Quaternion worldSlotRotation = slot.slotTransform.rotation * slotRotation;

                        // Kitabın dünya konum ve rotasyonunu ayarla
                        //book.transform.position = worldSlotPosition;
                        //book.transform.rotation = worldSlotRotation;

                        Debug.Log($"Book with code {book.slotCode} placed in slot {slot.slotCode}");
                        bookPlaced = true;
                        break;
                    }
                }

                if (bookPlaced) break;
            }

            if (!bookPlaced)
            {
                Debug.LogWarning("No suitable slot found for book with code " + book.slotCode);
            }
        }
    }
}

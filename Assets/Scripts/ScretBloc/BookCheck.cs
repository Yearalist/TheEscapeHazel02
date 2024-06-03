using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using SecretCloset;  // Book sınıfının bulunduğu namespace'i ekliyoruz

namespace SecretCloset
{

    public class BookCheck : MonoBehaviour
    {
        public List<BookInfo> books; // Kitapların listesi
        public List<ShelfInfo> shelves; // Rafların listesi

        public void CheckBooks()
        {
            foreach (BookInfo book in books)
            {
                bool correctPlace = false; // Kitabın doğru yerde olup olmadığını kontrol etmek için bir bayrak

                // Tüm rafları döngüye alarak
                foreach (ShelfInfo shelf in shelves)
                {
                    // Kitabın raf kodu ile eşleşen bir raf varsa
                    if (shelf.shelfCode == book.slotCode)
                    {
                        // Rafın slotlarını kontrol et
                        foreach (SlotInfo slot in shelf.slots)
                        {
                            // Eğer slot doluysa ve içindeki obje, aranan kitaba aitse
                            if (slot.slotTransform.childCount > 0 &&
                                slot.slotTransform.GetChild(0).gameObject == book.gameObject)
                            {
                                correctPlace = true; // Kitap doğru yerde
                                break; // İçteki döngüden çık
                            }
                        }
                    }

                    if (correctPlace) break; // Eğer kitap doğru yerde bulunduysa, dıştaki döngüden de çık
                }

                // Kitabın doğru yerde olup olmadığını logla
                Debug.Log($"Barkodlu kitap {book.slotCode} doğru yerde: {correctPlace}");
            }
        }
    }
}

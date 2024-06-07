using System.Collections;
using System.Collections.Generic;
using SecretCloset;
using UnityEngine;

public class TableCheck : MonoBehaviour
{
    public List<TableSlotInfo> slots; // Kitapların listesi
    public List<TableShelfInfo> tables; // Tabloların listesi

    public void CheckBooks()
    {
        foreach (TableSlotInfo slot in slots)
        {
            bool correctPlace = false; // Kitabın doğru yerde olup olmadığını kontrol etmek için bir bayrak

            // Tüm tabloları döngüye alarak
            foreach (TableShelfInfo table in tables)
            {
                // Kitabın tablo kodu ile eşleşen bir tablo varsa
                if (table.tableCode == slot.tableSlotCode)
                {
                    // Tablo'nun slotlarını kontrol et
                    foreach (TableSlotInfo tableSlot in table.slots)
                    {
                        // Eğer slot doluysa ve içindeki obje, aranan kitaba aitse
                        if (tableSlot.tableSlotTransform.childCount > 0 &&
                            tableSlot.tableSlotTransform.GetChild(0).gameObject == slot.gameObject)
                        {
                            correctPlace = true; // Kitap doğru yerde
                            break; // İçteki döngüden çık
                        }
                    }
                }

                if (correctPlace) break; // Eğer kitap doğru yerde bulunduysa, dıştaki döngüden de çık
            }

            // Kitabın doğru yerde olup olmadığını logla
            Debug.Log($"Barkodlu kitap {slot.tableSlotCode} doğru yerde: {correctPlace}");
        }
    }
}

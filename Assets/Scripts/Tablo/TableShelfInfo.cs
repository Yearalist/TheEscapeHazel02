using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SecretCloset; // Book sınıfının bulunduğu namespace'i ekliyoruz

namespace SecretCloset
{
    public class TableShelfInfo : MonoBehaviour
    {
        public string tableCode; // Tablo kodu
        public List<TableSlotInfo> slots; // Tablo üzerindeki slotların listesi
    }
}
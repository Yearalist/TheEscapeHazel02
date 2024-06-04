using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SecretCloset;  // Book sınıfının bulunduğu namespace'i ekliyoruz

namespace SecretCloset
{

public class ShelfInfo : MonoBehaviour
{

    public string shelfCode; // Rafın kodu
    public List<SlotInfo> slots; // Raf üzerindeki slotların listesi
}
}
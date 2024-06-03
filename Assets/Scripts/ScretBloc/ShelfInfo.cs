using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SecretCloset;  // Book sınıfının bulunduğu namespace'i ekliyoruz

namespace SecretCloset
{

public class ShelfInfo : MonoBehaviour
{

    
    public string shelfCode; // örneğin, "6.1"
    public List<SlotInfo> slots;
}
}
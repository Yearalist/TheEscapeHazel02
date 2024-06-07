using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableInfo : MonoBehaviour
{ 
    public string barcode;
    public string slotCode; // Kitabın yerleştirileceği slotun kodu
    public Vector3 slotPosition; // Slotun position'ı
    public Quaternion slotRotation; // Slotun rotation'ı
}

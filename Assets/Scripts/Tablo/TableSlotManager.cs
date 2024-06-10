using System.Collections;
using System.Collections.Generic;
using SecretCloset;
using Unity.VisualScripting;
using UnityEngine;
public class TableSlotManager : MonoBehaviour
{
    public List<TableShelfInfo> tables; // Yönetilecek tabloların listesi
    [SerializeField] private Transform drawer;
    public float moveDistance = 1.0f; // Tablo hareket mesafesi
    [SerializeField] private AudioSource drawerOpeningSound;

    
    // Tablolardaki slotların doluluk durumunu kontrol et ve gerekirse tabloyu hareket ettir
    public void CheckAndMoveTable()
    {
        bool allSlotsFilled = true;
        foreach (TableShelfInfo table in tables)
        {
            foreach (TableSlotInfo slot in table.slots)
            {
                if (!slot.isOccupied)
                {
                    allSlotsFilled = false;
                    break;
                }
            }

            if (!allSlotsFilled)
            {
                break;
            }
        }

        if (tables.Count == 0)
        {
            Debug.LogError("tablolar scriptte listelenmemis");
        }
        else if (allSlotsFilled)
        {
            drawerOpeningSound.Play();
            StartCoroutine(MoveTableSmoothly());
        }
    }

    private IEnumerator MoveTableSmoothly()
    {
        Vector3 startPosition = drawer.localPosition;
        Vector3 endPosition = startPosition;
        endPosition.z += moveDistance;
        float duration = 2.0f; // Hareket süresi (saniye)
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            drawer.localPosition = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        drawer.localPosition = endPosition;
    }
}

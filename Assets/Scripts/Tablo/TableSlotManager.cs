using System.Collections;
using System.Collections.Generic;
using SecretCloset;
using Unity.VisualScripting;
using UnityEngine;
public class TableSlotManager : MonoBehaviour
{
    public List<TableShelfInfo> tables; // Yönetilecek tabloların listesi
    public float moveDistance = 1.0f; // Tablo hareket mesafesi

    // Tablolardaki slotların doluluk durumunu kontrol et ve gerekirse tabloyu hareket ettir
    public void CheckAndMoveTable()
    {
        foreach (TableShelfInfo table in tables)
        {
            bool allSlotsFilled = true;
            Debug.Log($"Checking table: {table.tableCode}");

            foreach (TableSlotInfo slot in table.slots)
            {
                if (!slot.isOccupied)
                {
                    allSlotsFilled = false;
                }
            }

            if (allSlotsFilled)
            {
                StartCoroutine(MoveTableSmoothly(table));
                break; // Hareket ettikten sonra kontrol etmeyi bırak
            }
        }
    }

    private IEnumerator MoveTableSmoothly(TableShelfInfo table)
    {
        Vector3 startPosition = table.transform.position;
        Vector3 endPosition = startPosition;
        endPosition.z += moveDistance;
        float duration = 2.0f; // Hareket süresi (saniye)
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            table.transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        table.transform.position = endPosition;
        Debug.Log($"Table {table.tableCode} moved to {endPosition}");
    }
}

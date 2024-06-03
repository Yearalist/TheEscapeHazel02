using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using SecretCloset;

public class BookDragHandler : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private Vector3 startPosition;
    private Transform originalParent;
    private bool isDragging = false;

    private void Start()
    {
        startPosition = transform.localPosition;
        originalParent = transform.parent;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        startPosition = transform.localPosition;
        originalParent = transform.parent;
        transform.SetParent(GameObject.Find("Canvas").transform);  // Kitabı canvas üzerine taşı
        Debug.Log("Kitap alındı.");
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(eventData.position);
            newPos.z = 0;
            transform.position = newPos;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(eventData.position);
        Debug.Log("Kitap bırakıldı.");

        if (Physics.Raycast(ray, out hit))
        {
            SlotInfo slot = hit.collider.GetComponent<SlotInfo>();
            Debug.Log($"Slot bulundu: {slot}");

            if (slot != null)
            {
                Debug.Log($"Slot kodu: {slot.slotCode}, Kitap kodu: {GetComponent<BookInfo>().slotCode}");

                if (slot.slotTransform.childCount == 0)
                {
                    transform.SetParent(slot.slotTransform);
                    transform.localPosition = Vector3.zero;  // Kitabın slot içinde düzgün yerleşmesini sağlamak için
                    Debug.Log($"Kitap kodu {GetComponent<BookInfo>().slotCode} slot kodu {slot.slotCode} olan slota yerleştirildi.");
                    return;
                }
                else
                {
                    Debug.LogWarning("Slot dolu!");
                }
            }
            else
            {
                Debug.LogWarning("Slot bulunamadı!");
            }
        }
        else
        {
            Debug.LogWarning("Hit collider bulunamadı!");
        }

        transform.SetParent(originalParent);
        transform.localPosition = startPosition;
    }

}

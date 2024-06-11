using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class BookCode : MonoBehaviour
{

    [SerializeField] private Button button;
    [SerializeField] private TMP_InputField userInput;
    [SerializeField] private TMP_Text messageText; 

    private Dictionary<string, string> bookPlaces = new Dictionary<string, string>()
    {
        {"02071877", "4. blok 3. kitaplık 4. raf 6. kitap"},
        {"73086534","2. blok  4. kitaplık 3. raf 2.kitap"},
        {"07011999","11. blok 1. kitaplık  6. raf 10. kitap"},
        {"23041564","7. blok 3. kitaplık 1. raf 1. kitap"},
        {"28042022","12. blok 3. kitaplık 5. raf  11. kitap"},
        {"23032003","5. blok 2. kitaplık 2. raf  3. kitap"}
    };

    private void Start()
    {
        button.onClick.AddListener(GiveBookPlace);
    }

    private void GiveBookPlace()
    {
        if (bookPlaces.TryGetValue(userInput.text, out string place))
        {
            messageText.text = $"Kitap {place} da bulunmakta";
            messageText.color = Color.green;
        }
        else
        {
            messageText.text = "Böyle bir kitap yok";
            messageText.color = Color.red;
        }
    }
}
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PCInputHandler : MonoBehaviour
{
    [SerializeField] private InputMenager inputManager;
    private bool isUsingComputer;
    [SerializeField] private GameObject fakeCursor;
    [SerializeField] private TMP_InputField passwordInput, bookInput;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isUsingComputer)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.TryGetComponent(out PCInputHandler pc))
                {
                    isUsingComputer = true;
                    inputManager.canMove = false;
                    Cursor.lockState = CursorLockMode.Confined;
                    fakeCursor.SetActive(false);
                    passwordInput.SetTextWithoutNotify("");
                    bookInput.SetTextWithoutNotify("");
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isUsingComputer)
        {
            OnExit();
        }
    }


    public void OnExit()
    {
        if (isUsingComputer)
        {
            isUsingComputer = false;
            Cursor.lockState = CursorLockMode.Locked;
            fakeCursor.SetActive(true);
            inputManager.canMove = true;
            passwordInput.DeactivateInputField();
            bookInput.DeactivateInputField();
            passwordInput.SetTextWithoutNotify("");
            bookInput.SetTextWithoutNotify("");
        }
    }
}
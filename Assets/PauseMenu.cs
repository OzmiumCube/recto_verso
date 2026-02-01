using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject main;

    private void Start()
    {
        if (InputManager.Instance == null) return;
        InputManager.Instance.escapeAction.action.performed += OpenMenu;
    }

    private void OnEnable()
    {
        if (InputManager.Instance == null) return;
        InputManager.Instance.escapeAction.action.performed += OpenMenu;
    }

    private void OnDisable()
    {
        if (InputManager.Instance == null) return;
        InputManager.Instance.escapeAction.action.performed -= OpenMenu;
    }

    public void OpenMenu(InputAction.CallbackContext ctx)
    {
        main.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Resume()
    {
        main.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


    }

    public void Exit()
    {
        Application.Quit();
    }


}

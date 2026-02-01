using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject main;
    [SerializeField] Look player1Look;
    [SerializeField] Look player2Look;

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
        player1Look.enabled = false;
        player2Look.enabled = false;
    }

    public void Resume()
    {
        main.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player1Look.enabled = true;
        player2Look.enabled = true;

    }

    public void Exit()
    {
        SceneManager.LoadScene("Main_Menu");
    }


}

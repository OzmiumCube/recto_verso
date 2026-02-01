using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    public static InputManager Instance;


    public InputActionReference swapAction;
    public InputActionReference moveAction;
    public InputActionReference jumpAction;
    public InputActionReference lookAction;
    public InputActionReference swapObjectAction;
    public InputActionReference kickObjectAction;
    public InputActionReference escapeAction;

    void EnableActions()
    {
        swapObjectAction.action.Enable();
        swapAction.action.Enable();
        moveAction.action.Enable();
        jumpAction.action.Enable();
        lookAction.action.Enable();
        kickObjectAction.action.Enable();
        escapeAction.action.Enable();
    }

    void DisableActions()
    {
        swapAction.action.Disable();
        moveAction.action.Disable();
        jumpAction.action.Disable();
        lookAction.action.Disable();
        swapObjectAction.action.Disable();
        kickObjectAction.action.Disable();
        escapeAction.action.Disable();
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        EnableActions();
    }
}

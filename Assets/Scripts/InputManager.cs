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

    private void OnEnable()
    {
        swapAction.action.Enable();
        moveAction.action.Enable();
        jumpAction.action.Enable();
        lookAction.action.Enable();
        swapObjectAction.action.Enable();

    }

    private void OnDisable()
    {
        swapAction.action.Disable();
        moveAction.action.Disable();
        jumpAction.action.Disable();
        lookAction.action.Disable();
        swapObjectAction.action.Disable();

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
    }
}

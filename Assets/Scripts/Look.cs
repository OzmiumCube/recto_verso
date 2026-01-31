using UnityEngine;
using UnityEngine.InputSystem;

public class Look : MonoBehaviour
{
    public Transform cameraTransform;
    public float sensitivity = 2f;

    float yaw;
    float pitch;
    Vector2 lookInput;
    private PlayerController playerController;
   
    private void Start()
    {
        if (InputManager.Instance == null) return;
        playerController = GetComponent<PlayerController>();
        InputManager.Instance.lookAction.action.performed += OnLook;
        InputManager.Instance.lookAction.action.canceled += OnLook;
    }

    private void OnEnable()
    {
        InputManager.Instance.lookAction.action.performed += OnLook;
        InputManager.Instance.lookAction.action.canceled += OnLook;
    }

    private void OnDisable()
    {
        InputManager.Instance.lookAction.action.performed -= OnLook;
        InputManager.Instance.lookAction.action.canceled -= OnLook;
    }

    public void OnLook(InputAction.CallbackContext ctx)
    {
        lookInput = ctx.ReadValue<Vector2>();

    }

    private void Update()
    {
        //if (playerController.currentState == PlayerController.PlayerState.Sliding) return;

        yaw += lookInput.x * sensitivity;
        pitch -= lookInput.y * sensitivity;
        pitch = Mathf.Clamp(pitch, -80f, 80f);

        transform.rotation = Quaternion.Euler(0, yaw, 0);
        if (cameraTransform)
            cameraTransform.localRotation = Quaternion.Euler(pitch, 0, 0);
    }
}
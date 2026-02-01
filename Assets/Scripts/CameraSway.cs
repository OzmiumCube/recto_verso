using UnityEngine;
using UnityEngine.InputSystem;

public class MovementSway : MonoBehaviour
{
    [Header("Camera Sway")]
    public float moveSwayAmount = 0.05f;
    public float moveSwaySmooth = 4f;

    [Header("Weapon Sway")]
    public float lookSwayAmount = 0.02f;
    public float lookSwaySmooth = 6f;

    [Header("Clamp Limits")]
    public Vector3 maxCameraOffset = new Vector3(0.1f, 0.1f, 0.05f);

    [Header("References")]
    public Transform cameraTransform;

    private Vector3 cameraBasePos;
    private Vector3 targetOffsetCamera;
    private Vector3 currentOffsetCamera;
    private Vector2 lookInput;
    private Vector3 movementInput;

    void Start()
    {
        cameraBasePos = cameraTransform.localPosition;

        currentOffsetCamera = Vector3.zero;
        targetOffsetCamera = Vector3.zero;

        if (InputManager.Instance == null) return;
        InputManager.Instance.lookAction.action.performed += SetLookInput;
        InputManager.Instance.lookAction.action.canceled += SetLookInput;
        InputManager.Instance.moveAction.action.performed += SetMovementInput;
        InputManager.Instance.moveAction.action.canceled += SetMovementInput;
    }

    private void OnEnable()
    {
        if (InputManager.Instance == null) return;
        InputManager.Instance.lookAction.action.performed += SetLookInput;
        InputManager.Instance.lookAction.action.canceled += SetLookInput;
        InputManager.Instance.moveAction.action.performed += SetMovementInput;
        InputManager.Instance.moveAction.action.canceled += SetMovementInput;
    }

    private void OnDisable()
    {
        if (InputManager.Instance == null) return;
        InputManager.Instance.lookAction.action.performed -= SetLookInput;
        InputManager.Instance.lookAction.action.canceled -= SetLookInput;
        InputManager.Instance.moveAction.action.performed -= SetMovementInput;
        InputManager.Instance.moveAction.action.canceled -= SetMovementInput;
    }



    public void SetMovementInput(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    public void SetLookInput(InputAction.CallbackContext ctx) => lookInput = ctx.ReadValue<Vector2>();

    void LateUpdate()
    {
        Vector3 moveOffset = new Vector3(movementInput.x * moveSwayAmount, -movementInput.y * moveSwayAmount, 0f);
        Vector3 lookOffset = new Vector3(-lookInput.y * lookSwayAmount, -lookInput.x * lookSwayAmount, 0f);

        targetOffsetCamera = moveOffset;
        targetOffsetCamera.x = Mathf.Clamp(targetOffsetCamera.x, -maxCameraOffset.x, maxCameraOffset.x);
        targetOffsetCamera.y = Mathf.Clamp(targetOffsetCamera.y, -maxCameraOffset.y, maxCameraOffset.y);
        targetOffsetCamera.z = Mathf.Clamp(targetOffsetCamera.z, -maxCameraOffset.z, maxCameraOffset.z);

        currentOffsetCamera = Vector3.Lerp(currentOffsetCamera, targetOffsetCamera, Time.deltaTime * moveSwaySmooth);
        cameraTransform.localPosition = cameraBasePos + currentOffsetCamera;
    }
}

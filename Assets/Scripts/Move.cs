using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Move : MonoBehaviour
{
    public float moveSpeed = 6f;
    //public float sprintMultiplier = 1.7f;
    public float acceleration = 20f;

   // public InputActionReference sprintAction;
    Rigidbody rb;
    Vector2 moveInput;
    bool isSprinting; 

    private PlayerController playerController;

    void Awake() => rb = GetComponent<Rigidbody>();

    private void Start()
    {
        if (InputManager.Instance == null) return;
        playerController = GetComponent<PlayerController>();
        InputManager.Instance.moveAction.action.performed += OnMove;
        InputManager.Instance.moveAction.action.canceled += OnMove;
    }

    private void OnEnable()
    {
        if (InputManager.Instance == null) return;
        InputManager.Instance.moveAction.action.performed += OnMove;
        // sprintAction.action.performed += OnSprint;
        InputManager.Instance.moveAction.action.canceled += OnMove;
       // sprintAction.action.canceled += OnSprint;
       // sprintAction.action.Enable();
    }

    private void OnDisable()
    {
        if (InputManager.Instance == null) return;
        InputManager.Instance.moveAction.action.performed -= OnMove;
        // sprintAction.action.performed -= OnSprint;
        InputManager.Instance.moveAction.action.canceled -= OnMove;
        //sprintAction.action.canceled -= OnSprint;
      //  sprintAction.action.Disable();
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }

    public void OnSprint(InputAction.CallbackContext ctx)
        => isSprinting = ctx.ReadValueAsButton();

    private void FixedUpdate()
    {
        if (playerController.currentState == PlayerController.PlayerState.Sliding) return;
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        Vector3 inputDir = (forward * moveInput.y + right * moveInput.x).normalized;
        float speed = moveSpeed; // * (isSprinting ? sprintMultiplier : 1f);

        Vector3 targetVel = inputDir * speed;
        Vector3 currentXZ = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);

        Vector3 newXZ = Vector3.MoveTowards(currentXZ, targetVel, acceleration * Time.fixedDeltaTime);
        rb.linearVelocity = new Vector3(newXZ.x, rb.linearVelocity.y, newXZ.z);
        rb.linearDamping = inputDir.magnitude > 0.1f ? 0f : 5f;
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
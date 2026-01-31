using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerController;

[RequireComponent(typeof(Rigidbody))]
public class Jump : MonoBehaviour
{
    public float verticalJumpForce = 6.5f;
    public float horizontalJumpForce = 6.5f;

    Rigidbody rb;
    bool jumpQueued;
    private bool dashJumpQueued;
    private PlayerController playerController;
    private bool jumpStarting;
    private void Start()
    {
        if (InputManager.Instance == null) return;
        playerController = GetComponent<PlayerController>();
        InputManager.Instance.jumpAction.action.performed += OnJump;
    }

    void Awake() => rb = GetComponent<Rigidbody>();

    private void OnEnable()
    {
        if (InputManager.Instance == null) return;
        InputManager.Instance.jumpAction.action.performed += OnJump;
    }

    private void OnDisable()
    {
        if (InputManager.Instance == null) return;
        InputManager.Instance.jumpAction.action.performed -= OnJump;
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && playerController.grounded && (playerController.currentState == PlayerState.Idle))
            jumpQueued = true;

        if (ctx.performed && playerController.grounded && (playerController.currentState == PlayerState.Sliding))
            dashJumpQueued = true;
    }


    private void Update()
    {
        if (jumpQueued)
        {
            if(playerController.currentState == PlayerState.Idle)
            {
                StartCoroutine(JumpRoutine());
            }
        }


        if (playerController.currentState == PlayerState.Jumping && playerController.grounded && !jumpStarting)
        {
            playerController.currentState =  PlayerState.Idle;
        }
    }

    private IEnumerator JumpRoutine()
    {
        Vector3 v = rb.linearVelocity;
        v.y = 0f;
        rb.linearVelocity = v;
        rb.linearVelocity += Vector3.up * verticalJumpForce;
        jumpQueued = false;

        jumpStarting = true;
        playerController.currentState = PlayerState.Jumping;
        yield return new WaitForSeconds(0.3f);
        jumpStarting = false;
    }
}
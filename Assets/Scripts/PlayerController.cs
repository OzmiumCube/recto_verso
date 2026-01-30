using DG.Tweening.Core.Easing;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public bool stealthed;

    public enum PlayerState
    {
        Idle,
        Jumping,
        Sliding,
        Dashing
    }

    public bool grounded = false;
    public PlayerState currentState = PlayerState.Idle;
    [Header("References")]
    public Transform cameraTransform;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        grounded = IsGrounded();

    }

    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}

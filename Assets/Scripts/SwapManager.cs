using UnityEngine;
using UnityEngine.InputSystem;

public class SwapManager : MonoBehaviour
{
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;

    public int currentPlayer = 1;

    private void OnEnable()
    {
        if (InputManager.Instance == null) return;
        InputManager.Instance.swapAction.action.performed += OnSwapButton;
    }

    private void OnDisable()
    {
        if (InputManager.Instance == null) return;
        InputManager.Instance.swapAction.action.performed -= OnSwapButton;

    }

    private void OnSwapButton(InputAction.CallbackContext ctx)
    {
        SwapPlayer();
    }


    private void Start()
    {
        if (InputManager.Instance == null) return;
        player1.SetActive(true);
        player2.SetActive(false);
        InputManager.Instance.swapAction.action.performed += OnSwapButton;

    }

    private void SwapPlayer()
    {
        player1.SetActive(!player1.activeSelf);
        player2.SetActive(!player2.activeSelf);
        currentPlayer = currentPlayer == 1 ? 2 : 1;
    }


}

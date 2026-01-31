using UnityEngine;
using UnityEngine.InputSystem;

public class SwapManager : MonoBehaviour
{
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;

    private int currentPlayer = 1;

    private void OnEnable()
    {
        InputManager.Instance.swapAction.action.performed += OnSwapButton;
    }

    private void OnDisable()
    {
        InputManager.Instance.swapAction.action.performed -= OnSwapButton;

    }

    private void OnSwapButton(InputAction.CallbackContext ctx)
    {
        SwapPlayer();
    }


    private void Start()
    {
        //player1.SetActive(true);
        //player2.SetActive(false);
    }

    private void SwapPlayer()
    {
        player1.SetActive(!player1.activeSelf);
        player2.SetActive(!player2.activeSelf);
        currentPlayer = currentPlayer == 1 ? 2 : 1;
    }


}

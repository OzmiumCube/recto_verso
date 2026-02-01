using MoreMountains.Feedbacks;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwapManager : MonoBehaviour
{
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] MMF_Player fadeInFeedback;
    [SerializeField] MMF_Player fadeOutFeedback;

    public int currentPlayer = 1;

    public event Action<int> OnPlayerSwap;

    public static SwapManager Instance;

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
        StartCoroutine(SwapPlayer());
    }


    private void Start()
    {
        if (InputManager.Instance == null) return;
        player1.SetActive(true);
        player2.SetActive(false);
        InputManager.Instance.swapAction.action.performed += OnSwapButton;

    }

    private IEnumerator SwapPlayer()
    {
        yield return StartCoroutine(fadeInFeedback.PlayFeedbacksCoroutine(transform.position, 1f, false));

        


        player1.SetActive(!player1.activeSelf);
        player2.SetActive(!player2.activeSelf);
        currentPlayer = currentPlayer == 1 ? 2 : 1;
        OnPlayerSwap?.Invoke(currentPlayer);

        if (currentPlayer == 1)
        {
            player1.transform.localRotation = player2.transform.localRotation;
        }
        else player2.transform.localRotation = player1.transform.localRotation;


        yield return StartCoroutine(fadeOutFeedback.PlayFeedbacksCoroutine(transform.position, 1f, false));

    }


}

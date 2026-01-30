using UnityEngine;

public class interact : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        InputManager.Instance.swapObjectAction.action.performed += OnSwap;
        InputManager.Instance.swapObjectAction.action.canceled += OnSwap;
    }

    private void OnDisable()
    {
        InputManager.Instance.swapObjectAction.action.performed -= OnSwap;
        InputManager.Instance.swapObjectAction.action.canceled -= OnSwap;
    }

    private void OnSwap(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        Debug.Log("swap object");
    }
    
    private void SwapObject()
    {
        Debug.Log("swap object method called");
    }

}


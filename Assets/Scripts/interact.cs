using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    [SerializeField] float swapRange;

    [SerializeField] Transform room1Maskables;
    [SerializeField] Transform room2Maskables;

    private void Start()
    {
        if (InputManager.Instance == null) return;
        InputManager.Instance.swapObjectAction.action.performed += OnSwap;
    }

    private void OnEnable()
    {
        if (InputManager.Instance == null) return;
        InputManager.Instance.swapObjectAction.action.performed += OnSwap;
    }

    private void OnDisable()
    {
        if (InputManager.Instance == null) return;
        InputManager.Instance.swapObjectAction.action.performed -= OnSwap;

    }
    private void OnSwap(InputAction.CallbackContext ctx)
    {
        CheckForMaskable();
    }
    

    private void CheckForMaskable()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, swapRange))
        {
            if(hit.collider.CompareTag("Maskable"))
            {
                SwapObject(hit.collider.gameObject);
            }
        }
    }

    private void SwapObject(GameObject objectHit)
    {
        Transform roomTransform = objectHit.transform.parent.transform;

        if(roomTransform == room1Maskables)
        {
            print("Moving to room 2!");
            objectHit.transform.SetParent(room2Maskables, false);
        } 
        else
        {
            objectHit.transform.SetParent(room1Maskables,false);
            print("Moving to room 1!");
        }
    }

}


using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class RealityText : MonoBehaviour
{
    [SerializeField] TMP_Text realityText;

    void Start()
    {
        realityText.text = "First Reality";
        SwapManager.Instance.OnPlayerSwap += SwapReality;
    }

    private void OnDisable()
    {
        SwapManager.Instance.OnPlayerSwap -= SwapReality;
    }


    private void SwapReality(int newReality)
    {
        print("here");
        if(newReality == 1)
        {
            realityText.text = "First Reality";
        } else realityText.text = "Second Reality";
    }
}

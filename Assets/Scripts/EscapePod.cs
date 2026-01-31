using UnityEngine;

public class EscapePod : MonoBehaviour
{

    [SerializeField] GameManager gameManager;
    [SerializeField] int playerID;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
          
            gameManager.PlayerAtEscape(playerID);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            gameManager.PlayerLeaveEscape(playerID);
        }
    }
}

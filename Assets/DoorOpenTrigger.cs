using UnityEngine;

public class DoorOpenTrigger : MonoBehaviour
{
    [SerializeField] Door door;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            door.DoorOpenTriggered();
            gameObject.SetActive(false);
        }
    }
}

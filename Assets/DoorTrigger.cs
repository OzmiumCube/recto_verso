using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] Door door;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            door.DoorTriggered();
            gameObject.SetActive(false);
        }
    }
}

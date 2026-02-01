using UnityEngine;

public class DoorCloseTrigger : MonoBehaviour
{
    [SerializeField] Door door;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            door.DoorCloseTriggered();
            gameObject.SetActive(false);
        }
    }
}

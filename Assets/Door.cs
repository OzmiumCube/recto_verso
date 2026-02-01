using MoreMountains.Feedbacks;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] MMF_Player doorCloseFeedback;
    [SerializeField] MMF_Player doorOpenFeedback;
    [SerializeField] GameObject doorHitbox;



    public void DoorCloseTriggered()
    {
        doorHitbox.SetActive(true);
        doorCloseFeedback.PlayFeedbacks();
    }

    public void DoorOpenTriggered()
    {
        doorHitbox.SetActive(false);
        doorOpenFeedback.PlayFeedbacks();
    }
}

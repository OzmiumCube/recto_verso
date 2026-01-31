using MoreMountains.Feedbacks;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] MMF_Player doorFeedback;
    [SerializeField] GameObject doorHitbox;



    public void DoorTriggered()
    {
        doorHitbox.SetActive(true);
        doorFeedback.PlayFeedbacks();
    }
}

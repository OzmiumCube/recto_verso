using MoreMountains.Feedbacks;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    [SerializeField] MMF_Player ambienceFeedback;

    private void Start()
    {
        ambienceFeedback.PlayFeedbacks();
    }
}

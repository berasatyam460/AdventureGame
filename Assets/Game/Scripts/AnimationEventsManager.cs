using UnityEngine;

public class AnimationEventsManager : MonoBehaviour
{
    public void DisableHeadTrack()
    {
        ActionManger.headTrackOff?.Invoke();
    }
}

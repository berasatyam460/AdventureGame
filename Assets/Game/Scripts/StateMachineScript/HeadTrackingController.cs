using System.Collections;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class HeadTrackingController : MonoBehaviour
{
    [SerializeField] private Transform headTarget;
    [SerializeField] private MultiAimConstraint headRig;

    private void OnEnable()
    {
        ActionManger.headTrackingON += EnableHeadTrack;
        ActionManger.headTrackOff += DisableHeadTrack;
    }

    private void OnDisable()
    {
        ActionManger.headTrackingON -= EnableHeadTrack;
        ActionManger.headTrackOff -= DisableHeadTrack;
    }

    private void Awake()
    {
        headRig.weight = 0f; // start disabled
    }

    public void EnableHeadTrack(Transform targetGameObject)
    {

        if (targetGameObject == null) return;

        // Instead of copying position, follow the transform
        headTarget.SetParent(targetGameObject);
        headTarget.localPosition = Vector3.zero;
        headTarget.localRotation = Quaternion.identity;

        headRig.weight = 1f;
        Debug.Log("Head tracking ENABLED");


    }

    public void DisableHeadTrack()
    {
        headRig.weight = 0f;


        headTarget.SetParent(null); // detach so it doesn't stick
        Debug.Log("Head tracking DISABLED");
    }

}

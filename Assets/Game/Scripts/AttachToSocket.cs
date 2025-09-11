using UnityEngine;

public class AttachToSocket : MonoBehaviour
{
    [SerializeField] private Transform ScoketTransform;
    [SerializeField] GameObject objectNeedToAttched;

    public void AttachTorch()
    {
        var obj = GameObject.Instantiate(objectNeedToAttched);
        obj.transform.SetParent(ScoketTransform);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;
    }


}

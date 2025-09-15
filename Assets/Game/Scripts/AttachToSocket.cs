using UnityEngine;

public class AttachToSocket : MonoBehaviour
{
    [SerializeField] private Transform ScoketTransform;
    [SerializeField] GameObject objectNeedToAttched;
    [SerializeField] GameObject objectToHide;

    public void AttachTorch()
    {
        var obj = GameObject.Instantiate(objectNeedToAttched);
        obj.transform.SetParent(ScoketTransform);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;
        HideAllMesh();



    }


    private void HideAllMesh()
    {
        MeshRenderer[] m_r = objectToHide.GetComponentsInChildren<MeshRenderer>();
        foreach (var mr in m_r)
        {
            mr.enabled = false;
        }
    }


}

using UnityEngine;

public class AttachToSocket : MonoBehaviour
{
    [SerializeField] private Transform torchSocket;
    [SerializeField] GameObject currentTorch;

    public void AttachTorch()
    {

        currentTorch.transform.SetParent(torchSocket);
        currentTorch.transform.localPosition = Vector3.zero;
        currentTorch.transform.localRotation = Quaternion.identity;
    }
}

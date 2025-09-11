using UnityEngine;

public class AnimationTester : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] string animationStateName = "GrabTorch"; // must match the Animator state name exactly

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) // press G to test
        {
            Debug.Log("Playing animation: " + animationStateName);
            animator.CrossFade(animationStateName, 0.1f);
        }
    }
}




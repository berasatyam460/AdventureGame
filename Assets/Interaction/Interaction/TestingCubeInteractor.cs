using System.Collections;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class TestingCubeInteractor : InteractableBase
{
    [SerializeField] int interactionNo;
    [SerializeField] GameObject player;
    private NavMeshAgent playerNavMeshAgent;
    private ThirdPersonController thirdPersonController;
    private Animator playerAnimator;
    [SerializeField] Transform interactingPoint;

    void Awake()
    {
        playerNavMeshAgent = player.GetComponent<NavMeshAgent>();
        thirdPersonController = player.GetComponent<ThirdPersonController>();
        playerAnimator = player.GetComponent<Animator>();
    }

    public override void Interact(GameObject interctingObject)
    {
        base.Interact(interctingObject);
        float distance = Vector3.Distance(playerNavMeshAgent.transform.position, interactingPoint.position);

        if (distance > 0.5f)
        {
            playerNavMeshAgent.SetDestination(interactingPoint.position);
            thirdPersonController._controller.enabled = false;
            StartCoroutine(StartInteraction());
        }
        else
        {
            StartCoroutine(PlayAnim(this.gameObject));
        }


    }


    IEnumerator StartInteraction()
    {

        while (Vector3.Distance(playerNavMeshAgent.transform.position, interactingPoint.position) > 0.1f)
        {
            playerAnimator.SetFloat("Speed", 2);
            thirdPersonController._controller.Move(playerNavMeshAgent.velocity);
            yield return null;

        }
        playerNavMeshAgent.ResetPath();

        StartCoroutine(PlayAnim(this.gameObject));
    }

    IEnumerator PlayAnim(GameObject interactableObject)
    {

        ActionManger.AnimationType?.Invoke(true, interactionNo, interactableObject);
        yield return new WaitForSeconds(0.1f);
        ActionManger.AnimationType?.Invoke(false, interactionNo, interactableObject);

        yield return new WaitForSeconds(2f);
        ActionManger.headTrackOff?.Invoke();
    }
}

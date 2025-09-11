using UnityEngine;

using UnityEngine.InputSystem;
public class LockMovement : StateMachineBehaviour
{
    // Called when the animator starts playing the state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var playerinput = animator.GetComponent<PlayerInput>();

        if (playerinput != null)
        {

            playerinput.enabled = false; // disable movement
        }
    }

    // Called when the animator finishes the state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var playerinput = animator.GetComponent<PlayerInput>();
        if (playerinput != null)
        {
            playerinput.enabled = true; // enable movement

        }
    }
}



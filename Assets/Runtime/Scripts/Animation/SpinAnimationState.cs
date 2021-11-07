using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAnimationState : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerController playerController = animator.transform.parent.GetComponent<PlayerController>();
        playerController.enabled = true;
    }
}

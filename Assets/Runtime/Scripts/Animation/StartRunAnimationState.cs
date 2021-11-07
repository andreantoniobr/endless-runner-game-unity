using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRunAnimationState : StateMachineBehaviour
{
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //TODO: Remover isso, nao assumir que o player eh pai do animator
        PlayerController player = animator.transform.parent.GetComponent<PlayerController>();
        if (player != null)
        {
            player.enabled = true;
        }
    }
}

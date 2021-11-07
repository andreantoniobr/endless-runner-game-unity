using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitGameStartAnimationState : StateMachineBehaviour
{/*
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //TODO: Remover o assumption de que o player eh sempre o pai do animator
        PlayerController player = animator.transform.parent.GetComponent<PlayerController>();
        if (player != null)
        {
            player.enabled = false;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger(PlayerAnimationConstants.StartGameTrigger);
        }
    }*/
}

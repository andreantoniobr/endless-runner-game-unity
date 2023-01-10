using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSideToSideAnimationState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        AnimatorClipInfo[] clips = animator.GetNextAnimatorClipInfo(layerIndex);
        if (clips.Length > 0)
        {
            AnimatorClipInfo jumpClipInfo = clips[0];
            //TODO: Resolver isso.
            MovableObstacle obstacle = animator.transform.parent.parent.parent.GetComponent<MovableObstacle>();
            if (obstacle)
            {
                float timeToCompleteAnimationCicle = obstacle.MovementDuration * 2;
                float multiplier = jumpClipInfo.clip.length / timeToCompleteAnimationCicle;
                animator.SetFloat(RatAnimationConstants.SideToSideMultiplier, multiplier);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private PlayerController player;

    private void Awake()
    {
        player = GetComponent<PlayerController>();
    }

    private void Update()
    {
        animator.SetBool(PlayerAnimationConstants.IsJumping, player.IsJumping);
        animator.SetBool(PlayerAnimationConstants.IsRolling, player.IsRolling);
    }

    public void Die()
    {
        animator.SetTrigger(PlayerAnimationConstants.DieTrigger);
    }

    public void PlayStartGameAnimation()
    {
        animator.SetTrigger(PlayerAnimationConstants.StartGameTrigger);
    }

    public float GetAnimationTime(string stateName)
    {
        float animationTime = 0;
        AnimatorStateInfo animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (animatorStateInfo.IsName(stateName))
        {
            animationTime = animatorStateInfo.normalizedTime;
        };
        return animationTime;
    }
}

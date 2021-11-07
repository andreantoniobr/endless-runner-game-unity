using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ObstacleDecoration : AudioMain
{
    //Audio Cue
    [SerializeField] private AudioClip collisionAudio;
    [SerializeField] private Animation collisionAnimation;    

    public void PlayCollisionFeedback()
    {
        PlayAudio(collisionAudio);

        if (collisionAnimation != null)
        {
            collisionAnimation.Play();
        }
    }
}

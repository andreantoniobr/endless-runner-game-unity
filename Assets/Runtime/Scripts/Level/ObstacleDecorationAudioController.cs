using UnityEngine;

public class ObstacleDecorationAudioController : AudioMain
{
    [SerializeField] private AudioClip collisionAudio;

    public void PlayCollisionFeedback()
    {
        PlayAudio(collisionAudio);
    }

    public void StopCollisionFeedback()
    {
        StopAudio();
    }
}

using UnityEngine;

public class PlayerAudioController : AudioMain
{
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip rollSound;
    [SerializeField] private AudioClip deadSound;

    public void PlayJumpSound()
    {
        PlayAudio(jumpSound);
    }

    public void PlayRollSound()
    {
        PlayAudio(rollSound);
    }

    public void PlayDeadSound()
    {
        PlayAudio(deadSound);
    }
}

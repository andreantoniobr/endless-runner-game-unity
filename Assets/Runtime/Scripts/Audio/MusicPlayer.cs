using UnityEngine;

public class MusicPlayer : AudioMain
{
    [SerializeField] private AudioClip startMenuMusic;
    [SerializeField] private AudioClip mainTrackMusic;
    [SerializeField] private AudioClip deadMusic;

    public void PlayStartMenuMusic()
    {
        PlayAudio(startMenuMusic, true);
    }

    public void PlayMainTrackMusic()
    {
        PlayAudio(mainTrackMusic, true);
    }

    public void PlayDeadMusic()
    {
        PlayAudio(deadMusic, true);
    }

    public void StopMusic()
    {
        StopAudio();
    }
}

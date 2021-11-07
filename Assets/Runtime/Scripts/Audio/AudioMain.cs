using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioMain : MonoBehaviour
{
    private AudioSource audioSource;
    protected AudioSource AudioSource => audioSource == null ? audioSource = GetComponent<AudioSource>() : audioSource;

    protected void PlayAudio(AudioClip clip, bool isLooping = false)
    {
        if (AudioSource.outputAudioMixerGroup == null)
        {
            Debug.LogError("Erro: Todo AudioSource deve ter um AudioMixerGroup assinalado.");
        }
        else 
        {
            AudioSource.clip = clip;
            AudioSource.loop = isLooping;
            AudioSource.Play();
        }        
    }

    protected void StopAudio()
    {
        AudioSource.Stop();
    }
}

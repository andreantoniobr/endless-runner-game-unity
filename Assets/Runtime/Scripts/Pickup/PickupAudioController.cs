using UnityEngine;

public class PickupAudioController : AudioMain
{
    [SerializeField] private AudioClip pickupSound;
    public AudioClip PickupSound => pickupSound;

    public void PlayPickupSound()
    {
        PlayAudio(pickupSound);
    }
}

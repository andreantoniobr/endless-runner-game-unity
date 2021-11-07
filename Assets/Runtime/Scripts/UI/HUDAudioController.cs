using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDAudioController : AudioMain
{
    [SerializeField] private AudioClip buttonPressSound;

    public void PlayButtonPressSound()
    {
        PlayAudio(buttonPressSound);
    }
}

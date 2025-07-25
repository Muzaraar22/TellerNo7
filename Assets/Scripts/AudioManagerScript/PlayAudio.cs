using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : AudioPlayer
{
    [SerializeField] AudioClip audioClip;
    protected void PlayAssignedClip()
    {
        PlayClip(audioClip);
    }
}
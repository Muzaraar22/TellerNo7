using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioWithRandomPitch : AudioPlayer
{
    [SerializeField] AudioClip audioClip;
    [SerializeField] float pitchRandomness = 0.05f;
    public void PlayAssignedClipWithRandomPitch()
    {
        PlayClipWithVariablePitch(audioClip, pitchRandomness);
    }
}
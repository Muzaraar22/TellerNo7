using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioWithTime : AudioPlayer
{
    [SerializeField] AudioClip audioClip;
    [SerializeField] float startTime;
    [SerializeField] float endTime;
    protected void PlayAssignedClipWithTime()
    {
        PlayClipWithTime(audioClip, startTime, endTime);
    }
}
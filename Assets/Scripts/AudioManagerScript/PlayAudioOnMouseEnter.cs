using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnMouseEnter : AudioPlayer
{
    [SerializeField] AudioClip audioClip;
    protected void OnMouseOver()
    {
        PlayClip(audioClip);
    }
}
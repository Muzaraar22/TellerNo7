using UnityEngine;
using rand = UnityEngine.Random;

public class TypeIntroAudio : AudioPlayer
{
    [SerializeField] AudioClip[] typeClips;
    public void PlayIntroAudio()
    {
        AudioClip introClip = typeClips[rand.Range(0, typeClips.Length)];
        PlayClip(introClip);
    }
}
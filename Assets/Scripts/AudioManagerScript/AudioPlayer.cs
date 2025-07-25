using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class AudioPlayer : MonoBehaviour
{
    public float basePitch;
    protected AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        basePitch = audioSource.pitch;
    }

    protected void PlayClipWithVariablePitch(AudioClip clip, float pitchRandomness = 0.05f)
    {
        var randomPitch = UnityEngine.Random.Range(-pitchRandomness, pitchRandomness);
        audioSource.pitch = basePitch + randomPitch;
        PlayClip(clip);
    }

    protected void PlayClip(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }

    /*Memainkan berdasar waktu mulai sampai waktu selesai*/
    protected void PlayClipWithTime(AudioClip clip, float startTime, float endTime)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.time = startTime;
        audioSource.Play();
        StartCoroutine(WaitForTimeAudio(endTime - startTime));
    }

    IEnumerator WaitForTimeAudio(float time)
    {
        yield return new WaitForSeconds(time);
    }

}
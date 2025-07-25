// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// //GAGAL
// public abstract class AudioPlayerGeneral : MonoBehaviour
// {
//     [Header("Customize Audio")]
//     public float pitchRandomness = 0.05f;
//     public float basePitch;
//     [Header("InputSound")]
//     public AudioClip[] clips;
//     protected AudioSource audioSource;

//     private void Awake()
//     {
//         audioSource = GetComponent<AudioSource>();
//     }

//     private void Start()
//     {
//         basePitch = audioSource.pitch;
//     }

//     protected void PlayClipWithVariablePitch(AudioClip clip)
//     {
//         var randomPitch = UnityEngine.Random.Range(-pitchRandomness, pitchRandomness);
//         audioSource.pitch = basePitch + randomPitch;
//         PlayClip(clip);
//     }

//     protected void PlayClip(AudioClip clip)
//     {
//         audioSource.Stop();
//         audioSource.clip = clip;
//         audioSource.Play();
//     }


// }
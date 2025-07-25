// using UnityEngine;


// //GAGAL
// [RequireComponent(typeof(AudioSource))]
// [ExecuteInEditMode]
// public class SFXPlayer : AudioPlayerGeneral
// {
//     [SerializeField]
//     protected SFXLibrary sfxLibrary;
//     public string clipName;
//     public int clipIndex = 0;
//     // menampilkan nama clip di inspector
//     [HideInInspector]
//     public AudioClip currentClip;

//     private void Awake()
//     {
//         audioSource = GetComponent<AudioSource>();
//         sfxLibrary = FindFirstObjectByType<SFXLibrary>();
//         DontDestroyOnLoad(gameObject);
//     }

//     private void Start()
//     {
//         currentClip = sfxLibrary.GetClipsFromName(clipName)[clipIndex];
//     }

//     private void PlaySFXRandom()
//     {
//         AudioClip[] clips = sfxLibrary.GetClipsFromName(clipName);
//         if (clips != null && clips.Length > 0)
//         {
//             currentClip = clips[Random.Range(0, clips.Length)];
//         }
//         PlayClip(currentClip);
//     }

//     private void PlaySFX()
//     {
//         PlayClip(currentClip);
//     }

//     private void PlaySFXWithRandomPitch()
//     {
//         PlayClipWithVariablePitch(currentClip);
//     }
// }

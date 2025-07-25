using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject bgHitam;
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider BrightnessSlider;
    public Image BrightnessPanel;
    
    //Ini diwakilin ama gameobject aja dulu hehe

    // public void OpenSettings()
    // {
    //     settingsPanel.SetActive(true);
    //     bgHitam.SetActive(true);
    // }

    private void Start()
    {
        LoadSettings();
    }
 
    public void UpdateMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    }

    public void UpdateSoundVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    }

    public void UpdateBrightness(float brightness)
    {
        BrightnessPanel.color = new Color(BrightnessPanel.color.r, BrightnessPanel.color.g, BrightnessPanel.color.b, 1-brightness);
    }

    public void SaveSettings()
    {
        audioMixer.GetFloat("MusicVolume", out float musicVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);

        audioMixer.GetFloat("SFXVolume", out float sfxVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);

        PlayerPrefs.SetFloat("Brightness", BrightnessSlider.value);
    }

    public void LoadSettings()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(musicSlider.value) * 20);

        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(sfxSlider.value) * 20);

        BrightnessSlider.value = PlayerPrefs.GetFloat("Brightness");
        BrightnessPanel.color = new Color(BrightnessPanel.color.r, BrightnessPanel.color.g, BrightnessPanel.color.b, 1 - BrightnessSlider.value);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

    public AudioMixerGroup master;
    public AudioMixerGroup music;
    public AudioMixerGroup soundFX;
    public GameObject fullScreenOn;
    public GameObject fullScreenOff;
    public Dropdown dropdownGraphics;
    public Dropdown dropdownResolution;
    private Slider sliderM;
    private Slider sliderMu;
    private Slider sliderSFX;

    private Resolution[] resolutions;


    private void Start()
    {
        Cursor.visible = true;

        resolutions = Screen.resolutions;

        dropdownResolution.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for(int i= 0; i<resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        dropdownResolution.AddOptions(options);
        dropdownResolution.value = currentResolutionIndex;
        dropdownResolution.RefreshShownValue();


        //sliderM = GameObject.Find("MasterVolumeSlider").GetComponent<Slider>();
        //sliderM.value = master.audioMixer.;
        //sliderMu = GameObject.Find("MusicVolumeSlider").GetComponent<Slider>();
        //sliderMu.value = ;
        //sliderSFX = GameObject.Find("SoundVolumeSlider").GetComponent<Slider>();
        //sliderSFX.value = ;
    }


    public void SetMasterVolume(float volume)
    {
        master.audioMixer.SetFloat("MasterVol", volume);
        //sliderM.value = volume;
    }

    public void SetMusicVolume(float volume)
    {
        //sliderMu.value = volume;
        music.audioMixer.SetFloat("MusicVol", volume);
    }

    public void SetSoundFxVolume(float volume)
    {
        //sliderSFX.value = volume;
        soundFX.audioMixer.SetFloat("SoundFXVol", volume);
    }

    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;

        if (!isFullScreen)
        {
            fullScreenOff.SetActive(true);
            fullScreenOn.SetActive(false);
        }
        else if (isFullScreen)
        {
            fullScreenOff.SetActive(false);
            fullScreenOn.SetActive(true);
        }
    }

    public void AddDropdownGraphicsValue()
    {
        dropdownGraphics.value = (dropdownGraphics.value + 1) % 3;
    }


    public void AddDropdownResolutionValue()
    {
        dropdownResolution.value = (dropdownResolution.value + 1) % resolutions.Length;
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    
}

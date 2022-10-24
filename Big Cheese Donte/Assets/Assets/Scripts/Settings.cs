using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public AudioMixer mixer;
    
    public TMPro.TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currenResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].width == Screen.currentResolution.height)
            {
                currenResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currenResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void Setmaster(float volume)
    {
        mixer.SetFloat("master", volume);


    }
    public void Setmusic(float volume)
    {
        mixer.SetFloat("music", volume);

    } public void Setsound(float volume)
    {
        mixer.SetFloat("sound", volume);

    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void Vsync(bool b)
        {
        
            if(b)
            {
                QualitySettings.vSyncCount = 4;
                print($"{QualitySettings.vSyncCount}");
            }
            else if(!b)
            {
                QualitySettings.vSyncCount = 0;
                print($"{QualitySettings.vSyncCount}");
            }
            
        }
}

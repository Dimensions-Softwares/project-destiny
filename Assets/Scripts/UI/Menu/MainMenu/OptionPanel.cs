using System.Collections.Generic;   
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class OptionPanel : MonoBehaviour
{
    public Dropdown resolutionDropdown; // dropdown menu showing all resolution from ur personal display
    public AudioMixer audioMixer; // Principal sound in unity
    Resolution[] resolutions;
    public void Start()
    {
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray(); // getting personal screen resolution display and delete duplicate resolution
        resolutionDropdown.ClearOptions(); // clear the initial 
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for(int i = 0; i<resolutions.Length; i++) 
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;// convert resolution in good format ex : 1920x1080
            options.Add(option);
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height) // getting the personal screen resolution
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options); // add all options value
        resolutionDropdown.value = currentResolutionIndex; // setting the personal screen resolution
        resolutionDropdown.RefreshShownValue(); // refresh default dropdwon value
        Screen.fullScreen = true;
    }
    public void setVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume); // Dynamic volume modification from slider
    }

    public void setFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen; //getting toogle value of fullscreen 
        
    }

    public void setResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen); // set screen resolutions
    }
}

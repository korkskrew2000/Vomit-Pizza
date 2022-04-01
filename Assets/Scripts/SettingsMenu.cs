using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {
    Resolution[] resolutions;
    public Dropdown resolitionDropdown;
    const string resName = "resolutionoption";

    private void Awake() {
        resolitionDropdown.onValueChanged.AddListener(new UnityAction<int>(index => {
            PlayerPrefs.SetInt(resName, resolitionDropdown.value);
            PlayerPrefs.Save();
        }));
    }
    private void Start() {
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
        resolitionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width &&
                resolutions[i].height == Screen.height) {
                currentResolutionIndex = i;
            }
        }
        resolitionDropdown.AddOptions(options);
        resolitionDropdown.value = PlayerPrefs.GetInt(resName, currentResolutionIndex);
        resolitionDropdown.RefreshShownValue();
    }
    public void SetResolution(int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
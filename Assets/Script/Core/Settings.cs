using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    private int _fullScreenSetting;
    [Range(0,4)]
    private int _vsyncCount = 0;
    [SerializeField] private string[] _resolutionIndex;

    // TODO: Refactor this into SetQualitySettings method
    void OnGUI()
    {
        string[] names = QualitySettings.names;
        GUILayout.BeginVertical();
        for (int i = 0; i < names.Length; i++)
        {
            if (GUILayout.Button(names[i]))
            {
                QualitySettings.SetQualityLevel(i, true);
            }
        }
        GUILayout.EndVertical();
    }

    private void SetQualitySettings()
    {
        
    }

    private void SetVSyncCount(int newCount)
    {
        _vsyncCount = newCount;
        // TODO: Refactor this.
        if (_vsyncCount <= 0) _vsyncCount = 0;
        else if (_vsyncCount >= 4) _vsyncCount = 4;
        else _vsyncCount = QualitySettings.vSyncCount = _vsyncCount;
    }

    private void SetFullscreen(int screenSetting)
    {
        Screen.fullScreenMode = (FullScreenMode)screenSetting;
        _fullScreenSetting = screenSetting;
    }

    private void SetResolution(int width = 1920, int height = 1080)
    {
        //! 900 x 600
        //! 1024 x 720
        //! 1920 x 1080
        string[] s = _resolutionIndex[0].Split(char.Parse("x"));
        foreach (var item in s)
        {
            Debug.Log(item);
        }
        //Screen.SetResolution(width, height, (FullScreenMode)_fullScreenSetting, 60);
    }
}

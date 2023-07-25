using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Michsky.UI.ModernUIPack;

namespace GameJam.Shell
{
    public class Settings : MonoBehaviour
    {
        [Header("UI - PseudoUI")] [SerializeField]
        private Button _buttonPrefab;

        [SerializeField] private Transform _buttonParent;
        [SerializeField] private Button[] _buttons;
        [SerializeField] private Vector3 yPos = Vector3.zero;

        [Header("UI - Final")] [SerializeField]
        private HorizontalSelector _framerateSelector;

        [Space(20)] private int _fullScreenSetting;
        [Range(0, 4)] private int _vsyncCount = 0;
        [SerializeField] private string[] _resolutionIndex;

        public void Initialized()
        {
            _framerateSelector.onValueChanged.AddListener(SetTargetFramerate);
            
            Debug.Log($"[LOG]: Settings Initialized");
        }

        private void SetQualitySettings()
        {
            string[] qualityNames = QualitySettings.names;
            _buttons = new Button[qualityNames.Length];

            // Won't Instantiate this in final build
            for (int i = 0; i < qualityNames.Length; i++)
            {
                Button b = Instantiate(_buttonPrefab, _buttonParent);
                _buttons[i] = b;
                _buttons[i].GetComponentInChildren<TextMeshProUGUI>().SetText(qualityNames[i]);
                int i1 = i;
                _buttons[i].onClick.AddListener(() => { QualitySettings.SetQualityLevel(i1, true); });
                b.transform.localPosition = yPos;
                yPos.y += 50;
            }
        }

        private void SetTargetFramerate(int newFramerate)
        {
            switch (newFramerate)
            {
                case 0:
                    Application.targetFrameRate = 60;
                    break;

                case 1:
                    Application.targetFrameRate = 75;
                    break;

                case 2:
                    Application.targetFrameRate = 120;
                    break;

                default:
                    Application.targetFrameRate = 60;
                    break;
            }
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
                Button b = Instantiate(_buttonPrefab, _buttonParent);
                yPos = new Vector3();
                yPos.x = 250;
                b.transform.localPosition = yPos;
                yPos.y += 50;

            }
            //Screen.SetResolution(width, height, (FullScreenMode)_fullScreenSetting, 60);
        }
    }
}
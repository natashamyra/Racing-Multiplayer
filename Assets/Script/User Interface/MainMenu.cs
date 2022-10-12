using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameJam.UI.Menu
{
    public class MainMenu : MonoBehaviour
    {
        public static MainMenu Instance;

        #region Buttons
        [Header("UI - Buttons Main")]
        [SerializeField] private Button _logoButton;
        [SerializeField] private Button _multiplayerButton;
        [SerializeField] private Button _practiseButton;
        [SerializeField] private Button _garageButton;
        #endregion

        #region Panels
        [Header("UI - Panels")]
        [SerializeField] private GameObject _mainPanel;
        [SerializeField] private GameObject _multiplayerPanel;
        [SerializeField] private GameObject _garagePanel;
        #endregion

         #region Multiplayer Panel
        [Header("UI - Button Multiplayer")]
        [SerializeField] private Button _multiplayerQuickStartButton;
        [SerializeField] private Button _multiplayerHostButton;
        [SerializeField] private Button _multiplayerJoinButton;
        #endregion

        #region Multiplayer Panel
        [Header("UI - Multiplayer")]
        [SerializeField] private GameObject _multiplayerLoadPanel;
        [SerializeField] private GameObject _lookForGamePanel;
        [SerializeField] private GameObject _multiplayerHostPanel;
        [SerializeField] private GameObject _multiplayerJoinPanel;
        
        #endregion

        /// <summary>
        /// Get this credit from Amyra/Amirul
        /// </summary>
        [Space(20)]
        [SerializeField] int credit = 1000;

        public enum UIMenu
        {
            None,
            Menu,
            Multiplayer,
            Practise,
            Garage,
            QuickStart,
            Host,
            Join
        }
        public UIMenu uiMenu;

        [Header("Text in Garage")]
        public TextMeshProUGUI menuText;
        public TextMeshProUGUI crText;
        public TextMeshProUGUI chosenCarText;

        // Start is called before the first frame update
        void Start()
        {
            if (Instance == null)
                Instance = this;
            else Destroy(this);

            Initialize();
        }

        private void Initialize()
        {
            _multiplayerButton.onClick.AddListener (() => Next(2));
            _practiseButton.onClick.AddListener (() => Next(3));
            _garageButton.onClick.AddListener (() => Next(4));

            _multiplayerQuickStartButton.onClick.AddListener(() => Next(5));
            _multiplayerHostButton.onClick.AddListener(() => Next(6));
            _multiplayerJoinButton.onClick.AddListener(() => Next(7));
        }


        public static void minusCredit(int value)
        {
            if (Instance.credit >= value)
            {
                Instance.credit -= value;

                Instance.UpdateCredit();
            }
            else
            {
                // Play error
            }
        }

        void UpdateCredit()
        {
            crText.SetText($"Cr. {credit}");
        }

        /// <summary>
        /// UI state controlling animation. Something to open or close. Update Menu UI
        /// </summary>
        void UIState()
        {
            _logoButton.onClick.RemoveAllListeners();
            _mainPanel.SetActive(false);

            switch (uiMenu)
            {
                case UIMenu.None:

                    break;
                case UIMenu.Menu:
                    menuText.SetText("Menu");
                    _mainPanel.SetActive(true);
                    _multiplayerPanel.SetActive(false);

                    _garagePanel.SetActive(false);
                    break;
                case UIMenu.Multiplayer:
                    menuText.SetText("Multiplayer");
                    _logoButton.onClick.AddListener(() => Next(1));
                    _multiplayerPanel.SetActive(true);

                    _multiplayerLoadPanel.SetActive(false);
                    _lookForGamePanel.SetActive(false);
                    _multiplayerHostPanel.SetActive(false);
                    _multiplayerJoinPanel.SetActive(false);
                    break;
                case UIMenu.Practise:
                    menuText.SetText("Practise");
                    _logoButton.onClick.AddListener(() => Next(1)); 

                    break;
                case UIMenu.Garage:
                    menuText.SetText("Garage");
                    _logoButton.onClick.AddListener(() => Next(1));
                    _garagePanel.SetActive(true);
                    break;
                case UIMenu.QuickStart:
                    _logoButton.onClick.AddListener(() => Next(2));

                    _multiplayerPanel.SetActive(false);
                    _multiplayerLoadPanel.SetActive(true);
                    _lookForGamePanel.SetActive(true);
                    break;
                case UIMenu.Host:
                    _logoButton.onClick.AddListener(() => Next(2));

                    _multiplayerPanel.SetActive(false);
                    _multiplayerLoadPanel.SetActive(true);
                    _multiplayerHostPanel.SetActive(true);
                    break;
                case UIMenu.Join:
                    _logoButton.onClick.AddListener(() => Next(2));
                    _multiplayerPanel.SetActive(false);
                    _multiplayerLoadPanel.SetActive(true);
                    _multiplayerJoinPanel.SetActive(true);
                    break;
            }
        }

        public void Next(int menuInt)
        {
            uiMenu = (UIMenu)menuInt;
            UIState();
        }
    }
}
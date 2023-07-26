using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameJam.UI.Menu
{
    public class MainMenu : Singleton<MainMenu>
    {
        public static MainMenu Instance;

        #region Buttons
        [Header("UI - Buttons Main")]
        [SerializeField] private Button _logoButton;
        [SerializeField] private Button _multiplayerButton;
        [SerializeField] private Button _practiseButton;
        [SerializeField] private Button _garageButton;

        [SerializeField] private Button _manageCarButton;
        [SerializeField] private Button _buyCarButton;
        [SerializeField] private Button _sellCarButton;
        [SerializeField] private Button _profileButton;
        [SerializeField] private Button _optionButton;
        #endregion

        #region Main Panels
        [Header("UI - Panels")]
        [SerializeField] private GameObject _mainPanel;
        [SerializeField] private GameObject _multiplayerPanel;
        [SerializeField] private GameObject _soloPanel;
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

        #region Garage Panel

        [Header("UI - Garage")] 
        [SerializeField] private GameObject _insideGaragePanel;
        [SerializeField] private GameObject _manageCarPanel;
        [SerializeField] private GameObject _buyCarPanel;
        [SerializeField] private GameObject _sellCarPanel;
        [SerializeField] private GameObject _profilePanel;
        [SerializeField] private GameObject _optionPanel;
        #endregion

        public enum UIMenu
        {
            None,
            Menu,
            Multiplayer,
            Solo,
            Garage,
            QuickStart,
            Host,
            Join,
        }
        public enum  UIGarage
        {
            None,
            ManageCar,
            BuyCar,
            SellCar,
            Profile,
            Option
        }
        
        [Header("UI - State")]
        public UIMenu uiMenu;
        public UIGarage uiGarage;

        [Header("Text in Garage")]
        public TextMeshProUGUI menuText;
        public TextMeshProUGUI chosenCarText;

        public void Initialize()
        {
            _multiplayerButton.onClick.AddListener (() => Next(2));
            _practiseButton.onClick.AddListener (() => Next(3));
            _garageButton.onClick.AddListener (() => Next(4));

            _multiplayerQuickStartButton.onClick.AddListener(() => Next(5));
            _multiplayerHostButton.onClick.AddListener(() => Next(6));
            _multiplayerJoinButton.onClick.AddListener(() => Next(7));
            
            _manageCarButton.onClick.AddListener(()=>NextGarage(1));
            _buyCarButton.onClick.AddListener(()=>NextGarage(2));
            _sellCarButton.onClick.AddListener(()=>NextGarage(3));
            _profileButton.onClick.AddListener(()=>NextGarage(4));
            _optionButton.onClick.AddListener(()=>NextGarage(5));
            
            Next();
            
            Debug.Log("[LOG] : Main Menu initialized");
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
                case UIMenu.Menu:
                    menuText.SetText("Menu");
                    _mainPanel.SetActive(true);
                    _multiplayerPanel.SetActive(false);
                    _soloPanel.SetActive(false);
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
                case UIMenu.Solo:
                    menuText.SetText("Solo");
                    _soloPanel.SetActive(true);
                    
                    _mainPanel.SetActive(false);
                    _logoButton.onClick.AddListener(() => Next(1));
                    break;
                case UIMenu.Garage:
                    menuText.SetText("Garage");
                    _logoButton.onClick.AddListener(() => Next(1));
                    _garagePanel.SetActive(true);
                    NextGarage();
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
                default:
                    menuText.SetText("Menu");
                    _mainPanel.SetActive(true);
                    _multiplayerPanel.SetActive(false);
                    _soloPanel.SetActive(false);
                    _garagePanel.SetActive(false);
                    break;
            }
        }

        public void Next(int menuInt = default)
        {
            uiMenu = (UIMenu)menuInt;
            UIState();
        }

        private void UIGarageSubState()
        {
            _logoButton.onClick.AddListener(() => Next(4));
            _manageCarPanel.SetActive(false);
            _buyCarPanel.SetActive(false);
            _sellCarPanel.SetActive(false);
            _profilePanel.SetActive(false);
            _optionPanel.SetActive(false);
            
            switch (uiGarage)
            {
                case UIGarage.ManageCar:
                    _insideGaragePanel.SetActive(false);
                    _manageCarPanel.SetActive(true);
                    
                    break;
                
                case UIGarage.BuyCar:
                    _insideGaragePanel.SetActive(false);
                    _buyCarPanel.SetActive(true);
                    
                    break;
                
                case UIGarage.SellCar:
                    _insideGaragePanel.SetActive(false);
                    _sellCarPanel.SetActive(true);
                    
                    break;
                
                case UIGarage.Profile:
                    _insideGaragePanel.SetActive(false);
                    _profilePanel.SetActive(true);
                    
                    break;
                
                case UIGarage.Option:
                    _insideGaragePanel.SetActive(false);
                    _optionPanel.SetActive(true);
                    
                    break;

                default:
                    menuText.SetText("Garage");
                    _logoButton.onClick.AddListener(() => Next(1));
                    _insideGaragePanel.SetActive(true);

                    break;
            }
        }
        
        public void NextGarage(int subMenuInt = default)
        {
            uiGarage = (UIGarage)subMenuInt;
            UIGarageSubState();
        }
    }
}
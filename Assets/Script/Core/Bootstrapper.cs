using System;
using System.Collections;
using System.Collections.Generic;
using GameJam.Data;
using GameJam.Mechanic;
using GameJam.UI.Menu;
using UnityEngine;

namespace GameJam.Core
{
    using Shell;
    /// <summary>
    /// Used to initialize all related script by hierarchy. Thus making any other script not using Start method.
    /// </summary>
    public class Bootstrapper : Singleton<Bootstrapper>
    {
        [SerializeField] private BootstrapperData _bootstrapperData;
        
        [Header("Core scripts")]
        [SerializeField] private MainMenu _mainMenu;
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private NetworkController _networkController;
        [SerializeField] private CarInventory _carInventory;
        [SerializeField] private Settings _settings;

        private void Awake()
        {
            if(_bootstrapperData.InitializeMainMenu) _mainMenu.Initialize();
            if(_bootstrapperData.InitializePlayerData) _playerData.Initialize();
            if(_bootstrapperData.InitializaNetworkController) _networkController.Initialize();
            if(_bootstrapperData.InitializaCarInventory) _carInventory.Initialize();
            if(_bootstrapperData.InitializeSettings) _settings.Initialized();
        }

        public MainMenu MainMenu => _mainMenu;
        public PlayerData PlayerData => _playerData;
        public NetworkController NetworkController => _networkController;
        public CarInventory CarInventory => _carInventory;
        public Settings GameSettings => _settings;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "BootstrapperData", menuName = "Game Jam/Bootstrapper", order = 1)]
public class BootstrapperData : ScriptableObject
{
    [SerializeField] private bool _initializeMainMenu;
    [SerializeField] private bool _initializePlayerData;
    [SerializeField] private bool _initializeNetworkController;

    public bool InitializeMainMenu => _initializeMainMenu;
    public bool InitializePlayerData => _initializePlayerData;
    public bool InitializaNetworkController => _initializeNetworkController;
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam.Data
{
    /// <summary>
    /// This should hold Profile, Current Car, Current Credit
    /// </summary>
    public class PlayerData : MonoBehaviour
    {
        [SerializeField] private int _currentCredit = 10000;
        [SerializeField] private PlayerProfile _playerProfile;

        #region Delegate
        public Action OnDataChanged;
        #endregion

        public void Initialize()
        {
            //! To load data to initialize
            Debug.Log("[LOG] : Player Data initialized");
        }
        
        public void AddCredit(int amount)
        {
            _currentCredit += amount;
            UpdateData();
        }
        
        public void MinusCredit(int amount)
        {
            _currentCredit -= amount;
            UpdateData();
        }
        
        private void UpdateData()
        {
            OnDataChanged?.Invoke();
        }
        
        public int CurrentCredit => _currentCredit;
    }
}
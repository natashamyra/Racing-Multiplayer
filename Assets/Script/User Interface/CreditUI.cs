using System;
using System.Collections;
using System.Collections.Generic;
using GameJam.Data;
using UnityEngine;
using TMPro;

namespace GameJam.UI
{
    using Core;

    public class CreditUI : MonoBehaviour
    {
        [SerializeField] private Bootstrapper _bootstrapper;
        
        [SerializeField] private TextMeshProUGUI[] _creditText;

        private void Start()
        {
            _bootstrapper = Bootstrapper.Instance;
            _bootstrapper.PlayerData.OnDataChanged += UpdateUIData;
        }

        private void OnDestroy()
        {
            _bootstrapper.PlayerData.OnDataChanged -= UpdateUIData;
        }

        public void AddCredit(int amount)
        {
            _bootstrapper.PlayerData.AddCredit(amount);
        }

        public void MinusCredit(int amount)
        {
            _bootstrapper.PlayerData.MinusCredit(amount);
        }

        private void UpdateUIData()
        {
            if (_creditText == null || _creditText.Length == 0) return;

            foreach (var creditText in _creditText)
            {
                creditText.SetText($"{_bootstrapper.PlayerData.CurrentCredit} Cr");
            }
        }
    }
}
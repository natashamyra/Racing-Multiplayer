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

        public int CurrentCredit => _currentCredit;

    }
}
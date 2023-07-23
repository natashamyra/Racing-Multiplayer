using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam.Data
{
    public class CarInventory : MonoBehaviour
    {
        [SerializeField] private CarScriptableObjects[] _carList;

        public void Initialize()
        {
            Debug.Log("[LOG] : Car Inventory initialized");
        }
    }
}
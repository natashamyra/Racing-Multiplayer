using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace GameJam.Clock
{
    public class SystemClock : MonoBehaviour
    {
        public TextMeshProUGUI text;

        DateTime dt;

        // Update is called once per frame
        void Update()
        {
            dt = DateTime.Now;
            text.SetText(dt.ToString("H:mm:ss tt"));
        }
    }
}
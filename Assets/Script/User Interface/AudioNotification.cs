using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.UI.ModernUIPack;

namespace GameJam.Audio
{
    public class AudioNotification : MonoBehaviour
    {
        [SerializeField] private NotificationManager _notificationManager;

        public void MusicTitle(string title, string artist)
        {
            _notificationManager.title = title;
            _notificationManager.description = artist;
            _notificationManager.UpdateUI();
            _notificationManager.OpenNotification();
        }
    }
}

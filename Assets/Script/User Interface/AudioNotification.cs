using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.UI.ModernUIPack;

namespace GameJam.Audio
{
    public class AudioNotification : MonoBehaviour
    {
        public AudioSource source;
        public NotificationManager notificationManager;

        // Start is called before the first frame update
        IEnumerator Start()
        {
            yield return new WaitForSeconds(5f);

            if (source.isPlaying)
            {
                Debug.Log(source.clip.name);
                notificationManager.title = "Budak flat";
                notificationManager.description = "Aman Ra";
                notificationManager.UpdateUI();
                notificationManager.OpenNotification();
            }
        }
    }
} 
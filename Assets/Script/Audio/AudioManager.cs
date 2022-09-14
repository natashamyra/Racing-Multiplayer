using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam.Audio
{
    public class AudioManager : Singleton<AudioManager>
    {
        [SerializeField] AudioSource _audioSource;
        [SerializeField] AudioPlaylist _audioPlaylist;
        [SerializeField] AudioNotification _audioNotification;

        [SerializeField] string musicArtist;
        [SerializeField] string musicTitle;

        //! TODO: Audio Manager play the music and slowly fades when load screen comes up
        //! TODO: Auto change music when music finish

        
        IEnumerator Start()
        {
            yield return new WaitForSeconds(5f);

            if (_audioSource.isPlaying)
            {
                GetMusicName(_audioSource.name);
            } 
        }

        private void GetMusicName(string music)
        {
            string[] result = music.Split('-');
            musicArtist = result[0];
            musicTitle = result[1];

            _audioNotification.MusicTitle(musicTitle, musicArtist);
        }

        private void GetNextMusic()
        {
            
        }
    }
}
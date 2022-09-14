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
        
        IEnumerator Start()
        {
            _audioSource.Play();
            yield return new WaitForSeconds(5f);

            if (_audioSource.isPlaying)
            {
                GetMusicName(_audioSource.clip.name);
            }
            yield return GetNextMusic();
        }

        private void GetMusicName(string music)
        {
            string[] result = music.Split('-');
            musicArtist = result[0];
            musicTitle = result[1];

            _audioNotification.MusicTitle(musicTitle, musicArtist);
        }

        private IEnumerator GetNextMusic()
        {
            yield return new WaitUntil(() => !_audioSource.isPlaying);
            int randomMusic = Random.Range(0, _audioPlaylist.MusicClips.Count - 1);
            _audioSource.clip = _audioPlaylist.MusicClips[randomMusic];
            _audioSource.Play();
            yield return GetNextMusic();
        }
    }
}
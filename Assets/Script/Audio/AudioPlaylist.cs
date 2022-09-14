using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam.Audio
{
    /// <summary>
    /// This only hold music playlist
    /// </summary>
    public class AudioPlaylist : MonoBehaviour
    {
        [SerializeField] List<AudioClip> _musicClips;

        public List<AudioClip> MusicClips => _musicClips;
    }
}
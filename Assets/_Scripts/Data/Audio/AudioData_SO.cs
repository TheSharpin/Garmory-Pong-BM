using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.Data.Audio
{
    [CreateAssetMenu(fileName = "Audio Data", menuName = "Data/Create Audio Data", order = 0)]
    public class AudioData_SO : ScriptableObject
    {
        public AudioClip UIClickClip;
        public AudioClip UISelectionClip;
        public AudioClip UIToggleClip;
    }
}

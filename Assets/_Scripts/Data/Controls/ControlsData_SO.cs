using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.Data.Controls
{
    [CreateAssetMenu(fileName ="Controls Database", menuName = "Create Controls Database", order = 0)]
    public class ControlsData_SO : ScriptableObject
    {
        [SerializeField] float screenMinYDistance;
        [SerializeField] float screenMaxYDistance;

        [Header("Ball")]
        [SerializeField] AudioClip[] ballSounds = default;
        [SerializeField] AudioClip loseLifeClip = default;
        [Range(0f,1f)]
        [SerializeField] float ballRandomFactor = 0.2f;

        public float ScreenMinYDistance => screenMinYDistance;
        public float ScreenMaxYDistance => screenMaxYDistance;
        public AudioClip[] BallSounds => ballSounds;
        public AudioClip LoseLifeClip => loseLifeClip;
        public float BallRandomFactor => ballRandomFactor;


    }
}

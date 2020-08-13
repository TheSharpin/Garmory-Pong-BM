using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Pong.Data.Core
{
    [CreateAssetMenu(fileName ="Player Difficulty", menuName ="Create Player Difficulty", order = 1)]
    public class DifficultyLevel_SO : ScriptableObject
    {
        [Header("Player")]
        [SerializeField] private int startingLives;

        [Header("Ball")] [Tooltip("Ball's speed")]
        [SerializeField] private Vector2 ballPushVector;
        [SerializeField] private float ballSize;
        [SerializeField] private float ballSpeed;
        [SerializeField] private float ballHitIncrementValue;
        [SerializeField] private bool autoPlay;

        public int StartingLives => startingLives;
        public float BallHitIncrementValue => ballHitIncrementValue;
        public float BallSize => ballSize;
        public float BallSpeed => ballSpeed;
        public Vector2 BallPushVector => ballPushVector;
        public bool AutoPlay => autoPlay;
    }
}
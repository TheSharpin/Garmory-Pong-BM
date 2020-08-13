using Pong.Data.Controls;
using Pong.Data.Core;
using Pong.Logic.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.Logic.Mechanics
{
    public class Ball : MonoBehaviour, IPausable
    {
        [SerializeField] ControlsData_SO controlsDatabase;
        [SerializeField] DifficultyLevel_SO difficultyLevel;

        //config params
        [SerializeField] Paddle paddle = default;

        //state
        private Vector2 paddleToBallVector;
        private Vector2 lastVeliocity;
        private bool hasStarted = false;

        //Cached component references
        private AudioSource audoSource;
        private Rigidbody2D rBody2D;

        private void Awake()
        {
            audoSource = GetComponent<AudioSource>();
            rBody2D = GetComponent<Rigidbody2D>();

            transform.localScale = new Vector2(difficultyLevel.BallSize, difficultyLevel.BallSize);
        }
        private void OnEnable()
        {
            GameManager.Instance.onSessionRestart += ResetPosition;
            paddle.BallYPosition = () => transform.position.y;
        }
        private void OnDisable()
        {
            if (GameManager.Instance)
            {
                GameManager.Instance.onSessionRestart -= ResetPosition;
            }

            paddle.BallYPosition -= () => transform.position.y;
        }

        void Start()
        {
            paddleToBallVector = transform.position - paddle.transform.position;
        }

        void Update()
        {
            if(GameManager.Instance.GameMode == GameModeEnum.GameOver)
            {
                LockBallToPaddle();
                return;
            }
            if (!hasStarted && GameManager.Instance.GameMode == GameModeEnum.Play)
            {
                LockBallToPaddle();
                LaunchOnClick();
            }
        }

        public void ResetPosition()
        {
            hasStarted = false;
        }

        private void LaunchOnClick()
        {
            if (Input.GetButton("Launch") && hasStarted == false)
            {
                hasStarted = true;
                rBody2D.velocity = difficultyLevel.BallPushVector;
            }
        }

        private void LockBallToPaddle()
        {
            Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
            transform.position = paddlePos + (paddleToBallVector*Mathf.Max(1,transform.localScale.x/2));
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Vector2 velocityTweak = new Vector2
                (UnityEngine.Random.Range(-controlsDatabase.BallRandomFactor, controlsDatabase.BallRandomFactor),
                UnityEngine.Random.Range(-controlsDatabase.BallRandomFactor, controlsDatabase.BallRandomFactor));

            if (hasStarted)        
                rBody2D.velocity += velocityTweak;

            switch(collision.gameObject.tag)
            {
                case "Paddle":
                    GameManager.Instance.IncrementScore();
                    PlayRandomHitClip();
                    rBody2D.velocity += rBody2D.velocity * difficultyLevel.BallHitIncrementValue;
                    break;

                case "Lives Decrement":
                    ResetPosition();
                    GameManager.Instance.DecrementLives();
                    audoSource.PlayOneShot(controlsDatabase.LoseLifeClip);
                    break;

                default:
                    PlayRandomHitClip();
                    rBody2D.velocity += rBody2D.velocity * difficultyLevel.BallHitIncrementValue;
                    break;
            }
        }

        private void PlayRandomHitClip()
        {
            AudioClip clip = controlsDatabase.BallSounds[UnityEngine.Random.Range(0, controlsDatabase.BallSounds.Length - 1)];
            audoSource.PlayOneShot(clip);
        }

        public void Pause()
        {
            lastVeliocity = rBody2D.velocity;
            rBody2D.velocity = Vector2.zero;
        }

        public void Resume()
        {
            rBody2D.velocity = lastVeliocity;
        }
    }
}

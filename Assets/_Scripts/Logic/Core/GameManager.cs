using Pong.Data.Core;
using Pong.Logic.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Pong.Logic.Core
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] DifficultyLevel_SO difficultyLevel;

        private PlayerData_SO playerData;
        private GameModeEnum gameMode = GameModeEnum.Menu;

        #region Properties
        public bool AutoPlay => difficultyLevel.AutoPlay;
        public bool NewHighScore => playerData.score > playerData.highscore;
        public int Lives => playerData.lives;
        public int Score => playerData.score;
        public int Highscore => playerData.highscore;
        public float SessionTimer => playerData.sessionTime;

        public GameModeEnum GameMode
        {
            private set
            {
                gameMode = value;
                onGameModeChanged?.Invoke(gameMode);
            }
            get => gameMode;
        }
        #endregion

        public event Action onScoreChanged;
        public event Action onLivesChanged;
        public event Action onSessionRestart;
        public event Action<GameModeEnum> onGameModeChanged;

        protected override void Awake()
        {
            base.Awake();

            playerData = new PlayerData_SO();
            playerData.lives = difficultyLevel.StartingLives;
            playerData.score = 0;
        }

        private void Start()
        {
            GameMode = GameModeEnum.Menu;

            onScoreChanged?.Invoke();
            onLivesChanged?.Invoke();
        }
        private void Update()
        {
            if (GameMode == GameModeEnum.Play)
                playerData.sessionTime += Time.deltaTime;
        }

        #region Game Mode
        public void StartSession()
        {
            Cursor.visible = false;

            playerData.lives = 3;
            playerData.score = 0;
            playerData.sessionTime = 0;
            playerData.highscore = PlayerPrefs.GetInt("Highscore");

            GameMode = GameModeEnum.Play;

            onLivesChanged?.Invoke();
            onScoreChanged?.Invoke();
        }

        public void RestartSession()
        {
            StartSession();
            onSessionRestart?.Invoke();
        }

        public void ExitSession()
        {
            Cursor.visible = true;

            PlayerPrefs.SetInt("Highscore", playerData.highscore);

            GameMode = GameModeEnum.Menu;
        }

        public void PauseGame()
        {
            var pausables = FindObjectsOfType<MonoBehaviour>().OfType<IPausable>();
            foreach (var pausable in pausables)
            {
                pausable.Pause();
            }

            GameMode = GameModeEnum.Pause;
        }

        public void ResumeGame()
        {
            var pausables = FindObjectsOfType<MonoBehaviour>().OfType<IPausable>();
            foreach (var pausable in pausables)
            {
                pausable.Resume();
            }

            GameMode = GameModeEnum.Play;
        }
        #endregion

        #region Player Data
        public void IncrementScore()
        {
            playerData.score++;

            if (NewHighScore)
                playerData.highscore = Score;

            onScoreChanged?.Invoke();
        }

        public void DecrementLives()
        {
            playerData.lives--;
            onLivesChanged?.Invoke();

            if (playerData.lives <= 0)
            {
                playerData.lives = 0;
                onLivesChanged?.Invoke();

                GameMode = GameModeEnum.GameOver;
            }
        }
        #endregion
    }

    public enum GameModeEnum
    {
        Menu,
        Play,
        GameOver,
        Pause
    }
}

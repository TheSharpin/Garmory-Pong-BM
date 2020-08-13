using Pong.Logic.Audio;
using Pong.Logic.Core;
using Pong.Logic.Mechanics;
using Pong.Logic.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Pong.UI.HUD
{
    public class GameCanvasController : CanvasController
    {
        [Header("Top Info")]
        [SerializeField] TextMeshProUGUI livesCount;
        [SerializeField] TextMeshProUGUI currentScoreCount;
        [SerializeField] TextMeshProUGUI timerCount;

        [Header("Pause Menu")]
        [SerializeField] GameObject pauseMenu;

        [Header("Game Over Session Window")]
        [SerializeField] GameObject gameOverWindow;
        [SerializeField] GameObject newHighscore;
        [SerializeField] TextMeshProUGUI sessionScoreCount;
        [SerializeField] TextMeshProUGUI highScore;
        [SerializeField] TextMeshProUGUI sessionTimeCount;

        private void OnEnable()
        {
            GameManager.Instance.onScoreChanged += UpdateCurrentScore;
            GameManager.Instance.onLivesChanged += UpdateCurrentLives;
            GameManager.Instance.onGameModeChanged += GameModeChangedHandler;

            UpdateCurrentLives();
            UpdateCurrentScore();
        }

        private void OnDisable()
        {
            if (GameManager.Instance)
            {
                GameManager.Instance.onScoreChanged -= UpdateCurrentScore;
                GameManager.Instance.onLivesChanged -= UpdateCurrentLives;
                GameManager.Instance.onGameModeChanged -= GameModeChangedHandler;
            }
        }

        private void Update()
        {
            if (Input.GetButtonDown("Open Menu") && GameManager.Instance.GameMode == GameModeEnum.Play)
            {
                pauseMenu.SetActive(!gameOverWindow.activeSelf);

                if (pauseMenu.activeSelf)
                {
                    // Pause Game
                    GameManager.Instance.PauseGame();
                    Cursor.visible = true;
                }
                else
                {
                    // Resume Game
                    GameManager.Instance.ResumeGame();
                    Cursor.visible = false;
                }
            }
        }

        private void UpdateCurrentScore()
        {
            currentScoreCount.text = GameManager.Instance.Score.ToString();
        }
        private void UpdateCurrentLives()
        {
            livesCount.text = GameManager.Instance.Lives.ToString();
        }

        private void GameModeChangedHandler(GameModeEnum gameMode)
        {
            if(gameMode == GameModeEnum.GameOver)
            {
                Cursor.visible = true;

                gameOverWindow.SetActive(true);
                newHighscore.SetActive(GameManager.Instance.NewHighScore);

                sessionScoreCount.text = GameManager.Instance.Score.ToString();
                highScore.text = GameManager.Instance.Highscore.ToString();
                sessionTimeCount.text = timerCount.text;
            }
        }

        #region Buttons
        public void Button_MainMenu()
        {
            AudioManager.Instance.PlayUISFX(UISFXEnum.Click);

            pauseMenu.SetActive(false);
            gameOverWindow.SetActive(false);
            newHighscore.SetActive(false);

            SceneLoader.Instance.LoadMainMenu();
        }
        public void Button_Restart()
        {
            AudioManager.Instance.PlayUISFX(UISFXEnum.Click);

            GameManager.Instance.RestartSession();

            pauseMenu.SetActive(false);
            gameOverWindow.SetActive(false);
            newHighscore.SetActive(false);
        }
        public void Button_Resume()
        {
            AudioManager.Instance.PlayUISFX(UISFXEnum.Click);

            pauseMenu.SetActive(false);
            GameManager.Instance.ResumeGame();
        }
        #endregion
    }
}

using Pong.Data.SceneManagement;
using Pong.Logic.Core;
using Pong.Logic.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pong.Logic.SceneManagement
{
    public class SceneLoader : Singleton<SceneLoader>
    {
        [SerializeField] SceneManagementData_SO data;

        internal void LoadNextScene()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }

        internal void LoadSession()
        {
            SceneManager.LoadScene(data.sessionIndex);
            GameManager.Instance.StartSession();
        }

        //Use coroutines
        internal void LoadMainMenu()
        {
            SceneManager.LoadScene(data.mainMenuIndex);
            GameManager.Instance.ExitSession();
        }

        internal void QuitGame()
        {
            Application.Quit();
        }
    }
}

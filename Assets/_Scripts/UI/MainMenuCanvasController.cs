using Pong.Logic.Audio;
using Pong.Logic.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pong.UI
{
    public class MainMenuCanvasController : CanvasController
    {
        [SerializeField] Button buttons;

        public void Button_NewGame()
        {
            AudioManager.Instance.PlayUISFX(UISFXEnum.Click);
            SceneLoader.Instance.LoadSession();
        }

        public void Button_ExitGame()
        {
            AudioManager.Instance.PlayUISFX(UISFXEnum.Click);
            SceneLoader.Instance.QuitGame();
        }
    }
}

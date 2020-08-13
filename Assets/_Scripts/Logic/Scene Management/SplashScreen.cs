using Pong.Logic.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.Logic.SceneManagement
{
    public class SplashScreen : MonoBehaviour
    {
        [SerializeField] Color fadingColor = Color.black;

        IEnumerator Start()
        {
            yield return null;

            if (SceneLoader.Instance != null)
            {
                SceneLoader.Instance.LoadNextScene();
            }
            else
                FindObjectOfType<SceneLoader>().LoadNextScene();
        }
    }
}

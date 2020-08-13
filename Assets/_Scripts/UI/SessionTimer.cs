using Pong.Logic.Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Pong.UI
{
    public class SessionTimer : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI timer;

        string seconds;
        string minutes;

        private void Update()
        {
            minutes = Mathf.Floor(GameManager.Instance.SessionTimer / 60).ToString("00");
            seconds = Mathf.Min(59, GameManager.Instance.SessionTimer % 60).ToString("00");
            timer.text = string.Format("{0}:{1}", minutes, seconds);
        }
    }
}

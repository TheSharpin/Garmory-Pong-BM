using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.Data.SceneManagement
{
    [CreateAssetMenu(fileName = "Scene Management Data", menuName = "Data/Create Scene Management Data", order = 0)]
    public class SceneManagementData_SO : ScriptableObject
    {
        public int mainMenuIndex;
        public int sessionIndex;
        public float fadeInTransitionTime;
        public float fadeOutTransitionTime;
        public Color defaultFadeColor;
    }
}

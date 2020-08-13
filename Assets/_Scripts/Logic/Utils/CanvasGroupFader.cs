using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.Logic.Utils
{
    [RequireComponent(typeof(CanvasGroup))]
    public class CanvasGroupFader : MonoBehaviour
    {
        CanvasGroup canvasGroup;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public IEnumerator FadeOut(float time)
        {
            if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();

            if (time <= 0)
            {
                canvasGroup.alpha = 1;
                yield break;
            }

            while (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += Time.deltaTime / time;
                yield return null;
            }
        }

        public IEnumerator FadeIn(float time)
        {
            if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();

            if (time <= 0)
            {
                canvasGroup.alpha = 0;
                yield break;
            }

            while (canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= Time.deltaTime / time;
                yield return null;
            }
        }

        public void FadeInVoid(float time)
        {
            StartCoroutine(FadeIn(time));
        }

        public void FadeOutVoid(float time)
        {
            StartCoroutine(FadeOut(time));
        }
    }
}

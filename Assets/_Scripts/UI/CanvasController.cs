using Pong.Logic.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.UI
{
    public abstract class CanvasController : MonoBehaviour
    {
        public void Toggle_Music(bool isOn)
        {
            AudioManager.Instance.PlayUISFX(UISFXEnum.Toggle);
            AudioManager.Instance.SetMusic(!isOn);
        }

        public void Toggle_Sounds(bool isOn)
        {
            AudioManager.Instance.PlayUISFX(UISFXEnum.Toggle);

            if (!isOn)
                AudioManager.Instance.SetSounds(true);
            else
            {
                StopAllCoroutines();
                StartCoroutine(DelayedSoundsSet(UISFXEnum.Toggle));
            }
        }

        public void PlaySelectionAudio()
        {
            AudioManager.Instance.PlayUISFX(UISFXEnum.Selection);
        }

        private IEnumerator DelayedSoundsSet(UISFXEnum Type)
        {
            yield return new WaitForSeconds(AudioManager.Instance.GetUISFXLength(Type));
            AudioManager.Instance.SetSounds(false);
        }
    }
}

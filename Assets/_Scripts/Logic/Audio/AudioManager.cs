using Pong.Data.Audio;
using Pong.Logic.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Pong.Logic.Audio
{
    public class AudioManager : Singleton<AudioManager>
    {
        [SerializeField] AudioMixer mixer;
        [SerializeField] AudioData_SO data;

        [SerializeField] AudioSource soundsSource;

        internal void SetMusic(bool set)
        {
            mixer.SetFloat("Music", set ? -80 : 0);
        }

        internal void SetSounds(bool set)
        {
            mixer.SetFloat("Sounds", set ? -80 : 0);
        }

        internal void PlayUISFX(UISFXEnum type)
        {
            AudioClip clip = data.UIClickClip;
            switch (type)
            {
                case UISFXEnum.Click: clip = data.UIClickClip; break;
                case UISFXEnum.Selection: clip = data.UISelectionClip; break;
                case UISFXEnum.Toggle: clip = data.UIToggleClip; break;
            }

            soundsSource.PlayOneShot(clip);
        }

        internal float GetUISFXLength(UISFXEnum type)
        {
            float length = 0f;
            switch (type)
            {
                case UISFXEnum.Click: length = data.UIClickClip.length; break;
                case UISFXEnum.Selection: length = data.UISelectionClip.length; break;
                case UISFXEnum.Toggle: length = data.UIToggleClip.length; break;
            }

            return length;
        }
    }

    internal enum UISFXEnum
    {
        Selection,
        Click,
        Toggle
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.Logic.Utils
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T _instance;
        public static T Instance
        {
            get { return _instance; }
            set
            {
                if (null == _instance)
                {
                    _instance = value;
                    DontDestroyOnLoad(_instance.gameObject);
                }
                else if (_instance != value)
                {
                    Destroy(value.gameObject);
                }
            }
        }


        protected virtual void Awake()
        {
            Instance = this as T;
        }

        protected virtual void OnDestroy()
        {
            if (_instance == this)
            {
                _instance = null;
            }
        }
    }
}

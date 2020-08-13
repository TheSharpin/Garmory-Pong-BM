using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 namespace Pong.Logic.Core
{
    public interface IPausable
    {
        void Pause();
        void Resume();
    }
}
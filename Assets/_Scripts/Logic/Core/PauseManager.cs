using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.Logic.Core
{
    public class PauseManager
    {
        public void PauseGame(IPausable[] pausables)
        {
            
        }

        public void ResumeGame(IPausable[] pausables)
        {
            for (int i = 0; i < pausables.Length; i++)
            {
                pausables[i].Resume();
            }
        }
    }
}

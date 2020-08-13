using Pong.Data.Controls;
using Pong.Data.Core;
using Pong.Logic.Delegates;
using Pong.Logic.Core;
using UnityEngine;

namespace Pong.Logic.Mechanics
{
    public class Paddle : MonoBehaviour
    {
        [SerializeField] ControlsData_SO controlsDatabase;
        [SerializeField] DifficultyLevel_SO difficultyLevel;

        // To avoid ciclic dependency use delegate instead of ball reference
        public FloatDelegate BallYPosition;

        private float mousePosInUnits;

        void Update()
        {
            if(GameManager.Instance.GameMode == GameModeEnum.Play)
                transform.position = new Vector2(transform.position.x, Mathf.Clamp(GetYPos(), controlsDatabase.ScreenMinYDistance, controlsDatabase.ScreenMaxYDistance));
        }

        private float GetYPos()
        {
            if (GameManager.Instance.AutoPlay && BallYPosition != null)
            {
                return BallYPosition.Invoke();
            }
            else
            {
                mousePosInUnits = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
                return mousePosInUnits;
            }
        }
    }
}

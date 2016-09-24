using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script
{
    public class GameController : MonoBehaviour
    {
        public static bool Playing = false;

        public Text Message;

        private bool _gameOver;
	
        void Awake()
        {
            SetStartMessage();
            _gameOver = false;
        }

        void Update()
        {
            if(!Playing)
            {
                Time.timeScale = 0;
                Click();
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        public void Click()
        {
            if(Input.GetMouseButton(0))
            {
                HideMessage();

                if (_gameOver)
                    ResetGame();
                else
                    Playing = true;
            }
        }

        public void GameOver()
        {
            Playing = false;
            _gameOver = true;
            SetGameOverMessage();
        }

        void ResetGame()
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        void SetStartMessage()
        {
            Message.text = "Tap the screen to start!";
        }

        public void SetGameOverMessage()
        {
            Message.text = "Tap the screen to restart!";
        }

        void HideMessage()
        {
            Message.text = "";
        }
    }
}
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script
{
    public class PlayerController : MonoBehaviour
    {
        public float Movespeed = 3f;

        public Transform CamTransform;
        public Text ScoreText;

        private GameController _gameController;
        private EnemyController _enemyController;

        private int _score;
    
        void Start ()
        {
            _gameController = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<GameController>();
            _enemyController = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<EnemyController>();

            _score = 0;
        }

        void FixedUpdate()
        {
            Vector3 forward = new Vector3(CamTransform.forward.x, 0f, CamTransform.forward.z);
            transform.position += Movespeed * forward * Time.deltaTime;
        }

        void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag(Tags.Pellet))
            {
                Destroy(other.gameObject);
                IncreaseScore(1);
            }
            else if(other.tag.Equals(Tags.PowerUp))
            {
                Destroy(other.gameObject);
                Pulse.PowerUp();
                IncreaseScore(5);
            }
        }

        void OnCollisionEnter(Collision other)
        {
            if(other.gameObject.CompareTag(Tags.Enemy))
            {
                if (Pulse.GetPowered())
                {
                    _enemyController.DestroyEnemy(other.gameObject);
                    IncreaseScore(10);
                }
                else
                {
                    _gameController.GameOver();
                }
            }
        }

        void IncreaseScore(int value)
        {
            _score += value;
            ScoreText.text = "Score: " + _score;
        }
    }
}
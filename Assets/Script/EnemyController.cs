using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{
    public class EnemyController : MonoBehaviour
    {
        private const int NumOfEnemies = 4;
        private const float DoorUpY = 1.5f;
        private const float DoorDownY = 0.5f;

        public List<Transform> Spawns;
        public GameObject Enemy;
        public Transform Door;
        public float DoorTime = 1f;

        private List<GameObject> _enemies;
        private int _spawnPos;
        private int _enemyIndex;
        private bool _playing;

        void Awake()
        {
            _enemies = new List<GameObject>();

            for(int i = 0; i < NumOfEnemies; i++)
            {
                CreateEnemy();
            }

            _spawnPos = 0;
            _enemyIndex = 0;
            _playing = true;

            StartCoroutine(RepeatDoor());
        }

        IEnumerator RepeatDoor()
        {
            while (_playing)
            {
                yield return new WaitForSeconds(1f);
                OpenDoor();
                yield return new WaitForSeconds(1f);
                CloseDoor();
                yield return new WaitForSeconds(3f);
            }
        }

        void OpenDoor()
        {
            EnemyMovement currEnemy = _enemies[_enemyIndex].GetComponent<EnemyMovement>();
            currEnemy.SetDoorOpen(true);

            Vector3 doorUp = new Vector3(Door.position.x, DoorUpY*2, Door.position.z);
            Door.position = doorUp;

            _enemyIndex++;
            if(_enemyIndex >= _enemies.Count)
            {
                _enemyIndex = 0;
            }
        }

        void CloseDoor()
        {
            Vector3 doorDown = new Vector3(Door.position.x, DoorDownY*2, Door.position.z);
            Door.position = doorDown;
        }

        public void DestroyEnemy(GameObject enemy)
        {
            _enemies.Remove(enemy);
            Destroy(enemy.gameObject);
            CreateEnemy();
        }

        void CreateEnemy()
        {
            if (_enemies.Count < NumOfEnemies)
            {
                GameObject enemy = Instantiate(Enemy);
                _enemies.Add(enemy);
                enemy.transform.position = Spawns[_spawnPos++].position;
                if (_spawnPos >= Spawns.Count)
                    _spawnPos = 0;
            }
        }
    }
}
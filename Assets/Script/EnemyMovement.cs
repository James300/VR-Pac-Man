using UnityEngine;

namespace Assets.Script
{
    public class EnemyMovement : MonoBehaviour
    {
        public EnemyController EnemyController;

        private Transform _player;
        private NavMeshAgent _navMesh;

        private bool _doorOpen;

        void Awake()
        {
            _player = GameObject.FindGameObjectWithTag(Tags.Player).transform;
            _navMesh = GetComponent<NavMeshAgent>();

            _doorOpen = false;
        }

        void Update()
        {
            if (_doorOpen)
            {
                _navMesh.SetDestination(_player.position);
            }
        }

        public void SetDoorOpen(bool val)
        {
            _doorOpen = val;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Polar.Player;

namespace Polar.Core
{
    public class Checkpoint : MonoBehaviour
    {
        private CheckpointManager _checkpointManager;
        private Health _playerHealth;

        private void Awake()
        {
            _checkpointManager = GetComponentInParent<CheckpointManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _checkpointManager.CheckpointHit(this);

                if(_playerHealth == null)
                {
                    _playerHealth = other.GetComponent<Health>();
                }
                
                _playerHealth.SetNewCheckpoint(this.transform);
            }
        }

        public void SetActiveCheckpoint(Material _material)
        {
            GetComponent<MeshRenderer>().material = _material;
        }

        public void UnsetCheckpoint(Material _material)
        {
            GetComponent<MeshRenderer>().material = _material;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Polar.Core
{
    public class CheckpointManager : MonoBehaviour
    {
        [SerializeField] Material nonActiveCheckpointMaterial;
        [SerializeField] Material activeCheckpointMaterial;

        private Checkpoint[] _checkpoints;

        private void Awake()
        {
            _checkpoints = GetComponentsInChildren<Checkpoint>();
        }

        public void CheckpointHit(Checkpoint _checkpoint)
        {
            foreach(Checkpoint checkpoint in _checkpoints)
            {
                checkpoint.UnsetCheckpoint(nonActiveCheckpointMaterial);
            }

            _checkpoint.SetActiveCheckpoint(activeCheckpointMaterial);
        }
    }
}

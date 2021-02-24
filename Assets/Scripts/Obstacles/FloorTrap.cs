using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Polar.Obstacles
{
    public class FloorTrap : MonoBehaviour
    {
        [SerializeField] float resetDelayTimer = 1f;
        [SerializeField] float triggerWaitTime = 1f;

        private Animator _animator;

        private bool hasTriggered = false;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!hasTriggered && other.CompareTag("Player"))
            {
                StartCoroutine("WaitToTrigger");
            }
        }

        private IEnumerator WaitToTrigger()
        {
            yield return new WaitForSeconds(triggerWaitTime);
            StartCoroutine("TriggerTrap");
        }

        private IEnumerator TriggerTrap()
        {
            hasTriggered = true;
            _animator.SetTrigger("Trap");
            yield return new WaitForSeconds(resetDelayTimer);
            hasTriggered = false;
        }
    }
}

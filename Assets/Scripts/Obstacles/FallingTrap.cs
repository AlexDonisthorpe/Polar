using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Polar.Obstacles
{
    public class FallingTrap : MonoBehaviour
    {
        [SerializeField] float fallDelay = 2f;
        [SerializeField] float disappearDelay = 2f;

        [SerializeField] bool doesRespawn = false;
        [SerializeField] float respawnDelay = 4f;

        [SerializeField] GameObject debris;

        private GameObject _spawnedDebris;
        private bool isReadyToSpawn = true;


        private void OnTriggerEnter(Collider other)
        {
            if(_spawnedDebris == null && isReadyToSpawn)
            {
                if (other.CompareTag("Player"))
                {
                    isReadyToSpawn = false;
                    StartCoroutine("TriggerTrap");
                }
            }

            if(doesRespawn)
            {
                StartCoroutine("Respawn");
            }
            
        }

        private IEnumerator TriggerTrap()
        {
            yield return new WaitForSeconds(fallDelay);
            _spawnedDebris = Instantiate(debris, transform.position, Quaternion.identity);
        }

        private IEnumerator CleanupDebris()
        {
            yield return new WaitForSeconds(disappearDelay);
            _spawnedDebris.GetComponent<DamageObject>().Cleanup();
        }

        private IEnumerator Respawn()
        {
            yield return new WaitForSeconds(respawnDelay);
            isReadyToSpawn = true;
        }
    }
}

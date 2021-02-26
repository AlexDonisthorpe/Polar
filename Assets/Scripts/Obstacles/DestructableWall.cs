using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Polar.Obstacles
{
    public class DestructableWall : MonoBehaviour
    {
        private CrashCrate[] _boxes;

        [SerializeField] float boxExplosionForce = 500f;

        private void Awake()
        {
            _boxes = GetComponentsInChildren<CrashCrate>();
        }

        private void OnTriggerEnter(Collider other)
        {

           if (other.CompareTag("Player"))
           {
                foreach (var box in _boxes)
                {
                    box.BlowUp(boxExplosionForce);
                }

                GetComponent<BoxCollider>().enabled = false;
                GetComponentInParent<BoxCollider>().enabled = false;
            }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Polar.Obstacles
{
    public class DestructableWall : MonoBehaviour
    {
        private CrashCrate[] _boxes;

        [SerializeField] float boxExplosionForce = 500f;

        // For some reason getComponentInParent isn't finding the parent object
        // No time to debug :(
        [SerializeField] GameObject parent;

        private void Awake()
        {
            _boxes = GetComponentsInChildren<CrashCrate>();
        }

        private void OnTriggerEnter(Collider other)
        {

           if (other.CompareTag("Player"))
           {    AkSoundEngine.PostEvent("Destroy", this.gameObject);
                foreach (var box in _boxes)
                {
                    box.BlowUp(boxExplosionForce);
                }

                GetComponent<BoxCollider>().enabled = false;
                parent.GetComponent<BoxCollider>().enabled = false;
            }

        }
    }
}

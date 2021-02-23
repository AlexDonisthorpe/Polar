using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Polar.Player;

namespace Polar.Obstacles
{
    public class DamageObject : MonoBehaviour
    {
        private void DamagePlayer(GameObject player)
        {
            player.GetComponent<Health>().DealDamage();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                DamagePlayer(other.gameObject);
            }
        }

    }
}


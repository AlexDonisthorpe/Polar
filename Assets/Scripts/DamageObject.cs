using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    private void DamagePlayer(GameObject player)
    {
        //Health doesn't exist yet!
        //player.GetComponent<Health>();

        //Debug for now
        Debug.Log("Player has hit the deathzone");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            
            DamagePlayer(other.gameObject);
        }
    }

}

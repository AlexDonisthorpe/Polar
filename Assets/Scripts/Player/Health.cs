using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Polar.UI;

namespace Polar.Player
{
    public class Health : MonoBehaviour
    {
        [SerializeField] int playerLives = 3;

        private Vector3 _respawnPosition;
        private Quaternion _respawnRotation;

        private void Start()
        {
            SetNewCheckpoint(transform);
        }

        public void DealDamage()
        {
            //Put Dying Stuff here
            //May need to pull this out into another method later
            playerLives--;

            if(playerLives <= 0)
            {  
                GameOver();
                
                

            }
            else
            {
                Respawn();
                
            }
        }

        private void Respawn()
        {
            transform.position = _respawnPosition;
            transform.rotation = _respawnRotation;
        }

        public void SetNewCheckpoint(Transform checkpointTransform)
        {
            Vector3 newPosition = new Vector3(checkpointTransform.position.x, checkpointTransform.position.y + 2, checkpointTransform.position.z);

            _respawnPosition = newPosition;
            _respawnRotation = checkpointTransform.rotation;
        }

        private void GameOver()
        {
            AkSoundEngine.PostEvent("DEAD", gameObject);
            // Add game over logic here - probably want to make a level controller to handle the gameover/timer stuff
            FindObjectOfType<LevelController>().LoadGameOverCanvas();
        }
    }
}

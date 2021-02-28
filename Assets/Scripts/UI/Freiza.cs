using UnityEngine;

namespace Polar.UI
{
    public class Freiza : MonoBehaviour
    {
        private bool nextLevelExists = true;
        [SerializeField] GameObject nextLevelButton;

        private void Start()
        {
            nextLevelExists = FindObjectOfType<LevelController>().DoesNextLevelExist();
        }

        // Yes, you read that right.
        public void Freeze()
        {
            if(nextLevelExists)
            {
                nextLevelButton.SetActive(true);
            }
            else
            {
                nextLevelButton.SetActive(false);
            }
            Time.timeScale = 0;
        }
    }
}



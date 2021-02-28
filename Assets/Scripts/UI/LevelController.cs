using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Polar.UI
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] Button nextLevelButton;
        [SerializeField] Button menuButton;
        [SerializeField] GameObject youWinCanvas;

        private Animator _animator;
        int currentSceneIndex;

        private void Awake()
        {
            _animator = youWinCanvas.GetComponent<Animator>();
        }

        private void Start()
        {
            int totalScenes = SceneManager.sceneCountInBuildSettings;
            currentSceneIndex = SceneManager.GetActiveScene().buildIndex;


            if (currentSceneIndex == totalScenes-1)
            {
                nextLevelButton.gameObject.SetActive(false);
            }

        }

        public void LoadNextLevel()
        {
            Time.timeScale = 1;
            var nextLevelIndex = currentSceneIndex + 1;
            SceneManager.LoadScene(nextLevelIndex);
        }

        public void ReturnToMenu()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }

        public void LoadYouWinCanvas()
        {
            youWinCanvas.SetActive(true);
        }

    }
}

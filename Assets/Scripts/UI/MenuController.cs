using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Polar.UI
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] GameObject _mainMenu;
        [SerializeField] GameObject _controlScreen;
        [SerializeField] GameObject _quitCanvas;

        public void LoadFirstLevel()
        {
            // Assuming the first level is the 2nd scene
            // (first scene being the menu)
            SceneManager.LoadScene(1);
        }

        public void LoadControlScreen()
        {
            _mainMenu.SetActive(false);
            _controlScreen.SetActive(true);
        }

        public void LoadMainMenu()
        {
            _controlScreen.SetActive(false);
            _mainMenu.SetActive(true);
        }

        public void StartQuit()
        {
            _quitCanvas.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Polar.UI
{
    public class Quitter : MonoBehaviour
    {
        public void QuitGame()
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #elif UNITY_WEBPLAYER
            Application.OpenURL("https://itch.io/jam/gjl-game-parade");
            #else
            Application.Quit();
            #endif
        }
    }
}

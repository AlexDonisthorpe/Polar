using UnityEngine;
using Polar.UI;
using System.Collections;

namespace Polar.Core
{
    public class Trophy : MonoBehaviour
    {
        [SerializeField] float levelLoadDelay = 2f;

        private void OnTriggerEnter(Collider other)
        {
            AkSoundEngine.PostEvent("Win", gameObject);
            StartCoroutine(LoadLevel());
        }

        private IEnumerator LoadLevel()
        {
            yield return new WaitForSecondsRealtime(levelLoadDelay);
            FindObjectOfType<LevelController>().LoadYouWinCanvas();
        }
    }
}
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Polar.UI
{
    public class PauseUI : MonoBehaviour
    {
        public static bool isPaused = false;
        [SerializeField] GameObject PauseMenuUI;
        private Animator _pauseAnimator;

        [SerializeField] private GameObject[] _buttonObjects;

        private void Start()
        {
            _pauseAnimator = PauseMenuUI.GetComponent<Animator>();
        }

        public void StartResume()
        {
            StartCoroutine(HideButtons(0.5f));
            StartCoroutine(Resume());
        }

        private IEnumerator HideButtons(float delay)
        {
            yield return new WaitForSecondsRealtime(delay);
            foreach (var button in _buttonObjects)
            {
                button.SetActive(false);
            }
        }

        private IEnumerator ShowButtons(float delay)
        {
            yield return new WaitForSecondsRealtime(delay);
            foreach (var button in _buttonObjects)
            {
                button.SetActive(true);
            }

        }

        public void Pause()
        {
            PauseMenuUI.SetActive(true);
            Time.timeScale = 0;
            StartCoroutine(ShowButtons(0.8f));
            isPaused = true;
        }

        private IEnumerator Resume()
        {
            _pauseAnimator.SetTrigger("FadeIn");
            yield return new WaitForSecondsRealtime(1f);
            PauseMenuUI.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
        }

        public IEnumerator ReturnToMainMenu()
        {
            _pauseAnimator.SetTrigger("MenuFadeOut");
            yield return new WaitForSecondsRealtime(1f);
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }

        public void FadeToMenu()
        {
            StartCoroutine(HideButtons(0.2f));
            StartCoroutine(ReturnToMainMenu());
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                {
                    StartResume();
                }
                else
                {
                    Pause();
                }
            }
        }

    }
}

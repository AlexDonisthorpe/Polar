using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Polar.UI
{
    public class LevelSelectManager : MonoBehaviour
    {
        [SerializeField] Level[] levels;
        [SerializeField] TMP_Text levelNameField;
        [SerializeField] TMP_Text levelDescriptionField;
        [SerializeField] Image screenshotField;
        [SerializeField] GameObject nextLevelButton;
        [SerializeField] GameObject previousLevelButton;
        [SerializeField] Fader fader;

        private int currentLevel;
        private int currentLevelSceneId;

        private void Start()
        {
            AssignLevel(0);
        }

        private void AssignLevel(int levelIndex)
        {
            currentLevel = levelIndex;

            levelNameField.text = levels[currentLevel].name;
            levelDescriptionField.text = levels[currentLevel].levelDescription;
            screenshotField.sprite = levels[currentLevel].levelScreenshot;

            currentLevelSceneId = levels[currentLevel].sceneId;

            UpdateButtons();
        }

        private void UpdateButtons()
        {
            if(currentLevel == 0)
            {
                previousLevelButton.SetActive(false);
            } else
            {
                previousLevelButton.SetActive(true);
            }

            if(currentLevel == levels.Length-1)
            {
                nextLevelButton.SetActive(false);
            }
            else
            {
                nextLevelButton.SetActive(true);
            }
        }

        public void GoNext()
        {
            AssignLevel(currentLevel + 1);
        }

        public void GoBack()
        {
            if (currentLevel == 0) return;

            AssignLevel(currentLevel - 1);
        }

        public void StartPlay()
        {
            // Code smell, omg - no time - panik
            fader.LoadLevel(currentLevelSceneId);
        }

    }
}
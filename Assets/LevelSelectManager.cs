using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

        private void Start()
        {
            AssignLevel(0);
        }

        private void AssignLevel(int levelIndex)
        {
            levelNameField.text = levels[levelIndex].name;
            levelDescriptionField.text = levels[levelIndex].levelDescription;
            screenshotField.sprite = levels[levelIndex].levelScreenshot;
            currentLevel = levels[levelIndex].sceneId;

            UpdateButtons();
        }

        private void UpdateButtons()
        {
            if(currentLevel == levels[0].sceneId)
            {
                previousLevelButton.SetActive(false);
            } else
            {
                previousLevelButton.SetActive(true);
            }

            if(currentLevel == levels[levels.Length-1].sceneId)
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
            fader.LoadLevel(currentLevel);
        }

    }
}
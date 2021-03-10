using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Polar.UI
{
    public class HealthUI : MonoBehaviour
    {
        int _playerLives = 3;
        [SerializeField] TMP_Text _tmproText;

        public void UpdateLives(int lives)
        {
            _playerLives = lives;
            UpdateLivesText();
        }

        private void UpdateLivesText()
        {
            _tmproText.text = _playerLives.ToString();
        }
    }
}
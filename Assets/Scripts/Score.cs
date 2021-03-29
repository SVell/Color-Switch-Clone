using System;
using TMPro;
using UnityEngine;

namespace ColorSwitch.Score
{
    public class Score : MonoBehaviour
    {
        private TextMeshProUGUI _scoreText;
        private int _score;

        private void Awake()
        {
            _scoreText = GetComponent<TextMeshProUGUI>();
        }

        
        private void OnEnable()
        {
            StarCollision.updateScore += UpdateScore;
        }

        private void OnDisable()
        {
            StarCollision.updateScore -= UpdateScore;
        }

        private void UpdateScore()
        {
            _scoreText.text = (++_score).ToString();
        }
    }
}

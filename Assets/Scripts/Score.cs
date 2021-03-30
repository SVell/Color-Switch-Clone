using TMPro;
using UnityEngine;

namespace ColorSwitch.Score
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _gameOverScoreText;
        [SerializeField] private TextMeshProUGUI _highScoreText;
        
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
            
            // Set best score
            int highScore = PlayerPrefs.GetInt("HighScore");
            PlayerPrefs.SetInt("HighScore", Mathf.Max(highScore, _score));
        }

        public void SetGameOverText()
        {
            if (_gameOverScoreText && _highScoreText)
            {
                _gameOverScoreText.text = _score.ToString();
                _highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
            }
        }
    }
}

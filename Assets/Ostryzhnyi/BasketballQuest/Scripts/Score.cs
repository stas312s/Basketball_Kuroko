using TMPro;
using UnityEngine;

namespace Ostryzhnyi.BasketballQuest.Scripts
{
    public class Score : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI highScoreText; 
        public static Score instance;
        public int score = 0;
        public int highScore = 0;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "FinishTrigger")
            {
                PlayerPrefs.SetInt("score", score);
                score++;

                if (score > highScore)
                {
                    highScore = score;
                    PlayerPrefs.SetInt("HighScore", highScore);
                    highScoreText.text = " " + highScore.ToString();
                }
            }
        }

        void Start()
        {
            if (PlayerPrefs.HasKey("Score"))
            {
                score = PlayerPrefs.GetInt("Score");
            }

            if (PlayerPrefs.HasKey("HighScore"))
            {
                highScore = PlayerPrefs.GetInt("HighScore");
            }

            scoreText.text = score.ToString();
            highScoreText.text = " " + highScore.ToString();
        }

        private void OnDestroy()
        {
            PlayerPrefs.SetInt("Score", score);
        }

        void Update()
        {
            scoreText.text = score.ToString();
        }
    }
}
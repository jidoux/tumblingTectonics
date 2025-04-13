using TMPro;
using UnityEngine;

namespace TumblingTectonics.UI {

    public class ScoreTextManager : MonoBehaviour {
        [SerializeField] private GameObject currentScore;
        public int score = 0;

        public void IncrementScore() {
            score++;
            TMP_Text scoreText = currentScore.GetComponent<TMP_Text>();
            scoreText.text = "Score: " + score;
        }
    }
}

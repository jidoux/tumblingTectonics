using TMPro;
using UnityEngine;

namespace TumblingTectonics.UI {

    public class ScoreTextManager : MonoBehaviour {
        [SerializeField] private GameObject currentScore;
        public int score = 0;

        public void IncrementScore() {
            Debug.Log("increment score called");
            score++;
            TMP_Text scoreText = currentScore.GetComponent<TMP_Text>();
            Debug.Log(string.Format("score text found with value: {0}", scoreText.text));
            scoreText.text = "Score: " + score;
        }
    }
}

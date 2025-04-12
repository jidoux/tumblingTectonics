using UnityEngine;
using UnityEngine.SceneManagement;

namespace TumblingTectonics.UI {

    public class EndScreenButtonManager : MonoBehaviour {

        //void Awake() {
        //    TMP_Text highScoreText = highScore.GetComponent<TMP_Text>();
        //    highScoreText.text = $"The High Score: {highScoreValue}";
        //    GameObject userScore = GameObject.Find("ScoreText");
        //    TMP_Text scoreText = userScore.GetComponent<TMP_Text>();
        //    scoreText.text = $"Your Score: {userScoreValue}";
        //}

        public void OnButtonPress() {
            RestartGame();
        }

        private void RestartGame() {
            SceneManager.LoadScene("GameScreen");
        }
    }
}


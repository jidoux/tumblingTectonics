using TMPro;
using UnityEngine;

namespace TumblingTectonics.UI {
    class HighScoreTextManager : MonoBehaviour {
        [SerializeField] private GameObject highScoreGameObject;
        public int highScoreValue = 0;
        private string playerPrefsHighScoreName = "HighScore";

        public void SetHighScoreText() { // TODO if high score gets updated will highScoreValue this int be updated or no
            if (PlayerPrefs.HasKey(playerPrefsHighScoreName)) {
                highScoreValue = PlayerPrefs.GetInt(playerPrefsHighScoreName);
            }
            else { 
                highScoreValue = 0;
            }
            TMP_Text highScoreText = highScoreGameObject.GetComponent<TMP_Text>();
            highScoreText.text = "High Score: " + highScoreValue.ToString();
        }

        public void UpdateHighScoreIfTheirScoreIsBetter(int playerScore) {
            if (playerScore > highScoreValue) {
                PlayerPrefs.SetInt(playerPrefsHighScoreName, playerScore);
            }
        }
    }
}
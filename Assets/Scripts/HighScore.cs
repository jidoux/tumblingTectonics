using TMPro;
using UnityEngine;

namespace TumblingTectonics.UI {
    public class HighScore : MonoBehaviour {
        // static means its accessable by other scripts with HighScore.score so yeah thats nice
        // it also means that upon calling LoadScene and reloading this scene, it will remain (until the game itself is force stopped)
        // but obviously that isnt optimal so we use PlayerPrefs to make variables persist
        static public int score = 0;
        private string playerPrefsHighScoreName = "HighScore"; // cuz in my head using a string literal for this is just asking for problems
        void Start() {

        }

        void Awake() { // executed when the instance is created (runs before Start())
            if (PlayerPrefs.HasKey(playerPrefsHighScoreName)) {
                score = PlayerPrefs.GetInt(playerPrefsHighScoreName);
            }
            PlayerPrefs.SetInt(playerPrefsHighScoreName, score); // it either writes or updates this value right? Surely...
        }

        void Update() {
            TMP_Text highScoreText = this.GetComponent<TMP_Text>();
            highScoreText.text = "High Score: " + score; // string + int calls ToString() implicitly on the int

            // updating the PlayerPrefs high score if it must be done
            if (score > PlayerPrefs.GetInt(playerPrefsHighScoreName)) {
                PlayerPrefs.SetInt(playerPrefsHighScoreName, score);
            }
        }
    }
}
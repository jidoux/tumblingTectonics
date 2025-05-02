using TumblingTectonics.Sound;
using TumblingTectonics.UI;
using UnityEngine;

namespace TumblingTectonics.GameManager {

    public class MiscStartGameLogic : MonoBehaviour {

        [SerializeField] private GameObject cursorManagerScript;
        [SerializeField] private GameObject player; // TODO ensure the audio follows the player idk if it will
        [SerializeField] private AudioClip gameBackgroundMusic;
        [Header("For the volume, 1 is max, 0 is min")]
        [SerializeField] private float gameBackgroundMusicVolume;

        private void Start() {
            cursorManagerScript.GetComponent<CursorManager>().DisableCursor();
            GameObject score = GameObject.Find("ScoreManager");
            score.GetComponent<HighScoreTextManager>().SetHighScoreText();
            if (SoundEffectsManager.gameEndMusic != null) {
                SoundEffectsManager.gameEndMusic.Stop();
                Destroy(SoundEffectsManager.gameEndMusic.gameObject);
            }
            SoundEffectsManager.soundEffectsManagerInstance.PlaySoundEffectsClip(gameBackgroundMusic, player.transform, gameBackgroundMusicVolume);
        }
    }
}

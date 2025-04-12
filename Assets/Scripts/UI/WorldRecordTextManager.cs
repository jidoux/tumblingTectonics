using TMPro;
using UnityEngine;

namespace TumblingTectonics.UI {

    public class WorldRecordTextManager : MonoBehaviour {
        [SerializeField] private GameObject worldRecordScoreGameObject;
        public int worldRecordScoreValue = 0;

        // TODO set this up to be called when the scene loads. Add caching later but its not a problem I'd say
        public void GetWorldRecordScore() {
            TMP_Text worldRecordText = worldRecordScoreGameObject.GetComponent<TMP_Text>();
            worldRecordText.text = "World Record: " + worldRecordText;
        }

        // TODO also this, also add some interface to backend or something like this I'd say.
        public void PlayerDiedUpdateScoreIfTheirsWasBetter(int playerScore) {
            if (playerScore > worldRecordScoreValue) {
                worldRecordScoreValue = playerScore;
            }
        }
    }
}

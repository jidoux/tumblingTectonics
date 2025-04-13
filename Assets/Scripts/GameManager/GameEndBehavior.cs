using TumblingTectonics.Player;
using TumblingTectonics.UI;
using UnityEngine;

namespace TumblingTectonics.GameManager {
    public class GameEndBehavior : MonoBehaviour {
        // needed to play player death animation upon game end
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject deadPlayerUi;
        [SerializeField] private GameObject cursorManagerScript;

        private void Start() {
            deadPlayerUi.SetActive(false);
        }

        public void EndGame() {
            cursorManagerScript.GetComponent<CursorManager>().EnableCursor();
            deadPlayerUi.SetActive(true);
            // disabling the movement script controller
            player.GetComponent<MovementController>().enabled = false;
            // disabling the players collider so that the boulder's dont bounce off the corpse
            player.GetComponent<CharacterController>().enabled = false;
            PlayDeathAnimation();
            GameObject score = GameObject.Find("ScoreManager");
            //int playerScore = score.GetComponent<ScoreTextManager>().score;
            //score.GetComponent<WorldRecordTextManager>().PlayerDiedUpdateScoreIfTheirsWasBetter(playerScore);
        }

        private void PlayDeathAnimation() {
            Animator animator = player.GetComponent<Animator>();
            animator.SetBool("IsDead", true);
        }
    }
}

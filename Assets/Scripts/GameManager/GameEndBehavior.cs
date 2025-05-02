using TumblingTectonics.Player;
using TumblingTectonics.Sound;
using TumblingTectonics.UI;
using UnityEngine;

namespace TumblingTectonics.GameManager {
    public class GameEndBehavior : MonoBehaviour {
        // needed to play player death animation upon game end
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject deadPlayerUi;
        [SerializeField] private GameObject cursorManagerScript;
        [SerializeField] private AudioClip deathSound;
        [SerializeField] private AudioClip deathSong;
        [Header("For the volume, 1 is max, 0 is min")]
        [SerializeField] private float deathSoundVolume;
        [SerializeField] private float deathSongVolume;

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
            handleSounds();

        }

        private void handleSounds() {
            if (SoundEffectsManager.gameMusic != null) {
                SoundEffectsManager.gameMusic.Stop();
                Destroy(SoundEffectsManager.gameMusic.gameObject);
            }
            SoundEffectsManager.soundEffectsManagerInstance.PlaySoundEffectsClip(deathSound, player.transform, deathSoundVolume);
            SoundEffectsManager.soundEffectsManagerInstance.PlaySoundEffectsClip(deathSong, player.transform, deathSongVolume);
        }

        private void PlayDeathAnimation() {
            Animator animator = player.GetComponent<Animator>();
            animator.SetBool("IsDead", true);
        }
    }
}

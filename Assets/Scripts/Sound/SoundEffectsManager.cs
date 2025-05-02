using UnityEngine;
using UnityEngine.UIElements;

namespace TumblingTectonics.Sound {
    public class SoundEffectsManager : MonoBehaviour {

        // making a singleton since there will only be one of these in the scene
        public static SoundEffectsManager soundEffectsManagerInstance;
        [SerializeField] private AudioSource soundEffectObject;

        static public AudioSource gameMusic;
        static public AudioSource gameEndMusic;


        private void Awake() {
            soundEffectsManagerInstance ??= this;
        }

        public void PlaySoundEffectsClip(AudioClip audioClip, Transform spawnTransform, float volume) {
            AudioSource gameMusicAudioSource = Instantiate<AudioSource>(soundEffectObject, spawnTransform.position, Quaternion.identity);

            gameMusicAudioSource.clip = audioClip;

            gameMusicAudioSource.volume = volume;

            gameMusicAudioSource.Play();

            if (audioClip.name == "background-song-rising-darkness") {
                gameMusicAudioSource.loop = true;
                gameMusic = gameMusicAudioSource;
            }
            else if (audioClip.name == "avemaria") {
                gameMusicAudioSource.loop = true;
                gameEndMusic = gameMusicAudioSource;
            }

            float clipLength = gameMusicAudioSource.clip.length;

            // idk if this works TODO check but its meant to not raise exception if we destroy this in
            // another place i.e. when player dies
            if (gameMusicAudioSource != null) {
                Destroy(gameMusicAudioSource.gameObject, clipLength);
            }
        }
    }
}

using TumblingTectonics.Sound;
using TumblingTectonics.UI;
using UnityEngine;

namespace TumblingTectonics.Coin {

    public class CoinManager : AbstractGameObjectHandler {
        [SerializeField] private AudioClip coinPickupSound;
        [Header("For the volume, 1 is max, 0 is min")]
        [SerializeField] private float coinPickupVolume;

        public override void OnCollisionEnter(Collision collision) {
            GameObject collidedWith = collision.gameObject;
            if (collidedWith.name == "Slope(Clone)") {
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                gameObject.GetComponent<Renderer>().enabled = true;
            }
        }

        public void OnTriggerEnter(Collider other) {
            GameObject collidedWith = other.gameObject;
            if (collidedWith.name == "Player") {
                Destroy(this.gameObject);
                SoundEffectsManager.soundEffectsManagerInstance.PlaySoundEffectsClip(coinPickupSound, collidedWith.transform, coinPickupVolume);
                // TODO is there a better way to do this or? It has type mismatch cuz its prefab cant have
                // serializedField with some gameobject so idk man
                GameObject scoreTextManager = GameObject.Find("ScoreManager");
                scoreTextManager.GetComponent<ScoreTextManager>().IncrementScore();
                int playerScore = scoreTextManager.GetComponent<ScoreTextManager>().score;
                scoreTextManager.GetComponent<HighScoreTextManager>().UpdateHighScoreIfTheirScoreIsBetter(playerScore);
                scoreTextManager.GetComponent<HighScoreTextManager>().SetHighScoreText();
            }
        }
    }
}

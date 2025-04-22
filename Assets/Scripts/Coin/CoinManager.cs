using TumblingTectonics.UI;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace TumblingTectonics.Coin {

    public class CoinManager : AbstractGameObjectHandler {

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

using TumblingTectonics.UI;
using UnityEngine;

namespace TumblingTectonics.Coin {

    public class CoinManager : AbstractGameObjectHandler {
        public override void OnCollisionEnter(Collision collision) {
            // its not implemented, i didnt design this well, sorry
            // my interface/superclass for game objects assumes they will all use collisionEnter
            // but this one uses trigger instead. Idk how I could have prevented this.
            // it still requires the AbstractGameObjectHandler for other things such as deletion though
        }

        public void OnTriggerEnter(Collider other) {
            GameObject collidedWith = other.gameObject;
            if (collidedWith.name == "Slope(Clone)") {
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                gameObject.GetComponent<Renderer>().enabled = true;
                // moving it up a bit
                gameObject.transform.position = new Vector3(
                    transform.position.x, transform.position.y + 2f, transform.position.z);
                // it meant to be a random rotation but who knows i really dont know what its doing ya feel me
                Quaternion rotationOfCoin = Quaternion.Euler(0, 0, Random.Range(0, 360));
                gameObject.transform.rotation = rotationOfCoin;
            }
            if (collidedWith.name == "Player") {
                Destroy(this.gameObject);
                // TODO is there a better way to do this or?
                GameObject score = GameObject.Find("ScoreManager");
                score.GetComponent<ScoreTextManager>().IncrementScore();
            }
        }
    }
}

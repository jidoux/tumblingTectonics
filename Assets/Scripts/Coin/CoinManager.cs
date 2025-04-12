using UnityEngine;

namespace TumblingTectonics.Coin {

    public class CoinManager : AbstractGameObjectHandler {
        public override void OnCollisionEnter(Collision collision) {
            GameObject collidedWith = collision.gameObject;
            if (collidedWith.name == "Player") {
                Destroy(this.gameObject);
                Debug.Log("increas score k"); // TODO this doesnt wokr but why who lknows..
            }
        }

    }
}
using TumblingTectonics.GameManager;
using UnityEngine;

namespace TumblingTectonics.Boulder {

    public class BoulderManager : AbstractGameObjectHandler {
        //[SerializeField] private float howFarBelowPlayerToStartDeletingBoulders = 50f;

        //private void Update() {
        //    CheckIfBoulderShouldBeDeleted();
        //}

        //private void CheckIfBoulderShouldBeDeleted() {
        //    float playerYPosition = Camera.main.transform.position.y;
        //    if (transform.position.y < playerYPosition - howFarBelowPlayerToStartDeletingBoulders) {
        //        Destroy(this.gameObject);
        //    }
        //}

        public override void OnCollisionEnter(Collision collision) {
            GameObject collidedWith = collision.gameObject;
            if (collidedWith.name == "Player") {
                GameEndBehavior gameEndBehaviorScript = Camera.main.GetComponent<GameEndBehavior>();
                gameEndBehaviorScript.EndGame();
            }
            else if (gameObject.GetComponent<Renderer>().enabled != true) {
                gameObject.GetComponent<Renderer>().enabled = true;
            }
        }
    }
}

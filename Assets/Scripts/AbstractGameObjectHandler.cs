using UnityEngine;

namespace TumblingTectonics {
    public abstract class AbstractGameObjectHandler : MonoBehaviour {
        // it seems this is used by its subclasses which makes sense ig
        [SerializeField] private float howFarBelowPlayerToDeleteIt = 50f;

        public void Update() {
            CheckIfObjectShouldBeDeleted();
        }

        public void CheckIfObjectShouldBeDeleted() {
            float cameraYPosition = Camera.main.transform.position.y;
            if (this.transform.position.y < cameraYPosition - howFarBelowPlayerToDeleteIt) {
                Destroy(this.gameObject);
            }
        }

        public abstract void OnCollisionEnter(Collision collision);
    }
}

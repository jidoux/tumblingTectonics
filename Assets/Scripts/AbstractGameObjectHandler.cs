using TumblingTectonics.GameManager;
using UnityEngine;

namespace TumblingTectonics {
    public abstract class AbstractGameObjectHandler : MonoBehaviour {
        // TODO will this interface be attached to anything even?
        [SerializeField] private float howFarBelowPlayerToDeleteIt = 50f;

        public void Update() {
            CheckIfObjectShouldBeDeleted();
        }

        public void CheckIfObjectShouldBeDeleted() {
            float cameraYPosition = Camera.main.transform.position.y;
            if (this.transform.position.y < cameraYPosition - howFarBelowPlayerToDeleteIt) {
                Destroy(this.gameObject);
                Debug.Log(string.Format("Destored gameObject with name: {0}", this.gameObject.name));
            }
        }

        public abstract void OnCollisionEnter(Collision collision);
    }
}

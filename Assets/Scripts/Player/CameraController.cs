using UnityEngine;

namespace TumblingTectonics.Player {

    public class CameraController : MonoBehaviour {

        [SerializeField] private Transform followTarget;
        [SerializeField] private float distanceAwayFromPlayer = 6f;
        [SerializeField] Vector2 verticalPlayerViewingOffset;

        private void Update() {
            Vector3 focusPosition = followTarget.position + new Vector3(
                verticalPlayerViewingOffset.x, verticalPlayerViewingOffset.y, 0);
            // setting position of the camera to behind the character
            transform.position = focusPosition - Quaternion.identity * new Vector3(0, 0, distanceAwayFromPlayer);
        }


        public Quaternion PlanarRotationOfCamera => Quaternion.identity;
    }
}

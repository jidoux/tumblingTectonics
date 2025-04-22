using UnityEngine;

namespace TumblingTectonics.Player {

    public class CameraController : MonoBehaviour {

        [SerializeField] private Transform followTarget;
        [SerializeField] private float distanceAwayFromPlayer = 6f;
        [SerializeField] private Vector2 verticalPlayerViewingOffset;
        [SerializeField] private float verticalRotationOfCamera = 10f;

        private void Update() {
            Quaternion rotationOfCamera = Quaternion.Euler(verticalRotationOfCamera, 0, 0);
            Vector3 focusPosition = followTarget.position + new Vector3(
                verticalPlayerViewingOffset.x, verticalPlayerViewingOffset.y, 0);
            // setting position of the camera to behind the character
            transform.position = focusPosition - rotationOfCamera * new Vector3(0, 0, distanceAwayFromPlayer);
            transform.rotation = rotationOfCamera;
        }
    }
}

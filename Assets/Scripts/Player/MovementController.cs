using UnityEngine;

namespace TumblingTectonics.Player
{
    public class MovementController : MonoBehaviour {

        [SerializeField] private float movementSpeed = 5f;
        [SerializeField] private float maxDegreesToTurn = 450f;
        // idk if this is optimal but basically I need to get the slope prefab's z scale
        // to determine how to limit the character's movement on the x-axis (limit the player
        // from walking off the edges of the map basically). The other way is using gameObject.Find()
        // but idk about that ones efficiency (even tho it would be in start) + its going off a prefab.
        [SerializeField] private GameObject slopePrefab;
        [SerializeField] private float howFarPlayerCanBacktrack = 40f;
        [Header("Ground Check Settings")]
        [SerializeField] private float groundCheckRadius = 0.2f;
        [SerializeField] private Vector3 groundCheckPositionOffset;
        [SerializeField] private LayerMask groundCheckLayerMask;

        private bool isGrounded;
        private float ySpeed;
        private Quaternion targetRotation;
        private CameraController cameraController;
        private Animator animator;
        private CharacterController characterController;
        private float maxDistanceAwayFromCenterOnEitherSide;
        // storing this to limit the player's ability to go backwards based on how far they've gone
        private float maxZValueSoFar;

        private void Awake() {
            cameraController = Camera.main.GetComponent<CameraController>();
            animator = GetComponent<Animator>();
            characterController = GetComponent<CharacterController>();
        }

        private void Start() {
            float slopePrefabZScale = slopePrefab.transform.localScale.z;
            Debug.Log(string.Format("slope prefab z scale: {0}", slopePrefabZScale));
            maxDistanceAwayFromCenterOnEitherSide = slopePrefabZScale / 2f;
            maxZValueSoFar = gameObject.transform.position.z;
        }

        private void Update() {
            float currentZPos = gameObject.transform.position.z;
            if (currentZPos > maxZValueSoFar) {
                maxZValueSoFar = currentZPos;
            }
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            float moveAmount = Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput);
            moveAmount = Mathf.Clamp01(moveAmount); // clamping move amount to be between 0-1 for player animation

            // need to normalize so that diagonal movement isn't faster than movement in a single direction
            Vector3 movementInput = (new Vector3(horizontalInput, 0, verticalInput)).normalized;

            // move the movement input in the camera's direction
            Vector3 moveDirection = cameraController.PlanarRotationOfCamera * movementInput;
            ConstrainMovementToWithinBounds(ref moveDirection);

            GroundCheck();
            if (isGrounded) {
                ySpeed = -0.5f;
            }
            else {
                ySpeed += Physics.gravity.y * Time.deltaTime;
            }

            Vector3 velocity = moveDirection * movementSpeed;
            velocity.y = ySpeed;
            characterController.Move(velocity * Time.deltaTime);

            if (moveAmount > 0) {
                targetRotation = Quaternion.LookRotation(moveDirection);
            }

            // slowly change current rotation of player to the target rotation
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, targetRotation, maxDegreesToTurn * Time.deltaTime);

            float dampTimeToMakeMovementSmoother = 0.2f;
            animator.SetFloat("moveAmount", moveAmount, dampTimeToMakeMovementSmoother, Time.deltaTime);
        }

        private void ConstrainMovementToWithinBounds(ref Vector3 moveDirection) {
            // capping x-axis movement (for left and right movements)
            if (gameObject.transform.position.x > maxDistanceAwayFromCenterOnEitherSide - 0.5f) {
                moveDirection.x = -0.05f;
            }
            else if (gameObject.transform.position.x < -maxDistanceAwayFromCenterOnEitherSide + 0.5f) {
                moveDirection.x = 0.05f;
            }
            // capping z axis movement (for going backwards)
            if (gameObject.transform.position.z < maxZValueSoFar - howFarPlayerCanBacktrack) {
                moveDirection.z = 0.05f;
            }
        }

        private void GroundCheck() {
            // you need the layer mask for physics operations so you only check for colliders in that layer or smth
            Vector3 playerPositionWithOffset = transform.TransformPoint(groundCheckPositionOffset);
            isGrounded = Physics.CheckSphere(playerPositionWithOffset, groundCheckRadius, groundCheckLayerMask);
        }

        private void OnDrawGizmosSelected() {
            Gizmos.color = new Color(0, 255, 0, 0.5f);
            Vector3 playerPositionWithOffset = transform.TransformPoint(groundCheckPositionOffset);
            Gizmos.DrawSphere(playerPositionWithOffset, groundCheckRadius);
        }
    }
}


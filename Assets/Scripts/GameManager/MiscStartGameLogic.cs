using TumblingTectonics.UI;
using UnityEngine;

namespace TumblingTectonics.GameManager {

    public class MiscStartGameLogic : MonoBehaviour {

        [SerializeField] private GameObject cursorManagerScript;

        private void Start() {
            cursorManagerScript.GetComponent<CursorManager>().DisableCursor();
        }
    }
}

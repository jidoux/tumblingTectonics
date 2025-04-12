using UnityEngine;

namespace TumblingTectonics.UI {
    public class CursorManager : MonoBehaviour {

        public void DisableCursor() {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void EnableCursor() {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}

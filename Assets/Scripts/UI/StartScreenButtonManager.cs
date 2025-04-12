using UnityEngine;
using UnityEngine.SceneManagement;

namespace TumblingTectonics.UI {
    public class StartScreenButtonManager : MonoBehaviour {
        public void OnButtonPress() {
            StartGame();
        }

        private void StartGame() {
            SceneManager.LoadScene("GameScreen");
        }
    }
}

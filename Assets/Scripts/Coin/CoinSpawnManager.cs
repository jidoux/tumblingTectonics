using UnityEngine;

namespace TumblingTectonics.Coin {
    public class CoinSpawnManager : MonoBehaviour {

        public void SpawnCoins(Vector3 positionToSpawnCoin, GameObject coinContainer) {
            // its 100 just for the falling & random spawning stuff
            positionToSpawnCoin.y += 100;
            int numCoinsToSpawnForThisSlope = Mathf.Max(Random.Range(8, 18), Random.Range(8, 18));
            for (int i = 0; i < numCoinsToSpawnForThisSlope; i++) {
                positionToSpawnCoin.x = Random.Range(-29.5f, 29.5f);
                positionToSpawnCoin.z += Random.Range(-29.5f, 29.5f);
                GameObject coin = Instantiate<GameObject>(this.gameObject, positionToSpawnCoin, Quaternion.identity);
                // toggling the renderer of the coin so that when it initially spawns its not rendered
                // it will render later if needed (when it lands on the ground for example)
                coin.GetComponent<Renderer>().enabled = false;
                coin.GetComponent<Rigidbody>().freezeRotation = true;
                coin.transform.SetParent(coinContainer.transform);
            }
        }
    }
}

using UnityEngine;

namespace TumblingTectonics.Coin {
    public class CoinSpawnManager : MonoBehaviour {

        public void SpawnCoins(Vector3 position, GameObject coinContainer) {
            // its 100 just for the falling & random spawning stuff
            position.y += 100;
            int numCoinsToSpawnForThisSlope = Mathf.Max(Random.Range(80, 100), Random.Range(80, 100));
            for (int i = 0; i < numCoinsToSpawnForThisSlope; i++) {
                position.x += Random.Range(-39.5f, 39.5f);
                position.z += Random.Range(-79.5f, 79.5f);
                GameObject coin = Instantiate<GameObject>(this.gameObject, position, Quaternion.identity);
                // toggling the renderer of the coin so that when it initially spawns its not rendered
                // it will render later if needed (when it lands on the ground for example)
                coin.GetComponent<Renderer>().enabled = false;
                // making it fall super fast (idk if this even works honestly who knows)
                //coin.GetComponent<Rigidbody>().AddForce(Vector3.down * 500f);
                coin.transform.SetParent(coinContainer.transform);
            }
        }
    }
}

using UnityEngine;

namespace TumblingTectonics.Coin {
    public class CoinSpawnManager : MonoBehaviour {

        public void SpawnCoins(Vector3 position, GameObject coinContainer) {
            // its 100 just for the falling & random spawning stuff
            position.y += 100;
            //int numCoinsToSpawnForThisSlope = Mathf.Max(Random.Range(15, 60), Random.Range(15, 60));
            //Debug.Log(string.Format("num coins for this slope is: {0}", numCoinsToSpawnForThisSlope));
            for (int i = 0; i < 100; i++) {
                position.x += Random.Range(-39.5f, 39.5f);
                position.z += Random.Range(-79.5f, 79.5f);
                // it meant to be a random rotation but who knows i really dont know what its doing ya feel me
                Quaternion rotationOfCoin = Quaternion.Euler(0, Random.Range(0, 360), 0);
                GameObject coin = Instantiate<GameObject>(this.gameObject, position, rotationOfCoin);
                // toggling the renderer of the coin so that when it initially spawns its not rendered
                // it will render later if needed (when it lands on the ground for example)
                coin.GetComponent<Renderer>().enabled = false;
                // making it fall super fast
                coin.GetComponent<Rigidbody>().AddForce(Vector3.down * 500f);
                Debug.Log(string.Format("Coin spawned at position:", position));
                coin.transform.SetParent(coinContainer.transform);
            }
        }
    }
}

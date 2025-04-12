using UnityEngine;

namespace TumblingTectonics.Coin {
    public class CoinSpawnManager : MonoBehaviour {

        public void SpawnCoins(Vector3 position, GameObject coinContainer) {
            // its 100 just for the falling & random spawning stuff
            position.y += 100;
            // TODO it meant to be a random rotation but who knows i really dont know what its doing ya feel me
            GameObject coin = Instantiate<GameObject>(this.gameObject, position, Quaternion.Euler(0, Random.Range(0, 360), 0));
            Debug.Log(string.Format("Coin spawned at position:", position.ToString()));
            coin.transform.SetParent(coinContainer.transform);
        }
    }
}

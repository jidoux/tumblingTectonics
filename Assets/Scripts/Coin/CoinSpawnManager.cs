using UnityEngine;

namespace TumblingTectonics.Coin {
    public class CoinSpawnManager : MonoBehaviour {
        //[SerializeField] private GameObject coinContainer; // TODO it say type mismatch but why

        public void SpawnCoin(Vector3 position) {
            GameObject coin = Instantiate<GameObject>(this.gameObject, position, Quaternion.Euler(0, Random.Range(0, 360), 0));
            Debug.Log("Coin spawned");
            //coin.transform.SetParent(coinContainer.transform);
        }
    }
}

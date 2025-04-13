using UnityEngine;
using System.Collections.Generic;

namespace TumblingTectonics.Boulder {

    public class BoulderSpawnManager : MonoBehaviour {
        // need to delete boulders after a certain time idk how though
        // https://discussions.unity.com/t/how-to-destroy-object-after-it-moves-out-of-screen/171127/4
        [SerializeField] private List<GameObject> boulderPrefabs;
        [SerializeField] private float maxBoulderSpawnDelay = 0.5f;
        // using this just to keep the hierarchy cleaner keeping all the boulders contained within 1 gameObject
        [SerializeField] private GameObject boulderContainer;

        private void Start() {
            Invoke(nameof(SpawnBoulder), 0.1f);
        }

        private void SpawnBoulder() {
            Vector3 positionToSpawnBoulder = Camera.main.transform.position;
            positionToSpawnBoulder.x = Random.Range(-28, 28 + 1); // max exclusive so I add 1
            positionToSpawnBoulder.y += 100;
            positionToSpawnBoulder.z += 130;
            int boulderIndexToSpawn = Random.Range(0, boulderPrefabs.Count);
            GameObject randomBoulder = boulderPrefabs[boulderIndexToSpawn];
            float randomBoulderSize = Mathf.Min(Random.Range(4f, 15f), Random.Range(4f, 15f));
            randomBoulder.transform.localScale = new Vector3(randomBoulderSize, randomBoulderSize, randomBoulderSize);
            float randomMassOfBoulder = Mathf.Min(Random.Range(1f, 10000f), Random.Range(1f, 10000f), Random.Range(1f, 10000f));
            randomBoulder.GetComponent<Rigidbody>().mass = randomMassOfBoulder;
            GameObject boulder = Instantiate<GameObject>(randomBoulder, positionToSpawnBoulder, Quaternion.identity);
            boulder.transform.SetParent(boulderContainer.transform);
            float timeToCallAgain = Mathf.Min(Random.Range(0f, maxBoulderSpawnDelay), Random.Range(0f, maxBoulderSpawnDelay));
            Invoke(nameof(SpawnBoulder), timeToCallAgain);
        }
    }
}

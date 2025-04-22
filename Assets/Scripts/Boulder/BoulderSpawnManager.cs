using UnityEngine;
using System.Collections.Generic;
using TumblingTectonics.UI;

namespace TumblingTectonics.Boulder {

    public class BoulderSpawnManager : MonoBehaviour {
        [SerializeField] private List<GameObject> boulderPrefabs;
        [SerializeField] private float maxBoulderSpawnDelay = 1f;
        // using this just to keep the hierarchy cleaner keeping all the boulders contained within 1 gameObject
        [SerializeField] private GameObject boulderContainer;
        [SerializeField] private GameObject scoreManager; // used to scale according to score
        [SerializeField] private float boulderSpawnScaleFactor = 0.05f;
        [SerializeField] private float boulderSpeedScaleFactor = 0.009f;
        int score = 0;

        private void Awake() {
            score = scoreManager.GetComponent<ScoreTextManager>().score;
        }

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
            randomMassOfBoulder = Mathf.Max(1f, randomMassOfBoulder - score * 40); // 40 is arbitrary
            randomBoulder.GetComponent<Rigidbody>().mass = randomMassOfBoulder;
            float randomBoulderSpeedVariation = Random.Range(-1f, 1f);
            // this line is needed to set the baseline of the prefab's linear damping
            randomBoulder.GetComponent<Rigidbody>().linearDamping = 2.5f;
            randomBoulder.GetComponent<Rigidbody>().linearDamping -= (score * boulderSpeedScaleFactor);
            randomBoulder.GetComponent<Rigidbody>().linearDamping += randomBoulderSpeedVariation;
            if (randomBoulder.GetComponent<Rigidbody>().linearDamping < 0) {
                randomBoulder.GetComponent<Rigidbody>().linearDamping = 0;
            }
            randomBoulder.GetComponent<Renderer>().enabled = false;
            // i dont think giving them random rotations will do anything but whatever
            randomBoulder.transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            GameObject boulder = Instantiate<GameObject>(randomBoulder, positionToSpawnBoulder, Quaternion.identity);
            boulder.transform.SetParent(boulderContainer.transform);
            float timeToCallAgain = Random.Range(0f, maxBoulderSpawnDelay);
            score = scoreManager.GetComponent<ScoreTextManager>().score;
            timeToCallAgain -= score * boulderSpawnScaleFactor;
            Invoke(nameof(SpawnBoulder), Mathf.Max(timeToCallAgain, 0.1f));
        }
    }
}

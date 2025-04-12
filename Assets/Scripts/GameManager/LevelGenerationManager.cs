using UnityEngine;
using System.Collections.Generic;
using TumblingTectonics.Coin;

namespace TumblingTectonics.GameManager {
    public class LevelGenerationManager : MonoBehaviour {
        // this whole file has weird calcs sorry I tried to make the numbers based off calculations and not
        // just random numbers but it really doesn't help, my understanding is not strong enough unfortunately
        // it works tho

        [SerializeField] private List<GameObject> slopePrefabs;
        // used so that the hierarchy doesn't get cluttered with a bunch of slope instances
        [SerializeField] private GameObject slopeContainer;
        // used to spawn the slopes in front of the player
        [SerializeField] private GameObject player;
        // this coin prefab has attached to it (currently at least) a script which
        // handles the coin spawning functions so
        [SerializeField] private GameObject coinPrefab;
        [SerializeField] private int amountOfSlopesOnScreen = 7;
        // if the player runs this total distance from the last removal, we remove the oldest slope and add a new one
        [SerializeField] private float distanceToSpawnNewSlope = 100f;

        private float distanceWithoutSpawningNewSlope;
        private float prevPlayerZPosition;
        private float yToSpawnNewSlope;
        private float zToSpawnNewSlope;
        private List<GameObject> activeSlopes;

        private void Awake() {
            yToSpawnNewSlope = 0;
            zToSpawnNewSlope = 0;
            prevPlayerZPosition = 0;
            activeSlopes = new List<GameObject>();
        }

        private void Start() {
            for (int i = 0; i < amountOfSlopesOnScreen; i++) {
                SpawnSlope();
            }
        }

        private void Update() {
            // this should handle net movements since if player moves backwards we just
            // subtract from distanceWithoutSpawningNewSlope. So it handles the case where
            // the player may move backwards to manipulate this into deleting the slope
            // they are standing on, which is nice
            float playerZMovement = player.transform.position.z - prevPlayerZPosition;
            distanceWithoutSpawningNewSlope += playerZMovement;
            prevPlayerZPosition = player.transform.position.z;
            if (distanceWithoutSpawningNewSlope > distanceToSpawnNewSlope) {
                distanceWithoutSpawningNewSlope -= distanceToSpawnNewSlope;
                SpawnSlope();
                DeleteSlope();
            }
        }

        private void SpawnSlope() {
            // values meant to offset to make the slopes fine
            // no idea why they are needed honestly but they are
            zToSpawnNewSlope -= 8.5f;
            yToSpawnNewSlope -= 2.8f;
            GameObject slopeToSpawn = slopePrefabs[0];
            slopeToSpawn.transform.position = new Vector3(0, yToSpawnNewSlope, zToSpawnNewSlope);
            GameObject slope = Instantiate<GameObject>(slopeToSpawn);
            slope.transform.SetParent(slopeContainer.transform);
            float slopeZ = slope.transform.localScale.z;
            yToSpawnNewSlope += slopeZ;
            zToSpawnNewSlope += (slopeZ + slopeZ * (slope.transform.rotation.z / 100)) * 1.5f;
            activeSlopes.Add(slope);

            Vector3 positionToSpawnCoin = slope.transform.position;
            positionToSpawnCoin.y += 1.5f; // TODO this 3 lines, idk where htey should go, idk what im doing ya know,.
            coinPrefab.GetComponent<CoinSpawnManager>().SpawnCoin(positionToSpawnCoin);
        }

        private void DeleteSlope() {
            Destroy(activeSlopes[0]);
            activeSlopes.RemoveAt(0);
        }
    }
}

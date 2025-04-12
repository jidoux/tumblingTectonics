using TMPro;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace TumblingTectonics.UI {

    public class WorldRecordTextManager : MonoBehaviour {
        [SerializeField] private GameObject worldRecordScoreGameObject;
        public int worldRecordScoreValue = 0;

        // TODO set this up to be called when the scene loads. Add caching later but its not a problem I'd say
        public async Task<int> GetWorldRecordScore() {
            var result = await FirebaseDatabase.DefaultInstance.GetReference("worldRecord").GetValueAsync();
            var valueOfResult = result.Value ?? 0;
            bool success = Int32.TryParse(valueOfResult.ToString(), out int intToReturn);
            if (!success) {
                intToReturn = 0;
            }
            return intToReturn;
        }

        public async void SetWorldRecordScoreText() {
            //DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
            // I will just store it as a worldRecord : true
            var result = await FirebaseDatabase.DefaultInstance.GetReference("worldRecord").GetValueAsync();
            Debug.Log(string.Format("result: {0}", result));
            var valueOfResult = result.Value ?? 0;
            Debug.Log(string.Format("valueOfResult: {0}", valueOfResult));
            TMP_Text worldRecordText = worldRecordScoreGameObject.GetComponent<TMP_Text>();
            worldRecordText.text = "World Record: " + valueOfResult.ToString();
        }

        // TODO also this, also add some interface to backend or something like this I'd say.
        public async void PlayerDiedUpdateScoreIfTheirsWasBetter(int playerScore) {
            Debug.Log(string.Format("called played died update score if theires was better w/playerScore {0}", playerScore));
            int currWorldRecord = await GetWorldRecordScore();
            Debug.Log(string.Format("got world record score it was: {0}", currWorldRecord.ToString()));
            if (playerScore > currWorldRecord) {
                Debug.Log("We are trying ok cond met");
                DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
                await reference.Child("worldRecord").SetRawJsonValueAsync(playerScore.ToString());
            }
        }
    }
}

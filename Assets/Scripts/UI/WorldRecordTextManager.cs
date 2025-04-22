//using TMPro;
//using UnityEngine;
//using Firebase.Database;
//using System;
// TODO tried to make it work with webgl but gave up, just felt like it wasnt worth my time sadly its a pain to do

//namespace TumblingTectonics.UI {

//    public class WorldRecordTextManager : MonoBehaviour {
//        [SerializeField] private GameObject worldRecordScoreGameObject;
//        public int worldRecordScoreValue = 0;

//        public async void SetWorldRecordScoreText() {
//            FirebaseDatabase db = FirebaseDatabase.DefaultInstance;
//            db.SetPersistenceEnabled(false);
//            var result = await db.GetReference("worldRecord").GetValueAsync();
//            var valueOfResult = result.Value ?? 0;
//            TMP_Text worldRecordText = worldRecordScoreGameObject.GetComponent<TMP_Text>();
//            worldRecordText.text = "World Record: " + valueOfResult.ToString();
//        }

//        public async void PlayerDiedUpdateScoreIfTheirsWasBetter(int playerScore) {
//            FirebaseDatabase db = FirebaseDatabase.DefaultInstance;
//            var result = await db.GetReference("worldRecord").GetValueAsync();
//            var valueOfResult = result.Value ?? 0;
//            bool success = Int32.TryParse(valueOfResult.ToString(), out int currWorldRecord);
//            if (!success)
//            {
//                currWorldRecord = 0;
//            }
//            if (playerScore > currWorldRecord)
//            {
//                DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
//                await reference.Child("worldRecord").SetRawJsonValueAsync(playerScore.ToString());
//            }
//        }
//    }
//}

//using TMPro;
//using UnityEngine;
//using Firebase.Database;
//using System;

//namespace TumblingTectonics.UI {

//    public class WorldRecordTextManager : MonoBehaviour {
//        [SerializeField] private GameObject worldRecordScoreGameObject;
//        public int worldRecordScoreValue = 0;

//        // TODO caching is prob optimal but for this project its really not needed at all since im storing 1 int only..
//        // by caching i dont mean firebase's caching I mean storing it so we dont need to call this everytime
//        // the game scene is loaded 
//        // removed this cuz of webgl since it used system.threading package
//        // public async Task<int> GetWorldRecordScore() {
//        //     FirebaseDatabase db = FirebaseDatabase.DefaultInstance;
//        //     // the caching just is being problematic, I assume they just have this setting on by default then?
//        //     // honestly this whole persistence feature just seems buggy from what I've seen, its useful but needs work
//        //     db.SetPersistenceEnabled(false);
//        //     var result = await db.GetReference("worldRecord").GetValueAsync();
//        //     var valueOfResult = result.Value ?? 0;
//        //     bool success = Int32.TryParse(valueOfResult.ToString(), out int intToReturn);
//        //     if (!success) {
//        //         intToReturn = 0;
//        //     }
//        //     return intToReturn;
//        // }

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
//             bool success = Int32.TryParse(valueOfResult.ToString(), out int currWorldRecord);
//            if (!success) {
//                currWorldRecord = 0;
//            }
//            if (playerScore > currWorldRecord) {
//                DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
//                await reference.Child("worldRecord").SetRawJsonValueAsync(playerScore.ToString());
//            }
//        }
//    }
//}

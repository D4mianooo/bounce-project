using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;
using UnityEngine.SceneManagement;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] TMP_Text nicknames;
    [SerializeField] TMP_Text scores;
    
    
    private void OnEnable(){
        int leaderboardID = 7127;
        int count = 6;
        int after = 0;

        LootLockerSDKManager.GetScoreList(leaderboardID, count, after, (response) =>
        {
            if (response.statusCode == 200) {
                Debug.Log("Successful");
                int i = 0;
                foreach(var item in response.items){
                    i++;
                    string nick = item.player.name.Length > 0 ? item.player.name : "Unknown" ;
                    nicknames.text += $"{i}. {nick}\n";
                    scores.text += $"{item.score}s\n";
                }
            } else {
                Debug.Log("failed: " + response.Error);
            }
        });
    }
}

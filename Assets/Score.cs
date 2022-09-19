using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using LootLocker.Requests;

public class Score : MonoBehaviour{
    
    private TMP_Text tmpText;
   
    private void Awake(){
        
        tmpText = GetComponentInChildren<TMP_Text>();
        
    }
    
    private void Update(){
        
        UpdateScore();

    }

    private void UpdateScore(){
        
        int timeSinceLoad = (int)Time.timeSinceLevelLoad;
        TimeSpan elapsed = TimeSpan.FromSeconds(timeSinceLoad);
        tmpText.text = String.Format("{0:D2}:{1:D2}:{2:D2}", elapsed.Hours, elapsed.Minutes, elapsed.Seconds);
    }
    
    public static void AddPlayerScoreToLeaderboard(){
        
        string nickname = GameObject.FindGameObjectWithTag("Nickname").GetComponent<TMP_InputField>().text;
        const int leaderboardID = 7127;
        int score = (int)Time.timeSinceLevelLoad;
        
        SetPlayerNick(nickname.Length > 0 ? nickname : "Unknown");
        
        LootLockerSDKManager.SubmitScore(nickname, score, leaderboardID,(response) =>
        {
            if (response.statusCode == 200) {
                Debug.Log("Successful");
            } else {
                Debug.Log("failed: " + response.Error);
            }
        });
        GameManager.LoadMenuScene();
    }
    private static void SetPlayerNick(string nickname){
        LootLockerSDKManager.SetPlayerName(nickname, (response)=>{
            if (response.statusCode == 200) {
                Debug.Log("Successful");
            } else {
                Debug.Log("failed: " + response.Error);
            }
        });
    }
}

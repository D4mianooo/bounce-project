using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Score : MonoBehaviour{
    
    private const float ScoreGainDelay = 1f;
    private const int PointsGainedEverySecond = 10;
    private int score = 0;
    
    private TMP_Text tmpText;
   
   
    private void Awake(){
        
        tmpText = GetComponentInChildren<TMP_Text>();
        
    }
    private void Start() {
        
        InvokeRepeating("AddScore", ScoreGainDelay, ScoreGainDelay);
        
    }
    
    void AddScore(){
        
        score += PointsGainedEverySecond;
        tmpText.text = score.ToString();
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    
    private List<Transform> hearts = new List<Transform>();
    
    private void Start() {
        
        foreach(Transform child in transform){
            
            hearts.Add(child);
            
        }
        
    }
    
    public void UpdateHeartContainer(){
        
        int heartsLength = hearts.Count;
        
        Transform heart = hearts[heartsLength - 1];
        
        heart.gameObject.SetActive(false);
        
        hearts.RemoveAt(heartsLength - 1);
        
    }
    
}

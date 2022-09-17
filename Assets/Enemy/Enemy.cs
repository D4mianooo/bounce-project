using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{

    private HealthUI healthUI;
    
    private void Awake() {
        
        healthUI = GameObject.FindObjectOfType<HealthUI>();
        
    }

    private void OnCollisionEnter(Collision other) {
        
        if(other.gameObject.tag != "Player") return;
        
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        
        int currentPlayerHealth = playerHealth.GetHealth();
        playerHealth.SetHealth(currentPlayerHealth - 1);
        
        healthUI.UpdateHeartContainer();
        
        if(!playerHealth.IsPlayerAlive()){
            Debug.Log("Player is dead");
            //TODO: Pause game, Show score
        }
        
    }
    
    
    

}

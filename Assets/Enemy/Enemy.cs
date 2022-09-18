using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{

    private HealthUI healthUI;
    private DiedUI diedUI;
    
    private void Awake() {
        
        healthUI = GameObject.FindObjectOfType<HealthUI>();
        diedUI = GameObject.FindObjectOfType<DiedUI>();
        
    }

    private void OnCollisionEnter(Collision other) {
        
        if(other.gameObject.tag != "Player") return;
        
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        
        int currentPlayerHealth = playerHealth.GetHealth();
        playerHealth.SetHealth(currentPlayerHealth - 1);
        
        healthUI.UpdateHeartContainer();
        
    }
    

}

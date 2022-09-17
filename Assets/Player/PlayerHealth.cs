using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 3;

    public bool IsPlayerAlive(){
        
        return health > 0;
        
    }

    public int GetHealth(){
        
        return health;
   
    }
    
    public void SetHealth(int health){
        
        this.health = health;
   
    }
    
}

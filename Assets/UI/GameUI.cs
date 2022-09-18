using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour{
    
    private SceneManager _sceneManager;
    
    public void LoadGameplayScene(){
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}

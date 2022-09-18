using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LootLocker.Requests;
public class GameManager : MonoBehaviour{
    private void Start(){
        ProcessLootLockerGuestSession();
    }
    
    private void ProcessLootLockerGuestSession()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {

            if (!response.success)
            {

                Debug.Log("error starting LootLocker session");
                return;

            }

            Debug.Log("successfully started LootLocker session");

        });
    }
    public void ReloadScene(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1f;
    }
}
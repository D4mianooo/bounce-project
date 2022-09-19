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
    public static void LoadMenuScene(){
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    public static void LoadGameplayScene(){
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        Time.timeScale = 1f;
    }
    public static void LoadLeaderboardScene(){
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//for switching scenes
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    //for game over sound

    
    private void Start()
    {
        // Make sure the game over panel is hidden at the start
        gameObject.SetActive(false);
    }
    // Call this method to show the game over screen
    public void ShowGameOverScreen(){
        Debug.Log("show game over called");
        //play end sound
            
        gameObject.SetActive(true); // Show the game over panel
       //Time.timeScale = 0; // Pause the game
    }

    public void NewGameButton(){
        //load starting screen
       // Time.timeScale = 1;
        // SceneManager.LoadScene("SampleScene");
        //SceneManager.LoadScene("SampleScene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

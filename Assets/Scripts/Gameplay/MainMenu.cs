using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Starts the game when the player clicks the start button
    public void StartGame()
    {
        SceneManager.LoadScene("Overworld");
    }    

   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Loads the scene 
    public void LoadEndlessScene()
    {
        SceneManager.LoadScene("EndlessMode");
    }

    public void LoadHillClimbScene()
    {
        SceneManager.LoadScene("HillClimb");
    }

    public void LoadMotorRacingScene()
    {
        SceneManager.LoadScene("MotorRace");
    }


    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
}
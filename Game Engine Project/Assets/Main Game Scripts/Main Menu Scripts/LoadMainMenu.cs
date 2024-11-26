using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoadMainMenu : MonoBehaviour
{
    
    public void LoadScene()
    {
        Debug.Log("Button Pressed");
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
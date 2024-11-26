using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMaze : MonoBehaviour
{
    public void LoadScene()
    {
        Debug.Log("Button Pressed");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Maze");
    }
}

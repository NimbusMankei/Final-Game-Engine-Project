using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoadGameplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene()
    {
        Debug.Log("Button Pressed");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }
}

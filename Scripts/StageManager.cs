using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public void GameStart() {
        SceneManager.LoadScene("TutorialScene");
    }

    public void GameQuit() {
        Debug.Log("halo");
        Application.Quit();
    }
    
}


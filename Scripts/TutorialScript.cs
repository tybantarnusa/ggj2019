using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{

    public Sprite[] pages;
    public int index = 0;

    void Update() {
        GetComponent<SpriteRenderer>().sprite = pages[index];
    }


    public void Next() {
        if (index < 3) {
            index++;
        }
        else {
            SceneManager.LoadScene("GameScene");
        }
    }
}

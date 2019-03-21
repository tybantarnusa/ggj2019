using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public float timer;
    public float playTime = 100;
    public GameObject winText;

    void Start() {
        timer = playTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        string hour = "" + ((int) ((playTime - timer) / (playTime/6f) + 6 + 12));
        if (hour == "24") hour = "00";

        // GameObject.Find("Timer UI").GetComponent<Text>().text = "" + ((int) Mathf.Clamp(timer, 0, 10000));
        GameObject.Find("Timer UI").GetComponent<Text>().text = hour + ":00";
        

        if (timer <= 0) {
            winText.SetActive(true);
        }

        if (timer <= -3) {
            SceneManager.LoadScene("TitleScene");
        }
    }

    public void Lose() {
        timer = 0;
        winText.GetComponent<Text>().text = "You Lose!";
    }
}

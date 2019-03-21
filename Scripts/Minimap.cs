using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minimap : MonoBehaviour
{
    public GameObject roomManager;
    public int roomNumber = 0;

    public int maxGhosts = 5;

    
    private Transform bar;    
    private Text text;

    void Start()
    {
        bar = transform.GetChild(0);    
        text = transform.GetChild(1).gameObject.GetComponent<Text>();
    }

    void Update()
    {
        int ghostsCount = roomManager.GetComponent<RoomManager>().GetGhostsCount(roomNumber);

        float percentFull = Mathf.Clamp(ghostsCount / (float) roomManager.GetComponent<RoomManager>().maxGhosts, 0, 1);
        bar.localScale = new Vector3(bar.localScale.x, Mathf.Lerp(bar.localScale.y, percentFull, 0.2f));

        text.text = "" + ghostsCount;
    }
}

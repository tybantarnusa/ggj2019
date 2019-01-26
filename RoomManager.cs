using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] rooms;
    public float minLightDuration = 5f;
    public float maxLightDuration = 10f;

    private float[] roomsLightTimer;
    private Material lightOnMaterial;
    private Material lightOffMaterial;

    private int[] ghostsCount;


    void Start()
    {
        roomsLightTimer = new float[rooms.Length];
        ghostsCount = new int[rooms.Length];

        for (int i = 0; i < rooms.Length; i++) {
            roomsLightTimer[i] = Random.Range(minLightDuration, maxLightDuration);
        }

        this.lightOnMaterial = new Material(Shader.Find("Sprites/Default"));
        this.lightOffMaterial = new Material(Shader.Find("Legacy Shaders/Diffuse"));
    }

    void Update()
    {
        for (int i = 0; i < roomsLightTimer.Length; i++) {
            // Room is on
            if (roomsLightTimer[i] > 0) {
                roomsLightTimer[i] -= Time.deltaTime;
                rooms[i].GetComponent<Renderer>().material = lightOnMaterial;
                player.GetComponent<Renderer>().material = lightOnMaterial;

            // Room is off
            } else {
                roomsLightTimer[i] = 0;
                rooms[i].GetComponent<Renderer>().material = lightOffMaterial;
                player.GetComponent<Renderer>().material = lightOffMaterial;
            }
        }
    }

    public void TurnOnLight(int roomNumber) {
        rooms[roomNumber].GetComponent<Renderer>().material = lightOnMaterial;
        roomsLightTimer[roomNumber] = Random.Range(minLightDuration, maxLightDuration);
    }

    public bool CanGhostGetIn(int roomNumber) {
        if (roomsLightTimer[roomNumber] > 0) {
            return false;
        }
        return true;
    }

    public int GetGhostsCount(int roomNumber) {
        return ghostsCount[roomNumber];
    }

    public void GhostIn(int roomNumber) {
        ghostsCount[roomNumber]++;
    }
}

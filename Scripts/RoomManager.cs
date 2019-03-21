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
    public int maxGhosts = 5;

    public GameObject[] doors;
    public GameObject[] spawners;


    void Start()
    {
        roomsLightTimer = new float[rooms.Length];
        ghostsCount = new int[rooms.Length];

        for (int i = 0; i < rooms.Length; i++) {
            roomsLightTimer[i] = Random.Range(minLightDuration, maxLightDuration);
        }

        this.lightOnMaterial = new Material(Shader.Find("Sprites/Default"));
        this.lightOffMaterial = new Material(Shader.Find("Transparent/Diffuse"));
    }

    void Update()
    {
        for (int i = 0; i < roomsLightTimer.Length; i++) {
            // Room is on
            if (roomsLightTimer[i] > 0) {
                roomsLightTimer[i] -= Time.deltaTime;
                rooms[i].GetComponent<Renderer>().material = lightOnMaterial;
                player.GetComponent<Renderer>().material = lightOnMaterial;
                for (int j = 0; j < rooms[i].transform.childCount; j++) {
                    GameObject child = rooms[i].transform.GetChild(j).gameObject;
                    Renderer renderer = child.GetComponent<Renderer>();
                    if (renderer != null) {
                        renderer.material = lightOnMaterial;
                    }
                }

            // Room is off
            } else {
                roomsLightTimer[i] = 0;
                rooms[i].GetComponent<Renderer>().material = lightOffMaterial;
                player.GetComponent<Renderer>().material = lightOffMaterial;
                for (int j = 0; j < rooms[i].transform.childCount; j++) {
                    GameObject child = rooms[i].transform.GetChild(j).gameObject;
                    Renderer renderer = child.GetComponent<Renderer>();
                    if (renderer != null) {
                        renderer.material = lightOffMaterial;
                    }
                }
            }
        }



        // Room full
        for (int i = 1; i < rooms.Length; i++) {
            if (ghostsCount[i] >= maxGhosts) {
                if (doors[i] != null && spawners[i].GetComponent<GhostSpawner>().roomNumber != 0) {
                    doors[i].GetComponent<DoorScript>().isDisabled = true;
                    spawners[i].transform.position = new Vector3(0,-5f,0);
                    spawners[i].GetComponent<GhostSpawner>().roomNumber = 0;
                    if (player.GetComponent<Player>().roomNumber == i) {
                        if (i == 1) {
                            player.transform.position = new Vector3(12.65f,1.44f,0);
                        } else if (i == 2) {
                            player.transform.position = new Vector3(0.65f,-7.22f,0);
                        } else if (i == 3) {
                            player.transform.position = new Vector3(-12.56f,1.44f,0);
                        } else if (i == 4) {
                            player.transform.position = new Vector3(0.81f,9f,0);
                        }
                    }
                }
            }
        }

        if (ghostsCount[0] >= maxGhosts && GameObject.Find("GameManager").GetComponent<GameManager>().timer > 0) {
            GameObject.Find("GameManager").GetComponent<GameManager>().Lose();
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
        if (ghostsCount[roomNumber] >= maxGhosts && roomNumber != 0) {
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

    public void GhostKill(int roomNumber) {
        ghostsCount[roomNumber]--;
    }
}

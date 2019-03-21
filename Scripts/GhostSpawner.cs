using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{

    public GameObject ghostPrefab;
    private float timer;
    public int roomNumber = 1;
    public GameObject roomManager;

    public float spawnTime = 5;

    void Start(){
        timer = spawnTime;
    }


    // Update is called once per frame
    void Update()
    {
        this.timer -= Time.deltaTime;
        RoomManager rm = roomManager.GetComponent<RoomManager>();

        if (timer < 0) {
            if (rm.CanGhostGetIn(roomNumber)) {
                GameObject newGhost = Instantiate(ghostPrefab, transform.position, Quaternion.identity) as GameObject;
                newGhost.GetComponent<GhostMovement>().roomNumber = roomNumber;
                rm.GhostIn(roomNumber);
            }
            if (this.roomNumber == 0) {
                timer = Random.Range(1f,2f);
            }
            else {
                timer = Random.Range(2.5f,6f);
            }
        }
    }
}

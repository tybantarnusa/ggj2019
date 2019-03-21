using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public GameObject cam;
    public GameObject player;

    private Rigidbody2D body;
    public float maxSpeed = 5f;
    private float delay;

    private bool dead;

    public int roomNumber;

    public Sprite[] sprites;

    public GameObject roomManager;

    private Vector2 movement;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        delay = Random.Range(0.1f,3f);
        roomManager = GameObject.Find("Rooms");
        cam = GameObject.Find("Main Camera");
        player = GameObject.Find("Player");
        dead = false;
    }


    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        if (delay <= 0)
        {
            movement = new Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f));
            body.velocity = movement * maxSpeed;
            delay = Random.Range(0.1f,3f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        RoomManager rm = roomManager.GetComponent<RoomManager>();

        if (other.gameObject.tag == "attack") {
            GameObject.Find("Hit Sound").GetComponent<AudioSource>().Play();
            cam.GetComponent<CameraController>().Shake(0.2f);
            GetComponent<SpriteRenderer>().sprite = sprites[1];
            int facing = player.GetComponent<Player>().facing;
            if (facing == 1) {
                body.AddForce(new Vector2(3000f,0f));    
            }
            else if (facing == 2) {
                body.AddForce(new Vector2(0f,-3000f));    
            }
            else if (facing == 3) {
                body.AddForce(new Vector2(-3000f,0f));    
            }
            else if (facing == 0) {
                body.AddForce(new Vector2(0f,3000f));    
            }
            if (!dead) {
                rm.GhostKill(roomNumber);
                dead = true;
            }
            Destroy(this.gameObject,0.3f);
        }
    }
}

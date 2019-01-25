using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject cam;

    // Physics variables
    public float speed = 10f;
    private Rigidbody2D body;

    void Start()
    {
        this.body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            cam.GetComponent<CameraController>().Shake();
        }    
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2 (horizontal, vertical);
        body.velocity = movement * speed;
    }
}

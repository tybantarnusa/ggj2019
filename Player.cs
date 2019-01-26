using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject cam;

    private Animator anim;

    // Physics variables
    public float speed = 10f;
    private Rigidbody2D body;

    void Start()
    {
        this.body = GetComponent<Rigidbody2D>();
        this.anim = GetComponent<Animator>();
        GetComponent<Renderer>().material = new Material(Shader.Find("Transparent/Diffuse"));
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

        if (horizontal < 0) {
            transform.GetChild(0).localPosition = new Vector3(-0.83f, 0.3f, -1f);
        } else if (horizontal > 0) {
            transform.GetChild(0).localPosition = new Vector3(0.83f, 0.3f, -1f);
        }

        anim.SetFloat("velocity", horizontal);

        Vector2 movement = new Vector2 (horizontal, vertical);
        body.velocity = movement * speed;
    }
}

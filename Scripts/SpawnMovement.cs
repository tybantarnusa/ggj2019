using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMovement : MonoBehaviour
{

    private Rigidbody2D body;
    public float maxSpeed = 5f;
    private float delay;

    public Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        delay = Random.Range(0.1f,3f);        
    }

    void Update()
    {
        delay -= Time.deltaTime;
        if (delay <= 0)
        {
            movement = new Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f));
            body.AddForce(movement * maxSpeed);
            delay = Random.Range(0.1f,3f);
        }
    }
}

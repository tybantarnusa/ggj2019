using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;

    // Physics variables
    public float speed = 10f;
    private Rigidbody2D body;
    public GameObject attackPrefab;
    public int facing;
    public int roomNumber = 0;

    public GameObject warning;

    void Start()
    {
        this.body = GetComponent<Rigidbody2D>();
        this.anim = GetComponent<Animator>();
        GetComponent<Renderer>().material = new Material(Shader.Find("Transparent/Diffuse"));
        facing = 1;
    }

    void Update()
    {
        anim.SetBool("isAttacking",false);
        if (Input.GetKeyDown(KeyCode.Space)) {
            GameObject newAttack = null;
            if (facing == 1) {
                newAttack = Instantiate(attackPrefab,transform.position + new Vector3(1.19f,-0.02f,0),Quaternion.identity) as GameObject;
            }
            else if (facing == 3) {
                newAttack = Instantiate(attackPrefab,transform.position + new Vector3(-2.152f,-0.062f,0),Quaternion.identity) as GameObject;
            }
            else if (facing == 2) {
                newAttack = Instantiate(attackPrefab,transform.position + new Vector3(-0.4f,-1.5f,0),Quaternion.identity) as GameObject;
            }
            else if (facing == 0) {
                newAttack = Instantiate(attackPrefab,transform.position + new Vector3(-0.46f,1.39f,0),Quaternion.identity) as GameObject;
            }
            newAttack.transform.parent = this.transform;
            anim.SetBool("isAttacking",true);
            //body.AddForce(new Vector2(10000f,0f));  
        }    
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal < 0) {
            transform.GetChild(0).localPosition = new Vector3(-0.83f, 0.3f, -1f);
            facing = 3;
        } else if (horizontal > 0) {
            transform.GetChild(0).localPosition = new Vector3(0.83f, 0.3f, -1f);
            facing = 1;
        } else if (vertical > 0) {
            transform.GetChild(0).localPosition = new Vector3(-0.62f, 0.23f, -1f);
            facing = 0;
        } else if (vertical < 0) {
            transform.GetChild(0).localPosition = new Vector3(0.43f, -0.28f, -1f);
            facing = 2;
        }

        anim.SetFloat("velocity", horizontal);
        anim.SetFloat("velocity_up", vertical);

        Vector2 movement = new Vector2 (horizontal, vertical);
        body.velocity = movement * speed;
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "door") {
            bool doorIsDisabled = other.gameObject.transform.parent.GetComponent<DoorScript>().isDisabled;
            int roomNum = other.gameObject.transform.parent.GetComponent<DoorScript>().roomNumber;

            if (!doorIsDisabled) {
                if (Input.GetKeyDown(KeyCode.Space)) {
                    // Time.timeScale = 0f;

                    Vector3 targetPosition = other.gameObject.transform.GetChild(0).transform.position;
                    transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
                    this.roomNumber = roomNum;
                }
            } else {
                warning.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        warning.SetActive(false);
    }
}

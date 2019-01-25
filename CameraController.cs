using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    // Camera shake variables
    public float shakeDuration = 0f;
    public float shakeAmount = 0.3f;
    public float decreaseFactor = 1.0f;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 playerPosition = player.transform.position;
        transform.position = Vector3.Lerp(transform.position, new Vector3(playerPosition.x, playerPosition.y, transform.position.z), 0.3f);
    
        if (shakeDuration > 0f) {
            transform.localPosition = transform.position + Random.insideUnitSphere * shakeAmount;
            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
    }

    public void Shake() {
        this.shakeDuration = 0.2f;
    }

    public void Shake(float duration) {
        this.shakeDuration = duration;
    }
}

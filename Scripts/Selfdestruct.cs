using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selfdestruct : MonoBehaviour
{
    void Awake() {
        GetComponent<AudioSource>().pitch = Random.Range(1f, 1.5f);
    }
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject,0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

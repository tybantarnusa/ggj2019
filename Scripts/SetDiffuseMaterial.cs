using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDiffuseMaterial : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material = new Material(Shader.Find("Transparent/Diffuse"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

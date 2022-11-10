using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ombra : MonoBehaviour
{
    public Vector3 Pos = new Vector3();
    float posz;
    // Start is called before the first frame update
    void Start()
    {
        posz = Pos.z;   
    }

    // Update is called once per frame
    void Update()
    {
        Pos.z = GameObject.Find("/Player").transform.position.z + posz;
        transform.position = Pos;
    }
}

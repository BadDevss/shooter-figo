using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraHorizon : MonoBehaviour
{
    public int value;

    Camera mainCam;
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = gameObject.GetComponent(typeof(Camera)) as Camera;
        Player = GameObject.Find("/Player");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(mainCam.farClipPlane);
        mainCam.farClipPlane = value + (Player.transform.position.y * 2);
    }
}

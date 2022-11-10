using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ombra : MonoBehaviour
{
    //public Vector3 Pos = new Vector3();
    //float posz;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    posz = Pos.z;   
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    Pos.z = GameObject.FindGameObjectWithTag("Player").transform.position.z + posz;
    //    //Pos.z = GameObject.Find("/Player").transform.position.z + posz;
    //    transform.position = Pos;


    //}

    private Transform _playerTransform;

    private float _zOffset;

    private void Awake()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }

    private void Start()
    {
        _zOffset = Mathf.Abs((_playerTransform.position - transform.position).z);
    }

    private void Update()
    {
        Vector3 currentPos = transform.position;
        currentPos.z = _zOffset + _playerTransform.position.z;
        transform.position = currentPos;
    }

}

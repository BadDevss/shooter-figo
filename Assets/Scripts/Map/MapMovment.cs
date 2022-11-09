using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMovment : MonoBehaviour
{
    [SerializeField] private GameObject previousFloor;
    public GameObject PreviousFloor { get => previousFloor; set => previousFloor = value; }
    [SerializeField] private GameObject nextFloor;

    public GameObject NextFloor { get => nextFloor; set => nextFloor = value; }
    [SerializeField] private float offSet = 45.4f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 currentPos = previousFloor.transform.position;
            currentPos.z += offSet;
            previousFloor.transform.position = currentPos;
            
        }
    }
}

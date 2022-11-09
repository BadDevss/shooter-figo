using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovment : MonoBehaviour
{
    [SerializeField] private GameObject previousFloor;
    public GameObject PreviousFloor { get => previousFloor; set => previousFloor = value; }
    [SerializeField] private GameObject nextFloor;

    public GameObject NextFloor { get => nextFloor; set => nextFloor = value; }
    [SerializeField] private float offSet = 45.4f;

    private BoxCollider _detector;

    public BoxCollider Detector { get => _detector; set => _detector = value; }

    private void Awake()
    {
        _detector = GetComponent<BoxCollider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Flip floors");
            //switch the first floor to the third position
            Vector3 currentPos = previousFloor.transform.position;
            currentPos.z = nextFloor.transform.position.z + offSet;
            previousFloor.transform.position = currentPos;

            //disable this detector
            _detector.enabled = false;

            //enable the detector of the new second floor
            nextFloor.GetComponent<FloorMovment>().Detector.enabled = true;

            previousFloor.GetComponent<FloorMovment>().previousFloor = this.gameObject;
            nextFloor.GetComponent<FloorMovment>().nextFloor = previousFloor;
            nextFloor.GetComponent<FloorMovment>().previousFloor = this.gameObject;
        }
    }
}

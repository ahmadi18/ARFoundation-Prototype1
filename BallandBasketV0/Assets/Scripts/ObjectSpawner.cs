using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject Bin;
    public GameObject Ball;
    public GameObject Slime;
    public GameObject Turtle;

    public float initialspeed = 5;
    public float turtlespeed = 1;
    private float cameraOffset = 0.85f;

    private int objectNumber = 0;

    private PlacementIndicator placementIndicator;
    private GameObject spawnThis;

    void Start()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();
    }

    void Update()
    {

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            
            if (objectNumber==0)
            {
                 PlaceObject(Bin);
            }

            else if (objectNumber == 1)
            {
                PlaceObject(Slime);
            }

            else if (objectNumber == 2)
            {
                PlaceObject(Turtle);
                Rigidbody rb = Turtle.GetComponent<Rigidbody>();
                rb.velocity = Camera.main.transform.forward * turtlespeed;
            }

            else if (objectNumber>2)
            {
                ThrowObject(Ball);
            }

            objectNumber += 1;
        }

    }

    void ThrowObject(GameObject throwObject)
    {

        GameObject obj = Instantiate(throwObject);
        obj.transform.position = Camera.main.transform.position + Camera.main.transform.forward * cameraOffset;
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.velocity = Camera.main.transform.forward * initialspeed;
    }

    void PlaceObject(GameObject placeObject)
    {
        Instantiate(placeObject, placementIndicator.transform.position, placementIndicator.transform.rotation);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField] private GameObject[] waypoints; //keeps array of waypoints moving platforms is bounded by
    private int currentwaypointindex = 0;

    [SerializeField] private float speed = 2f; //speed of platform

    private void Update()
    {
        if (Vector2.Distance(waypoints[currentwaypointindex].transform.position, transform.position) < 0.1f)
        //compares position of waypoint to position of platform
        {
            currentwaypointindex++;
            if (currentwaypointindex >= waypoints.Length)
            {
                currentwaypointindex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentwaypointindex].transform.position, Time.deltaTime * speed);
        //Time.deltaTime allows for something to be frame independant and only depends on time
    }
}

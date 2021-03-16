using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public Transform[] points = new Transform[10];
    public int target;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, points[target % points.Length].position, speed*Time.deltaTime);
        while(Vector3.Distance(transform.position, points[target % points.Length].position) < 0.01f)
        {
            target++;
        }
    }
}

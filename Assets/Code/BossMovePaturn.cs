using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovePaturn : MonoBehaviour
{
    public bool isStarMove = false;
    public Transform[] wayPoints = new Transform[0];
    public int currentWayPointsIndex = 0;

    public float speed = 3f;

    // Update is called once per frame
    void Update()
    {
        if (isStarMove) return;
        
        float distance = Vector3.Distance(transform.position, wayPoints[currentWayPointsIndex].position);
        if (distance <= 0.1f)
        {
            transform.position = wayPoints[currentWayPointsIndex].position;
            currentWayPointsIndex++;
            if (currentWayPointsIndex == wayPoints.Length)
            {
                currentWayPointsIndex = 0;
            }
        }
        Vector3 dir = (wayPoints[currentWayPointsIndex].position - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;
    }
}

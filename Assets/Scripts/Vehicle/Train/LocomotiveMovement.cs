using PathCreation;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class LocomotiveMovement : MonoBehaviour
{
    public PathCreator pathCreator;
    public EndOfPathInstruction endOfPathInstruction;
    public float speed = 0.05f;
    //float distanceTravelled;
    public float startTime = 0;
    float timeTravelled = 0;
    public bool _break = false;

    void Start()
    {
        if (pathCreator != null)
        {
            // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
            pathCreator.pathUpdated += OnPathChanged;
            timeTravelled = startTime;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "waitArea")
        {
            _break = true;
            int countdownDuration = 1;

            Stopwatch stopwatch = Stopwatch.StartNew();  // Geri say�m i�in bir "Stopwatch" nesnesi olu�turun ve ba�lat�n

            while (stopwatch.Elapsed.TotalSeconds < countdownDuration)
            {
                
            }
            _break = false;
        }
    }

    void Update()
    {
        if (pathCreator != null && !_break)
        {
            //distanceTravelled += speed * Time.deltaTime;
            //transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            //transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            timeTravelled += speed * Time.deltaTime;

            transform.position = pathCreator.path.GetPointAtTime(timeTravelled, endOfPathInstruction);
            transform.rotation = pathCreator.path.GetRotation(timeTravelled, endOfPathInstruction);
        }
    }

    // If the path changes during the game, update the distance travelled so that the follower's position on the new path
    // is as close as possible to its position on the old path
    void OnPathChanged()
    {
        //distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
    }
    public float GetCurrentTimeTravelled()
    {
        return timeTravelled;
    }

    public void StopMovement()
    {
        speed = 0;
    }
}

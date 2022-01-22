using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PathFollower : MonoBehaviour
{
    public PathCreator pathCreator;
    public EndOfPathInstruction end;
    public float speed;
    public float rotateSpeed;
    float distanceTravled;

    // Update is called once per frame
    void Update()
    {
        distanceTravled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravled) * Quaternion.Euler(transform.rotation.x, 90, transform.rotation.z); ;
        //transform.eulerAngles = pathCreator.path.GetDirectionAtDistance(distanceTravled);
        // Quaternion angle = pathCreator.path.GetRotationAtDistance(distanceTravled);
        // angle.x = 0;
        // angle.y = 0;
        // angle.z = 90;
        // transform.rotation = angle;
    }
}

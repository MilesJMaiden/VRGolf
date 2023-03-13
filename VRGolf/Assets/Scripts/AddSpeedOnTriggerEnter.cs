using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpeedOnTriggerEnter : MonoBehaviour
{
    public GameManager GameManager;

    public string targetTag;

    private Collider clubCollider;

    //To calculate velocity
    private Vector3 previousPosition;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        previousPosition= transform.position;
        clubCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        //calculate velocity
        velocity = (transform.position - previousPosition) / Time.deltaTime;
        previousPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag(targetTag))
        {
            Debug.Log("Colliding");

            Vector3 collisionPosition = clubCollider.ClosestPoint(other.transform.position);
            //Get Vector3 of the angle/direction between the center of the ball abd the point of collision to determine movement direction
            Vector3 collisionNormal = other.transform.position - collisionPosition;

            //predict ball speed based on velocity of club when ball is hit
            Vector3 projectedVelocity = Vector3.Project(velocity, collisionNormal);

            Rigidbody rb = other.attachedRigidbody;
            rb.velocity = projectedVelocity;

            GameManager.currentHitNumber++;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int currentHoleNumber = 0;

    public List<Transform> startingPositions;

    public Rigidbody ballRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidBody.transform.position = startingPositions[currentHoleNumber].position;

        ballRigidBody.velocity = Vector3.zero;
        ballRigidBody.angularVelocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToNextHole()
    {
        //currentHoleNumber = currentHoleNumber + 1;
        currentHoleNumber += 1;

        if(currentHoleNumber >= startingPositions.Count)
        {
            Debug.Log("End Reached");
        } 
        else
        {
            ballRigidBody.transform.position = startingPositions[currentHoleNumber].position;

            ballRigidBody.velocity = Vector3.zero;
            ballRigidBody.angularVelocity = Vector3.zero;
        }
    }
}

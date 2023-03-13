using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{

    private int currentHoleNumber = 0;

    public List<Transform> startingPositions;

    public Rigidbody ballRigidBody;

    public TMPro.TextMeshPro textMesh;

    public int currentHitNumber = 0;
    private List<int> previousHitNumbers = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        ballRigidBody.transform.position = startingPositions[currentHoleNumber].position;

        ballRigidBody.velocity = Vector3.zero;
        ballRigidBody.angularVelocity = Vector3.zero;

        textMesh.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            GoToNextHole();
        }
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

        previousHitNumbers.Add(currentHitNumber);

        currentHitNumber= 0;

        DisplayScore();
    }

    public void DisplayScore()
    {

        string scoreText = "";

        for (int i = 0; i < previousHitNumbers.Count; i++)
        {
            //Debug.Log("Hole: " + (i + 1) + " - " + previousHitNumbers[i]);
            scoreText += "Hole: " + (i + 1) + " - Hits: " + previousHitNumbers[i] + "<br>";
        }

        textMesh.text = scoreText;
    }
}

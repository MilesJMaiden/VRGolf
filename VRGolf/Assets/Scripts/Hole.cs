using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{

    public GameManager gameManager;
    public string targetTag = "Ball";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(targetTag))
        {
            gameManager.GoToNextHole();
        }
    }
}

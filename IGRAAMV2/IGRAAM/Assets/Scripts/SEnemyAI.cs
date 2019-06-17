using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEnemyAI : MonoBehaviour
{

    Transform playerTransform;
    UnityEngine.AI.NavMeshAgent myNavmesh;


    public float checkRate = 0.0f;

    float nextCheck;
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player").activeInHierarchy)
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        myNavmesh = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;
            FollowPlayer();
        }
            
    }

    void FollowPlayer()
    {
        myNavmesh.transform.LookAt(playerTransform);
        myNavmesh.destination = playerTransform.position;
    }
}

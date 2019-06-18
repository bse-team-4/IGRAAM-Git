using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject Player;
    Transform goal;
    int PartyMemberRadius;
    Vector3 PartyMemberToPlayer;
    Vector3 HalvingVector;
    float DistanceToPlayer;
    public bool ShouldFollowPlayer;
    // Start is called before the first frame update
    void Start()
    {
        ShouldFollowPlayer = true;
        PartyMemberRadius = 3;
        agent = GetComponent<NavMeshAgent>();
        HalvingVector.Set(0.5f, 0.5f, 1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        //Update Mode
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //1 Pressed
            //PartyMember Radius set to attack
            PartyMemberRadius = 10;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //2 Pressed
            //PartyMember Radius set to defense
            PartyMemberRadius = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //3 Pressed
            //Code for setting up third mode goes here
        }


        if (ShouldFollowPlayer == true)
        {
            //Calculate distance to player
            PartyMemberToPlayer = this.transform.position - Player.transform.position;
            DistanceToPlayer = PartyMemberToPlayer.magnitude;
            if (DistanceToPlayer <= PartyMemberRadius)
            {
                //Reset goal in order to stop at a certain distance from the player
                agent.destination = this.transform.position;
            }
            else
            {
                //Party Member's goal gets set to be  the player's position
                agent.destination = Player.transform.position;
            }
        }
        else
        {
            //Don't move towards player
            agent.destination = this.transform.position;
        }
    }
}

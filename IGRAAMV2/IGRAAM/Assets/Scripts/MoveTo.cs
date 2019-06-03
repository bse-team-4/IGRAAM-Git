using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject Player;
    public Transform goal;
    public int PartyMemberRadius;
    Vector3 PartyMemberToPlayer;
    Vector3 HalvingVector;
    float DistanceToPlayer;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        HalvingVector.Set(0.5f, 0.5f, 1f);
        
    }

    // Update is called once per frame
    void Update()
    {

        PartyMemberToPlayer = this.transform.position - Player.transform.position;
        DistanceToPlayer = PartyMemberToPlayer.magnitude;
        if (DistanceToPlayer <= PartyMemberRadius)
        {
            agent.destination = this.transform.position;
        }       
        else
        {
            //Party Member's goal gets set to be half way between the player and its current pos
            //PartyMemberToPlayer.Scale(HalvingVector);
            //agent.destination = PartyMemberToPlayer;
            agent.destination = Player.transform.position;
        }
        
    }
}

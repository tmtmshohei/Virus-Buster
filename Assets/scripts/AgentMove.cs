using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMove : MonoBehaviour
{

    private NavMeshAgent agent;
    private GameObject neardata;
    //  もっとも近い出口
    private GameObject neargate;
    private bool dataarrived;
    private bool gatearrived;

    public GameObject FindClosestData()
    {
        GameObject[] datas;
        datas = GameObject.FindGameObjectsWithTag("data");
        GameObject closestdata = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject data in datas)
        {
            Vector3 diff = data.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closestdata = data;
                distance = curDistance;
            }
        }
        return closestdata;
    }

    public GameObject FindClosestGate()
    {
        GameObject[] gates;
        gates = GameObject.FindGameObjectsWithTag("Gate");
        GameObject closestgate = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject gate in gates)
        {
            Vector3 diff = gate.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closestgate = gate;
                distance = curDistance;
            }
        }
        return closestgate;
    }




	// Use this for initialization
	void Start () 
    {
        agent = GetComponent<NavMeshAgent>();
        dataarrived = false;
        gatearrived = false;
        neardata = FindClosestData();
        neargate = FindClosestGate();
        agent.destination = neardata.transform.position;



	}
	
	// Update is called once per frame
	void Update () 
    {



        if(agent.remainingDistance<2.0f)
        {
            agent.ResetPath();
            neargate = FindClosestGate();
            agent.SetDestination(neargate.transform.position);

        }


        /*
        if(!dataarrived)
        {
            agent.destination=neardata.transform.position;
            if (Vector3.Distance(agent.nextPosition,neardata.transform.position ) < 10.0f)
            {
                Destroy(agent);
                dataarrived = true;
                neargate = FindClosestGate();

            }
        }

        if(dataarrived) 
        {
            agent.destination= neargate.transform.position;
            if(Vector3.Distance(agent.nextPosition, neargate.transform.position) < 10.0f)
            {
                gatearrived = true;
                Destroy(agent);
            }


        }
        */

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class test : MonoBehaviour
{

    private NavMeshAgent agent;
    private GameObject neardata;
    private GameObject neargate;

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
        neardata = FindClosestData();
        neargate = FindClosestGate();
        agent.destination = neardata.transform.position;
        
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        
        if (agent.remainingDistance<1.0f)
        {
            Debug.Log("a");
            agent.ResetPath();
            neargate = FindClosestGate();
            agent.SetDestination(neargate.transform.position);



        }


	}
}

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
    private float data;
    private float gate;
    private float far2data;
    private float far2gate;
    public float dist;

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
        //neargate = FindClosestGate();
        //agent.destination = neardata.transform.position;
        agent.SetDestination(neardata.transform.position);

        //data = agent.destination;



	}
	
	// Update is called once per frame
	void Update () 
    {

        far2data = Dist(agent);

        if(far2data<7.0f)
        {
            //Debug.Log(far2data);
            //agent.ResetPath();
            neargate = FindClosestGate();
            agent.ResetPath();
            dataarrived = true;
            //Debug.Log("true");
            //agent.destination=neargate.transform.position;
            
        }

        Gotogate();




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

    public float Dist(NavMeshAgent target)
    {
        NavMeshPath path = target.path;
        dist = 0.0f;
        Vector3 now = transform.position;
        for (int i = 0; i < path.corners.Length;i++)
        {
            Vector3 conrner1 = path.corners[i];
            dist += Vector3.Distance(now,conrner1);
            now = conrner1;

        }
        return dist;

    }

    void Gotogate()
    {
        if (dataarrived == true)
        {
            agent.SetDestination(neargate.transform.position);
            far2gate = Dist(agent);
            //Debug.Log(far2gate);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Gate")
        {
            gameObject.SetActive(false);
            return;
        }
    }

}

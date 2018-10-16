using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class test : MonoBehaviour
{

    private NavMeshAgent agent;
    private GameObject neardata;
    private GameObject neargate;
    public float dist;
    public bool hoge;
    NavMeshPath path1;

	// Use this for initialization
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        neardata = FindClosestData();
        agent.destination = neardata.transform.position;
        hoge = false;
        path1 = new NavMeshPath();
	}

	void Update () 
    {
        /*if (Input.GetKey("up") && this.gameObject.tag == "enemy")
        {
            //Destroy(this.gameObject);
            gameObject.SetActive(false);
            return;
        }*/
        
        if (Dist(agent,neardata)<2.0f && hoge==false)
        {
            Debug.Log("a");
            //gameObject.SetActive(false);
            //Destroy(this.gameObject);
            agent.ResetPath();
            hoge = true;

            //neargate = FindClosestGate();
            //agent.SetDestination(neargate.transform.position);

        }
        if (hoge == true)
        {
            //Set(agent);
            neargate = FindClosestGate();
            agent.destination = neargate.transform.position;
            //Debug.Log(agent.destination);
        }



	}



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

    public float Dist(NavMeshAgent target ,GameObject obj)
    {
        
        target.destination = obj.transform.position;
        NavMeshPath path = target.path;

        dist = 0.0f;
        Vector3 now = transform.position;
        for (int i = 0; i < path.corners.Length; i++)
        {
            Vector3 conrner1 = path.corners[i];
            dist += Vector3.Distance(now, conrner1);
            now = conrner1;
        }
        return dist;
    }

    public void Set(NavMeshAgent target)
    {
        
        neargate = FindClosestGate();
        NavMesh.CalculatePath(gameObject.transform.position, neargate.transform.position, NavMesh.AllAreas, path1);
        target.destination = neargate.transform.position;
        target.SetPath(path1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //GameObject a = GameObject.FindWithTag("GATE");
        if(collision.gameObject.tag=="Gate")
        {
            Debug.Log("hit");
            gameObject.SetActive(false);
        }
    }




}

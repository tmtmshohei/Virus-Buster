using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class todata : MonoBehaviour {

    //敵キャラ
    private CharacterController enemyController;
    //private NavMeshAgent agent;
    //　もっとも近いデータ
    private GameObject neardata;
    //  もっとも近い出口
    private GameObject neargate;
    //　歩くスピード
    [SerializeField]
    private float walkSpeed = 1.0f;
    //　速度
    private Vector3 velocity;
    //　移動方向
    private Vector3 direction;
    private bool dataarrived;
    private bool gatearrived;

    public  GameObject FindClosestData()
    {
        GameObject[] datas;
        datas = GameObject.FindGameObjectsWithTag("data");
        GameObject closestdata = null;
        float distance = Mathf.Infinity;
        Vector3 position =  transform.position;
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
        gates = GameObject.FindGameObjectsWithTag("gate");
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
        enemyController = GetComponent<CharacterController>();
        //agent = GetComponent<NavMeshAgent>();
        neardata = FindClosestData();
        neargate = FindClosestGate();
        velocity = Vector3.zero;
        dataarrived = false;
        gatearrived = false;

	}
	
	// Update is called once per frame
	void Update () 
    {
		if(!dataarrived)
        {
            velocity = Vector3.zero;
            direction = (neardata.transform.position - transform.position).normalized;
            velocity = direction * walkSpeed;
            velocity.y += Physics.gravity.y * Time.deltaTime;
            enemyController.Move(velocity * Time.deltaTime);

        }
        if (Vector3.Distance(transform.position, neardata.transform.position) < 0.4f)
        {
            dataarrived = true;
            velocity = Vector3.zero;
            direction = (neargate.transform.position - transform.position).normalized;
            velocity = direction * walkSpeed;
            velocity.y += Physics.gravity.y * Time.deltaTime;
            enemyController.Move(velocity * Time.deltaTime);

        }


	}
}

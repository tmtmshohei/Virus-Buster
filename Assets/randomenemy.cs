using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomenemy : MonoBehaviour
{

    public GameObject[] DoubutuT;
    public GameObject dropanimal;
    public float timeOut;
    public float timeElapsed;

	// Use this for initialization
	void Start ()
    {
        timeOut = Random.Range(1.0f, 5.0f);
	}
	
	// Update is called once per frame
	void Update () 
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeOut)
        {
            dropanimal = DoubutuT[Random.Range(0, DoubutuT.Length)];
            Instantiate(dropanimal, transform.position, transform.rotation);
            timeElapsed = 0.0f;
        }
	}
}

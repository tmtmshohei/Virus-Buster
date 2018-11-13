using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Elapsed_TIme : MonoBehaviour 
{
	Text obj;
	float time_offset = 0;
	float time = 30.0f;
	void Start () 
	{
		obj = GetComponent<Text>();
	}
	
	void Update () 
	{
		time_offset += Time.deltaTime;
		obj.text = (time-time_offset).ToString("f1");
		if(time-time_offset<=0){obj.text = 0.ToString();}
	}

	
}

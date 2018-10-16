using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCount : MonoBehaviour {

    private GameObject enemy; 
    private CreateEnemy enemynum;
    private TextMesh text;
    public bool restart_flag;
    private GameObject[] enemycount;

	// Use this for initialization
	void Start () 
    {
        enemy = GameObject.Find("DATA1");
        text = GetComponent<TextMesh>();
        restart_flag = false;


	}

    // Update is called once per frame
    void Update()
    {
        enemycount = GameObject.FindGameObjectsWithTag("enemy");
        text.text = Checkenemy(enemycount);
        //enemynum = enemy.GetComponent<CreateEnemy>();
        //text.text = enemynum.numberOfEnemys.ToString();
        if(enemynum.numberOfEnemys>300)
        {
            restart_flag = true;
        }
        if(restart_flag==true)
        {
            SceneManager.LoadScene("VirusBuster");
        }

    }

    string Checkenemy(GameObject[] enemys)
    {
        int count = enemys.Length/2;
        if(count >0)
        {
            return count.ToString();
        }
        else{
            return 0.ToString();
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour {
 
    //　出現させる敵を入れておく
    [SerializeField] GameObject[] enemys;
    //　次に敵が出現するまでの時間
    [SerializeField] float appearNextTime;
    //　この場所から出現する敵の数
    [SerializeField] int maxNumOfEnemys;
    //　今何人の敵を出現させたか
    public int numberOfEnemys;
    public GameObject enemy_tags;
    //　待ち時間計測フィールド
    private float elapsedTime;
    //  出現させる座標
    private Vector3 pos;
    private float posx;
    private float posy;
    private float posz;

    // Use this for initialization
	void Start () 
    {
        numberOfEnemys = 0;
        elapsedTime = 0f;

	}
	
	// Update is called once per frame
	void Update ()
    {
        //　この場所から出現する最大数を超えてたら何もしない
        if (numberOfEnemys >= maxNumOfEnemys)
        {
            return;
        }
        //　経過時間を足す
        elapsedTime += Time.deltaTime;
        //　経過時間が経ったら
        if (elapsedTime > appearNextTime)
        {
            elapsedTime = 0f;

            AppearEnemy();
        }
	}

    //　敵出現メソッド
    void AppearEnemy()
    {
        //　出現させる敵をランダムに選ぶ
        var randomValue = Random.Range(0, enemys.Length);
        //　敵の向きをランダムに決定
        var randomRotationY = Random.value * 360f;

        posx=Random.Range(-30.0f, 30.0f);
        posy = 3.0f;
        posz = Random.Range(-30.0f, 30.0f);                 
        pos = new Vector3(posx, posy, posz);

        enemy_tags = Instantiate(enemys[randomValue],pos, Quaternion.Euler(0f, randomRotationY, 0f));
        enemy_tags.tag = "enemy";


        numberOfEnemys++;
        elapsedTime = 0f;
    }
}

//プレハブの中に入っている最初のenemyを削除すると、そのあとに敵の生成がされなくなるのかもしれない
//RaycastのスクリプトをDestroyではなくアクティブ、非アクティブに変更するなど


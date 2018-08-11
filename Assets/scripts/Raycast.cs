using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour 
{

    [SerializeField]
    private Transform _RightHandAnchor;

    [SerializeField]
    private Transform _LeftHandAnchor;

    [SerializeField]
    private Transform _CenterEyeAnchor;

    [SerializeField]
    private float _MaxDistance = 100.0f;

    [SerializeField]
    private LineRenderer _LaserPointerRenderer;

    private GameObject Reticle;
    private Quaternion Defrotation;
    private Vector3 Defpoint;

  
    private Transform Pointer
    {
        get
        {
            // 現在アクティブなコントローラーを取得
            var controller = OVRInput.GetActiveController();
            if (controller == OVRInput.Controller.RTrackedRemote)
            {
                return _RightHandAnchor;
            }
            else if (controller == OVRInput.Controller.LTrackedRemote)
            {
                return _LeftHandAnchor;
            }
            // どちらも取れなければ目の間からビームが出る
            return _CenterEyeAnchor;
        }
    }

    private void Start()
    {
        Reticle = GameObject.Find("Reticle");
        Defpoint = Reticle.transform.position; 
        Defrotation = Reticle.transform.rotation; 
    }

    // Update is called once per frame
    void Update () 
    {
        var pointer = Pointer;
        if (pointer == null || _LaserPointerRenderer == null)
        {
            return;
        }
        // コントローラー位置からRayを飛ばす
        Ray pointerRay = new Ray(pointer.position, pointer.forward);

        // レーザーの起点
        _LaserPointerRenderer.SetPosition(0, pointerRay.origin);

        RaycastHit hit;
        if (Physics.Raycast(pointerRay, out hit, _MaxDistance))
        {
            // Rayがヒットしたらそこまで
            _LaserPointerRenderer.SetPosition(1, hit.point);
            Reticle.transform.position = hit.point;
            Reticle.transform.rotation = Quaternion.LookRotation(hit.normal);
            //トリガーを引いて、敵に当たると消滅させる
            if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && hit.collider.tag=="enemy")
            {
                Destroy(hit.collider.gameObject);
            }
        }
        else
        {
            // Rayがヒットしなかったら向いている方向にMaxDistance伸ばす
            _LaserPointerRenderer.SetPosition(1, pointerRay.origin + pointerRay.direction * _MaxDistance);
            Reticle.transform.position =new Vector3(0,Defpoint.y,0);
            Reticle.transform.rotation = Defrotation;
        }
	}
}

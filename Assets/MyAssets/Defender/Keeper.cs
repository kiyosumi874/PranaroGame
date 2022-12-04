using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Keeper : MonoBehaviour
{
    //スピード（調整用）
    [Tooltip("移動速度調整")]
    [SerializeField] float speed;

    [Tooltip("移動幅")]
    [SerializeField] float maxMoved;

    [Tooltip("再POPの時間")]
    [SerializeField] float rePop;

    //DefenderのRidid
    //[SerializeField] Rigidbody rigidbody;

    //消滅管理のBool
    bool checkDestroy = false;

    Vector3 pos ;

    private void Start()
    {
        pos = transform.position;
        //rigidbody = GetComponent<Rigidbody>();
    }


    //参考：https://mono-pro.net/archives/7669
    private void FixedUpdate()
    {
       
        transform.position = new Vector3(pos.x + Mathf.PingPong(Time.time * speed, maxMoved), pos.y, pos.z);

    }

    //ボールに当たったら消滅
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.transform.tag=="ball")
    //    {
    //        this.gameObject.SetActive(false);
    //        checkDestroy = true;

    //        var pos = transform.position;
    //
    //        //時間差で復活させる
    //        DOVirtual.DelayedCall(rePop, ()=> { SetPopDefender(pos); }
    //        );
    //    }
    //}

    private void SetPopDefender(Vector3 pos)
    {
        this.gameObject.SetActive(true);

        this.gameObject.transform.position = pos;
        checkDestroy = false;
        Debug.Log("再POP");
    }

}

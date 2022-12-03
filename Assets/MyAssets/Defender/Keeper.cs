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
    [SerializeField] Rigidbody rigidbody;

    //消滅管理のBool
    bool checkDestroy = false;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


    //参考：https://3dcg-school.pro/unity-object-move-beginner/#Rigidbody
    private void FixedUpdate()
    {
       var pos = rigidbody.transform.position;

        //checkDestroyがONの時は処理を行わない
        if (checkDestroy)
        {
            return;
        }

        //X座標がMAX値より小さい場合
        if (pos.x < maxMoved)
        {
            //指定したスピードから現在の速度を引いて加速力を求める
            float currentSpeed = speed - rigidbody.velocity.magnitude;
            //調整された加速力で力を加える
            rigidbody.AddForce(new Vector3(currentSpeed, 0, 0));


        } //X座標がMAX値より大きい場合
        else if (pos.x >= maxMoved)
        {
            //指定したスピードから現在の速度を引いて加速力を求める
            float currentSpeed = speed - rigidbody.velocity.magnitude;
            //調整された加速力で力を加える
            rigidbody.AddForce(new Vector3(-currentSpeed, 0, 0));
        }
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

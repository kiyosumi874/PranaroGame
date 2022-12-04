using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Defender : MonoBehaviour
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

    Vector3 pos;
    //消滅管理のBool
    bool checkDestroy = false;

    private void Start()
    {
        pos = transform.position;
    }


    //参考：https://3dcg-school.pro/unity-object-move-beginner/#Rigidbody
    private void FixedUpdate()
    {
        //Transform myTransform = transform;
        //Vector3 pos = myTransform.position;
        
        //checkDestroyがONの時は処理を行わない
        if (checkDestroy)
        {
            return;
        }

        transform.position = new Vector3(pos.x + Mathf.PingPong(Time.time*speed, maxMoved), pos.y, pos.z);

        //X座標がMAX値より小さい場合
        //if (pos.x < defoultXpos + maxMoved)
        //{
        //  pos.x += speed * Time.deltaTime;
        //   myTransform.position = pos;

        //} //X座標がMAX値より大きい場合
        //else if (pos.x > defoultXpos)
        //{
        //  pos.x -= speed * Time.deltaTime;
        //  myTransform.position = pos;

        //指定したスピードから現在の速度を引いて加速力を求める
        //float currentSpeed = speed - GetComponent<Rigidbody>().velocity.magnitude;
        //調整された加速力で力を加える
        //GetComponent<Rigidbody>().AddForce(new Vector3(-currentSpeed * randSp, 0, 0));
        //}
    }

    //ボールに当たったら消滅
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag== "SoccerBall")
        {
            this.gameObject.SetActive(false);
            checkDestroy = true;

            var pos = transform.position;

            //時間差で復活させる
            DOVirtual.DelayedCall(rePop, ()=> { SetPopDefender(pos); }
            );
        }
    }

    private void SetPopDefender(Vector3 pos)
    {
        this.gameObject.SetActive(true);

        this.gameObject.transform.position = pos;
        checkDestroy = false;
        Debug.Log("再POP");
    }

}

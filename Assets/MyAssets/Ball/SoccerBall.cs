using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SoccerBall : MonoBehaviour
{
    [SerializeField] private SoundPlayer reflectSound = null;
    //[SerializeField] private GameObject effectPrefab;
    [Header("本番用のData")]
    [SerializeField] private SoccerBallParamAsset data = null;

    [Space(20)]

    [Header("trueにするとDebug用の値が使用される")]
    [SerializeField] bool isDebug = false;

    [Header("最初にボールを狙うポジション(Debug用)")]
    [SerializeField] private Vector3 debugAimPos;

    [Header("ボールのspeed(Debug用)")]
    [SerializeField] private float debugSpeed;

    [Header("失敗したときのロスタイム(Debug用)")]
    [SerializeField] private float debugLossTimeFaild = 1.0f;

    [Header("ゴールを決めた時のロスタイム(Debug用)")]
    [SerializeField] private float debugLossTimeSuccess = 0.5f;


    private Vector3 aimPos;
    private Vector3 initPos;
    private float speed;
    private float lossTimeFaild;
    private float lossTimeSuccess;

    public float Speed => speed;

    private Dictionary<State, Action> stateFuncs;

    private Vector3 destinationVecNorm; // 目的地に進む正規化されたベクトル
    private Rigidbody rigidbody;

    public enum State
    {
        Idle,
        Run,
        Init,
        InitLoss,
        Wait,
        End
    };

    private State state;

    public void SetState(State state)
    {
        this.state = state;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (isDebug)
        {
            aimPos = debugAimPos;
            speed = debugSpeed;
            lossTimeFaild = debugLossTimeFaild;
            lossTimeSuccess = debugLossTimeSuccess;
        }
        else
        {
            aimPos = data.AimPos;
            speed = data.Speed;
            lossTimeFaild = data.LossTimeFaild;
            lossTimeSuccess = data.LossTimeSuccess;
        }
        initPos = this.transform.position;
        rigidbody = GetComponent<Rigidbody>();
        destinationVecNorm = new Vector3();
        destinationVecNorm = Vector3.Normalize(aimPos - transform.position);
        stateFuncs = new Dictionary<State, Action>();
        stateFuncs[State.Idle] = UpdateStateIdle;
        stateFuncs[State.Run] = UpdateStateRun;
        stateFuncs[State.Init] = UpdateStateInit;
        stateFuncs[State.Wait] = UpdateStateWait;
        stateFuncs[State.End] = UpdateStateEnd;
        stateFuncs[State.InitLoss] = UpdateStateInitLoss;
        state = State.Wait;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDebug)
        {
            aimPos = debugAimPos;
            speed = debugSpeed;
            lossTimeFaild = debugLossTimeFaild;
            lossTimeSuccess = debugLossTimeSuccess;
        }
        // ステート管理関数
        StateManager();
        // 今のstateに対応する関数が呼ばれるDictionary
        stateFuncs[state]();
    }

    private void StateManager()
    {

    }

    // 七種類のポジションにランダムで発射
    private void ForceTheBall()
    {
        var rand = new System.Random((int)Time.time);
        Vector3 pos = aimPos;
        switch (rand.Next(0, 7))
        {
            case 0:
                pos.x += -1.0f;
                break;
            case 1:
                pos.x += 1.0f;
                break;
            case 2:
                pos.x += -2.0f;
                break;
            case 3:
                pos.x += 2.0f;
                break;
            case 4:
                pos.x += -3.0f;
                break;
            case 5:
                pos.x += 3.0f;
                break;
            default:
                break;
        }
        destinationVecNorm = Vector3.Normalize(pos - transform.position);
        //rigidbody.AddTorque(-destinationVecNorm.x * speed * 100.0f, 0.0f, -destinationVecNorm.z * speed * 100.0f);

        rigidbody.AddForce(destinationVecNorm.x * speed * 100.0f, 0.0f, destinationVecNorm.z * speed * 100.0f);
    }

    private IEnumerator WaitTime(float time,State state)
    {
        yield return new WaitForSeconds(time);
        this.state = state;
    }

    //-------------------
    // IdleState
    //-------------------
    private void UpdateStateIdle()
    {
        ForceTheBall();
        state = State.Run;
    }

    //-------------------
    // RunState
    //-------------------

    private void UpdateStateRun()
    {
    }

    //-------------------
    // InitState
    //-------------------
    private void UpdateStateInit()
    {
        rigidbody.velocity = Vector3.zero;
        //rigidbody.angularVelocity = Vector3.zero;
        this.transform.position = initPos;
        state = State.Wait;
        StartCoroutine(WaitTime(lossTimeSuccess, State.Idle));
    }

    private void UpdateStateInitLoss()
    {
        rigidbody.velocity = Vector3.zero;
        //rigidbody.angularVelocity = Vector3.zero;
        this.transform.position = initPos;
        state = State.Wait;
        StartCoroutine(WaitTime(lossTimeFaild, State.Idle));
    }

    //-------------------
    // WaitState
    //-------------------
    private void UpdateStateWait()
    {
    }

    //-------------------
    // EndState
    //-------------------
    private void UpdateStateEnd()
    {
        rigidbody.velocity = Vector3.zero;
        //rigidbody.angularVelocity = Vector3.zero;
        this.enabled = false;
    }

    //public void OnCollisionEnter(Collision collision)
    //{
    //    rigidbody.angularVelocity = Vector3.zero;
    //    rigidbody.AddTorque(GetDirection().x * speed * -100.0f, 0.0f, GetDirection().z * speed * -100.0f);
    //}


    private Vector3 GetDirection()
    {
        return Vector3.Normalize(rigidbody.velocity);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerGoal") || other.CompareTag("EnemyGoal"))
        {
            return;
        }
        reflectSound.Play();
    }

    public void OnCollisionEnter(Collision collision)
    {
        reflectSound.Play();
        //var tran = this.transform;
        //tran.localScale = new Vector3(2.0f, 2.0f, 1.0f);
        //Instantiate(effectPrefab, tran);
    }
}

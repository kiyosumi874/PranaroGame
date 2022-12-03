using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SoccerBall : MonoBehaviour
{
    [Header("本番用のData")]
    [SerializeField] private SoccerBallParamAsset data = null;

    [Space(20)]

    [Header("trueにするとDebug用の値が使用される")]
    [SerializeField] bool isDebug = false;

    [Header("最初にボールを狙うポジション(Debug用)")]
    [SerializeField] private Vector3 debugAimPos;

    [Header("ボールのspeed(Debug用)")]
    [SerializeField] private float debugSpeed;

    private Vector3 aimPos;
    private Vector3 initPos;
    private float speed;

    private Dictionary<State, Action> stateFuncs;

    private Vector3 destinationVecNorm; // 目的地に進む正規化されたベクトル
    private Rigidbody rigidbody;

    public enum State
    {
        Idle,
        Run,
        Init,
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
        }
        else
        {
            aimPos = data.AimPos;
            speed = data.Speed;
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
        state = State.Wait;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDebug)
        {
            aimPos = debugAimPos;
            speed = debugSpeed;
        }
        // ステート管理関数
        StateManager();
        // 今のstateに対応する関数が呼ばれるDictionary
        stateFuncs[state]();
    }

    private void StateManager()
    {

    }

    private void ForceTheBall()
    {
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
        this.transform.position = initPos;
        state = State.Wait;
        StartCoroutine(WaitTime(0.5f, State.Idle));
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
        this.enabled = false;
    }
}

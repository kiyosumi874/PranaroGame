using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SoccerBall : MonoBehaviour
{
    [Header("�{�ԗp��Data")]
    [SerializeField] private SoccerBallParamAsset data = null;

    [Space(20)]

    [Header("true�ɂ����Debug�p�̒l���g�p�����")]
    [SerializeField] bool isDebug = false;

    [Header("�ŏ��Ƀ{�[����_���|�W�V����(Debug�p)")]
    [SerializeField] private Vector3 debugAimPos;

    [Header("�{�[����speed(Debug�p)")]
    [SerializeField] private float debugSpeed;

    [Header("���s�����Ƃ��̃��X�^�C��(Debug�p)")]
    [SerializeField] private float debugLossTimeFaild = 1.0f;

    [Header("�S�[�������߂����̃��X�^�C��(Debug�p)")]
    [SerializeField] private float debugLossTimeSuccess = 0.5f;

    private Vector3 aimPos;
    private Vector3 initPos;
    private float speed;
    private float lossTimeFaild;
    private float lossTimeSuccess;

    private Dictionary<State, Action> stateFuncs;

    private Vector3 destinationVecNorm; // �ړI�n�ɐi�ސ��K�����ꂽ�x�N�g��
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
        // �X�e�[�g�Ǘ��֐�
        StateManager();
        // ����state�ɑΉ�����֐����Ă΂��Dictionary
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
        StartCoroutine(WaitTime(lossTimeSuccess, State.Idle));
    }

    private void UpdateStateInitLoss()
    {
        rigidbody.velocity = Vector3.zero;
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
        this.enabled = false;
    }
}

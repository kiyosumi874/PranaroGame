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

    private Vector3 aimPos;
    private Vector3 initPos;
    private float speed;

    private Dictionary<State, Action> stateFuncs;

    private Vector3 destinationVecNorm; // �ړI�n�ɐi�ސ��K�����ꂽ�x�N�g��
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

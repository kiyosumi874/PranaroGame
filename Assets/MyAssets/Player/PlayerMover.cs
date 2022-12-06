using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private GameObject leftPlayer = null;
    [SerializeField] private GameObject rightPlayer = null;

    [Header("本番用のData")]
    [SerializeField] private PlayerParamAsset data = null;

    [Space(20)]

    [Header("trueにするとDebug用の値が使用される")]
    [SerializeField] bool isDebug = false;

    [Header("Playerを動かす速度(Debug用)")]
    [SerializeField] private float debugSpeedMax = 1.0f;

    [Header("Playerが動ける範囲(Debug用)")]
    [SerializeField] private float debugMoveRange = 1.0f;

    


    private float speedMax = 1.0f;
    private float moveRange = 1.0f;
    private float startPos = 0.0f;
    private enum Direction
    {
        Right,
        Left,
        None
    }

    private Direction direction = Direction.None;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        if (isDebug)
        {
            speedMax = debugSpeedMax;
            moveRange = debugMoveRange;
        }
        else
        {
            speedMax = data.SpeedMax;
            moveRange = data.MoveRange;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDebug)
        {
            speedMax = debugSpeedMax;
            moveRange = debugMoveRange;
        }
        if (IsMove())
        {
            var speed = InputPlayerSpeed() * Time.deltaTime;
            transform.Translate(speed, 0.0f, 0.0f);
        }
        else
        {
            if ((!Input.GetKey(KeyCode.RightArrow) && direction == Direction.Right) || (!Input.GetKey(KeyCode.LeftArrow) && direction == Direction.Left))
            {
                // ここの引数をどちらに移動制限がかかったかで決める
                FixPos(direction);
            }
            
        }
    }

    // 入力されたPlayerのSpeedをfloatで返す
    private float InputPlayerSpeed()
    {
        float speed = 0.0f;
        if (Input.GetKey(KeyCode.RightArrow) && direction == Direction.None)
        {
            speed = speedMax;
            rightPlayer.SetActive(true);
            leftPlayer.SetActive(false);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && direction == Direction.None)
        {
            speed = -speedMax;
            rightPlayer.SetActive(false);
            leftPlayer.SetActive(true);
        }
        return speed;
    }

    private bool IsMove()
    {
        int count = 0;
        if (startPos - moveRange < this.transform.position.x)
        {
            count++;
        }
        else
        {
            direction = Direction.Left;
        }

        if (this.transform.position.x < startPos + moveRange)
        {
            count++;
        }
        else
        {
            direction = Direction.Right;
        }

        if (count == 2)
        {
            direction = Direction.None;
            return true;
        }

        return false;
    }



    private void FixPos(Direction direction)
    {
        switch (direction)
        {
            case Direction.Right:
                transform.Translate(-0.001f, 0.0f, 0.0f);
                break;
            case Direction.Left:
                transform.Translate(0.001f, 0.0f, 0.0f);
                break;
            default:
                break;
        }

        if (!IsMove())
        {
            FixPos(direction);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SoccerBall"))
        {
            var posX = other.GetComponent<SoccerBall>().transform.position.x;
            var diffX = this.transform.position.x - posX;
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Vector3 vec = Vector3.zero;
            
            if (diffX < -2.0f)
            {
                vec.x = 0.5f;
                vec.y = 0.0f;
                vec.z = 0.5f;
            }
            else if (diffX > 2.0f)
            {

                vec.x = -0.5f;
                vec.y = 0.0f;
                vec.z = 0.5f;
            }
            else if (diffX < -1.5f)
            {
                vec.x = 0.4f;
                vec.y = 0.0f;
                vec.z = 0.6f;
            }
            else if (diffX > 1.5f)
            {

                vec.x = -0.4f;
                vec.y = 0.0f;
                vec.z = 0.6f;
            }
            else if (diffX < -1.0f)
            {
                vec.x = 0.3f;
                vec.y = 0.0f;
                vec.z = 0.7f;
            }
            else if (diffX > 1.0f)
            {

                vec.x = -0.3f;
                vec.y = 0.0f;
                vec.z = 0.7f;
            }
            else if (diffX < -0.5f)
            {

                vec.x = 0.2f;
                vec.y = 0.0f;
                vec.z = 0.8f;
            }
            else if (diffX > 0.5f)
            {

                vec.x = -0.2f;
                vec.y = 0.0f;
                vec.z = 0.8f;
            }
            else
            {
                vec.x = 0.0f;
                vec.y = 0.0f;
                vec.z = 1.0f;
            }
            //other.GetComponent<Rigidbody>().AddTorque(Vector3.Normalize(vec).x * -1000.0f,0.0f, Vector3.Normalize(vec).z * -1000.0f);
            other.GetComponent<Rigidbody>().AddForce(Vector3.Normalize(vec) * other.GetComponent<SoccerBall>().Speed * 100.0f);
        }
    }
}




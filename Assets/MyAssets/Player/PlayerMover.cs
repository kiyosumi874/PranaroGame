using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
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
        }
        if (Input.GetKey(KeyCode.LeftArrow) && direction == Direction.None)
        {
            speed = -speedMax;
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
}

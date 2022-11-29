using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data",menuName = "ScriptableObjects/CreatePlayerParamAsset")]
public class PlayerParamAsset : ScriptableObject
{
    [Header("Playerを動かす速度")]
    [SerializeField] private float speedMax = 1.0f;

    [Header("Playerが動ける範囲")]
    [SerializeField] private float moveRange = 1.0f;

    // speedのgetter(ラムダ式を利用し色々省略している)
    public float SpeedMax => speedMax;

    // moveRangeのgetter
    public float MoveRange => moveRange;
}

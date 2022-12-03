using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CreateSoccerBallParamAsset")]
public class SoccerBallParamAsset : ScriptableObject
{
    [Header("最初にボールを狙うポジション")]
    [SerializeField] private Vector3 aimPos = Vector3.zero;

    [Header("ボールのspeed")]
    [SerializeField] private float speed = 1.0f;

    [Header("失敗したときのロスタイム")]
    [SerializeField] private float lossTimeFaild = 1.0f;

    [Header("ゴールを決めた時のロスタイム")]
    [SerializeField] private float lossTimeSuccess = 0.5f;
    // aimPosのgetter(ラムダ式を利用し色々省略している)
    public Vector3 AimPos => aimPos;

    // speedのgetter
    public float Speed => speed;

    public float LossTimeFaild => lossTimeFaild;
    public float LossTimeSuccess => lossTimeSuccess;
}

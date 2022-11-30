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

    // aimPosのgetter(ラムダ式を利用し色々省略している)
    public Vector3 AimPos => aimPos;

    // speedのgetter
    public float Speed => speed;
}

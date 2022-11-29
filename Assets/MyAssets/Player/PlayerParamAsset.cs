using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data",menuName = "ScriptableObjects/CreatePlayerParamAsset")]
public class PlayerParamAsset : ScriptableObject
{
    [Header("Player�𓮂������x")]
    [SerializeField] private float speedMax = 1.0f;

    [Header("Player��������͈�")]
    [SerializeField] private float moveRange = 1.0f;

    // speed��getter(�����_���𗘗p���F�X�ȗ����Ă���)
    public float SpeedMax => speedMax;

    // moveRange��getter
    public float MoveRange => moveRange;
}

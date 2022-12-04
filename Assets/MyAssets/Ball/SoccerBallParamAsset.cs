using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CreateSoccerBallParamAsset")]
public class SoccerBallParamAsset : ScriptableObject
{
    [Header("�ŏ��Ƀ{�[����_���|�W�V����")]
    [SerializeField] private Vector3 aimPos = Vector3.zero;

    [Header("�{�[����speed")]
    [SerializeField] private float speed = 1.0f;

    [Header("���s�����Ƃ��̃��X�^�C��")]
    [SerializeField] private float lossTimeFaild = 1.0f;

    [Header("�S�[�������߂����̃��X�^�C��")]
    [SerializeField] private float lossTimeSuccess = 0.5f;
    // aimPos��getter(�����_���𗘗p���F�X�ȗ����Ă���)
    public Vector3 AimPos => aimPos;

    // speed��getter
    public float Speed => speed;

    public float LossTimeFaild => lossTimeFaild;
    public float LossTimeSuccess => lossTimeSuccess;
}

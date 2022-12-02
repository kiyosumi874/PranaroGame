using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{
	[Header("�J�n����")]
	[SerializeField] private float startTime = 30.0f;

	[SerializeField] private Ranking ranking = null;
	[SerializeField] private Score score = null;
	[SerializeField] private SoccerBall soccerBall = null;
	[SerializeField] private PlayerMover player = null;

	private float countDownTime;  // �J�E���g�_�E���^�C��
	private TMP_Text textCountDown;              // �\���p�e�L�X�gUI

	// Use this for initialization
	void Start()
	{
		countDownTime = startTime;  // �J�E���g�_�E���J�n�b�����Z�b�g
		textCountDown = GetComponent<TMP_Text>();
	}

	// Update is called once per frame
	void Update()
	{
		// 0.0�b�ȉ��ɂȂ�����J�E���g�_�E���^�C����0.0�ŌŒ�i�~�܂����悤�Ɍ�����j
		if (countDownTime <= 0.0F)
		{
			countDownTime = 0.0F;
			textCountDown.text = String.Format("{0:00.00}", countDownTime);
			soccerBall.SetState(SoccerBall.State.End);
			player.enabled = false;
			ranking.CallRanking(score.GetScore());
			this.enabled = false;
		}

		// �J�E���g�_�E���^�C���𐮌`���ĕ\��
		textCountDown.text = String.Format("{0:00.00}", countDownTime);
		// �o�ߎ����������Ă���
		countDownTime -= Time.deltaTime;
		
	}
}
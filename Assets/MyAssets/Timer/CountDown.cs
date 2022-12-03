using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{
	[Header("�J�n����")]
	[SerializeField] private float startTime = 30.0f;

	[Header("�����̃t�H�[�}�b�g")]
	[SerializeField] private bool isFloat = true;

	private float countDownTime;  // �J�E���g�_�E���^�C��
	private TMP_Text textCountDown;              // �\���p�e�L�X�gUI
	private bool isEnd;
	public bool IsEnd => isEnd;
	public float CountDownTime => countDownTime;
	public float StartTime => startTime;


	// Use this for initialization
	void Start()
	{
		countDownTime = startTime;  // �J�E���g�_�E���J�n�b�����Z�b�g
		textCountDown = GetComponent<TMP_Text>();
		isEnd = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (!isEnd)
        {
			// 0.0�b�ȉ��ɂȂ�����J�E���g�_�E���^�C����0.0�ŌŒ�i�~�܂����悤�Ɍ�����j
			if (countDownTime <= 0.0F)
			{
				countDownTime = 0.0F;
				if (isFloat)
                {
					textCountDown.text = String.Format("{0:00.00}", countDownTime);
				}
				else
                {
					int time = (int)countDownTime+1;
					textCountDown.text = String.Format("{0:0}", time);
				}
				isEnd = true;
			}
			else
            {
				// �J�E���g�_�E���^�C���𐮌`���ĕ\��
				if (isFloat)
				{
					textCountDown.text = String.Format("{0:00.00}", countDownTime);
				}
				else
				{
					int time = (int)countDownTime+1;
					textCountDown.text = String.Format("{0:0}", time);
				}
				// �o�ߎ����������Ă���
				countDownTime -= Time.deltaTime;
			}
		}
	}
}
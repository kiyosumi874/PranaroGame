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

	[SerializeField] private bool isImage = false;
	[SerializeField] private bool isStartTimer = false;

	[SerializeField] private TMP_Text textCountDown = null;
	[SerializeField] private Image image = null;
	[SerializeField] private Sprite[] sprite = null;

	private float countDownTime;  // �J�E���g�_�E���^�C��
	private bool isEnd;
	public bool IsEnd => isEnd;
	public float CountDownTime => countDownTime;
	public float StartTime => startTime;


	// Use this for initialization
	void Start()
	{
		countDownTime = startTime;  // �J�E���g�_�E���J�n�b�����Z�b�g
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

					if (!isImage)
                    {
						textCountDown.text = String.Format("{0:0}", time);
					}
					else
                    {
						if (isStartTimer)
                        {
							if (time == 3)
							{
								image.enabled = true;
								image.sprite = sprite[0];
							}
							if (time == 2)
							{
								image.sprite = sprite[1];
							}
							if (time == 1)
							{
								image.sprite = sprite[2];
							}
						}
						else
                        {
							if (time == 5)
							{
								image.enabled = true;
								image.sprite = sprite[0];
							}
							if (time == 4)
							{
								image.sprite = sprite[1];
							}
							if (time == 3)
							{
								image.sprite = sprite[2];
							}
							if (time == 2)
							{
								image.sprite = sprite[3];
							}
							if (time == 1)
							{
								image.sprite = sprite[4];
							}
						}
						
					}
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

					if (!isImage)
					{
						textCountDown.text = String.Format("{0:0}", time);
					}
					else
					{
						if (isStartTimer)
						{
							if (time == 3)
							{
								image.enabled = true;
								image.sprite = sprite[0];
							}
							if (time == 2)
							{
								image.sprite = sprite[1];
							}
							if (time == 1)
							{
								image.sprite = sprite[2];
							}
						}
						else
                        {
							if (time == 5)
							{
								image.enabled = true;
								image.sprite = sprite[0];
							}
							if (time == 4)
							{
								image.sprite = sprite[1];
							}
							if (time == 3)
							{
								image.sprite = sprite[2];
							}
							if (time == 2)
							{
								image.sprite = sprite[3];
							}
							if (time == 1)
							{
								image.sprite = sprite[4];
							}
						}
					}
				}
				// �o�ߎ����������Ă���
				countDownTime -= Time.deltaTime;
			}
		}
	}
}
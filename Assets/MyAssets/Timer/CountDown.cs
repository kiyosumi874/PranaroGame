using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{
	[Header("開始時間")]
	[SerializeField] private float startTime = 30.0f;

	[Header("数字のフォーマット")]
	[SerializeField] private bool isFloat = true;

	[SerializeField] private bool isImage = false;
	[SerializeField] private bool isStartTimer = false;

	[SerializeField] private TMP_Text textCountDown = null;
	[SerializeField] private Image image = null;
	[SerializeField] private Sprite[] sprite = null;

	private float countDownTime;  // カウントダウンタイム
	private bool isEnd;
	public bool IsEnd => isEnd;
	public float CountDownTime => countDownTime;
	public float StartTime => startTime;


	// Use this for initialization
	void Start()
	{
		countDownTime = startTime;  // カウントダウン開始秒数をセット
		isEnd = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (!isEnd)
        {
			// 0.0秒以下になったらカウントダウンタイムを0.0で固定（止まったように見せる）
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
				// カウントダウンタイムを整形して表示
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
				// 経過時刻を引いていく
				countDownTime -= Time.deltaTime;
			}
		}
	}
}
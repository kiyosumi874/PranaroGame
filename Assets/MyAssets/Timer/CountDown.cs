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

	private float countDownTime;  // カウントダウンタイム
	private TMP_Text textCountDown;              // 表示用テキストUI
	private bool isEnd;
	public bool IsEnd => isEnd;
	public float CountDownTime => countDownTime;
	public float StartTime => startTime;


	// Use this for initialization
	void Start()
	{
		countDownTime = startTime;  // カウントダウン開始秒数をセット
		textCountDown = GetComponent<TMP_Text>();
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
					textCountDown.text = String.Format("{0:0}", time);
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
					textCountDown.text = String.Format("{0:0}", time);
				}
				// 経過時刻を引いていく
				countDownTime -= Time.deltaTime;
			}
		}
	}
}
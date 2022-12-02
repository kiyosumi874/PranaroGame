using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{
	[Header("開始時間")]
	[SerializeField] private float startTime = 30.0f;

	[SerializeField] private Ranking ranking = null;
	[SerializeField] private Score score = null;
	[SerializeField] private SoccerBall soccerBall = null;
	[SerializeField] private PlayerMover player = null;

	private float countDownTime;  // カウントダウンタイム
	private TMP_Text textCountDown;              // 表示用テキストUI

	// Use this for initialization
	void Start()
	{
		countDownTime = startTime;  // カウントダウン開始秒数をセット
		textCountDown = GetComponent<TMP_Text>();
	}

	// Update is called once per frame
	void Update()
	{
		// 0.0秒以下になったらカウントダウンタイムを0.0で固定（止まったように見せる）
		if (countDownTime <= 0.0F)
		{
			countDownTime = 0.0F;
			textCountDown.text = String.Format("{0:00.00}", countDownTime);
			soccerBall.SetState(SoccerBall.State.End);
			player.enabled = false;
			ranking.CallRanking(score.GetScore());
			this.enabled = false;
		}

		// カウントダウンタイムを整形して表示
		textCountDown.text = String.Format("{0:00.00}", countDownTime);
		// 経過時刻を引いていく
		countDownTime -= Time.deltaTime;
		
	}
}
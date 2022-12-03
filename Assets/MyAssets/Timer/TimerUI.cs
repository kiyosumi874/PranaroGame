using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private Ranking ranking = null;
    [SerializeField] private Score score = null;
    [SerializeField] private SoccerBall soccerBall = null;
    [SerializeField] private PlayerMover player = null;
    [SerializeField] private CountDown countDown = null;
    [SerializeField] private GameObject endTimeUI = null;

    private bool[] onEvent;
    private float countDownStartTime;
    // Start is called before the first frame update
    void Start()
    {
        onEvent = new bool[2] { false, false };

        countDownStartTime = endTimeUI.GetComponent<CountDown>().StartTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (countDown.IsEnd && !onEvent[0])
        {
            onEvent[0] = true;
            soccerBall.SetState(SoccerBall.State.End);
            player.enabled = false;
            ranking.CallRanking(score.GetScore());
        }

        if (countDown.CountDownTime < countDownStartTime && !onEvent[1])
        {
            onEvent[1] = true;
            endTimeUI.SetActive(true);
        }
    }
}

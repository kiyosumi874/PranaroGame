using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTimerUI : MonoBehaviour
{
    [SerializeField] private CountDown countDown = null;
    [SerializeField] private GameObject timerUI = null;
    [SerializeField] private SoccerBall soccerBall = null;
    [SerializeField] private SoundPlayer bgm = null;
    [SerializeField] private SoundPlayer whistle = null;
    private bool onEvent;
    // Start is called before the first frame update
    void Start()
    {
        onEvent = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (countDown.IsEnd && !onEvent)
        {
            onEvent = true;
            bgm.Play();
            whistle.Play();
            timerUI.GetComponent<CountDown>().enabled = true;
            timerUI.GetComponent<TimerUI>().enabled = true;
            soccerBall.SetState(SoccerBall.State.Idle);
            this.gameObject.SetActive(false);
        }
    }
}

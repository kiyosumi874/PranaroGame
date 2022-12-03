using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTimerUI : MonoBehaviour
{
    [SerializeField] private CountDown countDown = null;
    [SerializeField] private GameObject timerUI = null;
    [SerializeField] private SoccerBall soccerBall = null;
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
            timerUI.SetActive(true);
            soccerBall.SetState(SoccerBall.State.Idle);
            this.gameObject.SetActive(false);
        }
    }
}

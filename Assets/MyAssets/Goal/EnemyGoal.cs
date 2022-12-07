using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoal : MonoBehaviour
{
    [SerializeField] private Score score;
    [SerializeField] private SoundPlayer goalSE;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SoccerBall"))
        {
            Debug.Log("“_‚ð“ü‚ê‚½");
            goalSE.Play();
            score.AddScore();
            other.GetComponent<SoccerBall>().SetState(SoccerBall.State.Init);
        }
    }
}

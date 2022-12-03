using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoal : MonoBehaviour
{
    [SerializeField] private Score score;
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
            Debug.Log("点を入れられた");
            score.AddScore();
            other.GetComponent<SoccerBall>().SetState(SoccerBall.State.InitLoss);
        }
    }
}

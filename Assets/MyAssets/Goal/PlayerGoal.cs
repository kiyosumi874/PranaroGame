using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoal : MonoBehaviour
{
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
            other.GetComponent<SoccerBall>().SetState(SoccerBall.State.InitLoss);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallRanking(int score)
    {
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(score);
    }
}

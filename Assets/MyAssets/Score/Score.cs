using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private int score = 0;
    private TMP_Text text;

    public int GetScore()
    {
        return score;
    }
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    public void AddScore()
    {
        score++;
        text.text = score.ToString();
    }
}

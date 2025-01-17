﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{

    public Transform player;
    public Text scoreText;
    public Text highScoreText;

    public float score =0;
    public float actualScore;
    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = PlayerPrefs.GetFloat("HighScore", 0).ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        actualScore = player.position.z;
        scoreText.text = actualScore.ToString("0");

        if (actualScore > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", actualScore);
            highScoreText.text = actualScore.ToString("0");
        }
    }
}

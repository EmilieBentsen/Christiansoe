using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System.Timers;
using System;


public class Quiz : MonoBehaviour
{
    //Denne klasse indeholder score og brugerens brugernanv til quizzen, den indeholder også en timer der viser hvor længe quizzen har været i gang
    DateTime startTime;
    TimeSpan elapsedTime;
    public Text username, timerText, score;
    public static int scoreNumber;


    void Start()
    {
        username.text = "Hej " + SceneController.quizName + " quizzen er igang!";
        score.text = "Score: " + scoreNumber.ToString();
        startTime = SceneController.savedTimeQuiz;


    }
    // Update is called once per frame
    void Update()
    {
        elapsedTime = DateTime.Now - startTime;
        timerText.text = string.Format("{0}:{1}:{2}", elapsedTime.Hours, elapsedTime.Minutes, elapsedTime.Seconds);

    }



}

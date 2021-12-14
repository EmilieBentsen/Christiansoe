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
    
    TimeSpan elapsedTime;
    public Text username, timerText, score;
    


    void Start()
    {
        username.text = "Hej " + SceneController.quizName + " quizzen er igang!";
        score.text = "Score: " + QuizController.scoreNumber.ToString();
        


    }
    // Update is called once per frame
    void Update()
    {
        elapsedTime = QuizController.elapsedTime;
        timerText.text = string.Format("{0}:{1}:{2}", elapsedTime.Hours, elapsedTime.Minutes, elapsedTime.Seconds);

    }



}

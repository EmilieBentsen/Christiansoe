using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class QuizController : MonoBehaviour
{
    // Start is called before the first frame update
    //Denne klasse tager imod brugernavn og gemmer det i SceneControlleren, SceneControlleren indeholder de væsenligeste statiske variabler i programmet
    public InputField input;
    private string name;

    void Start()
    {
       
        
    }

    public void GetInputName()
    {
        name = input.text;
        Debug.Log(name);
        SceneController.quizName = name;
        SceneController.savedTimeQuiz = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

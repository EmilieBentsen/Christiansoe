using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Globalization;

public class SceneController : MonoBehaviour
{
    public static string keyword;
    public static string quizName;
    public static string lastScene;
    public static string quizLetter;
    public static int quizCount;
    public static DateTime savedTimeQuiz;


    // Start is called before the first frame update
    //Denne klasser er den mest væsenligeste klasse, da det er den der skifter scener i appen og indeholder de væsenligeste statiske variabler i programmet
    void Start()
    {
        Debug.Log(keyword);
    }

    public void GetSceneKeyword(string PassedKeyword)
    {
        keyword = PassedKeyword;
    }

    public void SeasonScene()
    {
        DateTime current = DateTime.Now;


        if (current.Month >= 4 && current.Month <= 9)
        {
           SceneManager.LoadSceneAsync("summer");

        }
        else
        {
            SceneManager.LoadSceneAsync("winter");


        }
    }

    public void ChangeScene(string scene)
    {
       
        SceneManager.LoadSceneAsync(scene);
       
    }

    public void ToMapScene(string lstscene)
    {
        lastScene = lstscene;
        SceneManager.LoadSceneAsync("map");
    }

    public void BackFromMapScene()
    {
        SceneManager.LoadSceneAsync(lastScene);
    }
   
    public void ToFaergetidScene(string lstscene)
    {
        lastScene = lstscene;
        SceneManager.LoadSceneAsync("færgetid");
    }

    public void BackFromFaergetid()
    {
        SceneManager.LoadSceneAsync(lastScene);
    }
    public void GetQuizLetter(string Letter)
    {
        quizLetter = Letter;
        Debug.Log("QuizLetter: " + quizLetter);
    }

    public void Quit()
    {
        Application.Quit();
    }

}

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Firestore;
using Firebase.Extensions;

public class QuestionController : MonoBehaviour
{
    // Start is called before the first frame update
    //Denne klasse opretter spørgsmål i databasen og henter dem så de bliver vist i random rækkefølge
    public Text spm1;
    
  
    private static QuestionController instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            DontDestroyOnLoad(gameObject);
        }
        
    }

    void Start()
    {
        //Husk at fylde de rigtige spørgsmål i

        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;

        CollectionReference quizRef = db.Collection("A");
        quizRef.Document("1").SetAsync(new Dictionary<string, object>(){
        { "SP", "hvem har lagt navn til øen?" },
        { "svar1", "Frederik" },
        { "svar2", "Viggo" },
        { "rigtígt", "Christian" },
        { "BSV", false }
    }).ContinueWithOnMainThread(task =>
        quizRef.Document("2").SetAsync(new Dictionary<string, object>(){
        { "SP", "hvem har lagt navn til øen?" },
        { "svar1", "Frederik" },
        { "svar2", "Viggo" },
        { "rigtígt", "Christian" },
        { "BSV", false }
        })
        ).ContinueWithOnMainThread(task =>
            quizRef.Document("3").SetAsync(new Dictionary<string, object>(){
        { "SP", "hvem har lagt navn til øen?" },
        { "svar1", "Frederik" },
        { "svar2", "Viggo" },
        { "rigtígt", "Christian" },
        { "BSV", false }
            })
        ).ContinueWithOnMainThread(task =>
            quizRef.Document("4").SetAsync(new Dictionary<string, object>(){
        { "SP", "hvem har lagt navn til øen?" },
        { "svar1", "Frederik" },
        { "svar2", "Viggo" },
        { "rigtígt", "Christian" },
        { "BSV", false }
            })
        ).ContinueWithOnMainThread(task =>
            quizRef.Document("5").SetAsync(new Dictionary<string, object>(){
        { "SP", "hvem har lagt navn til øen?" },
        { "svar1", "Frederik" },
        { "svar2", "Viggo" },
        { "rigtígt", "Christian" },
        { "BSV", false }
            })
        );

        StartQuiz();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void StartQuiz()
    {
        string quizLetter = SceneController.quizLetter;
        Dictionary<string, object> questions = new Dictionary<string, object>();
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;

        DocumentReference docRef = db.Collection(quizLetter).Document("1");
        docRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            DocumentSnapshot snapshot = task.Result;
            if (snapshot.Exists)
            {
                Debug.Log(String.Format("Document data for {0} document:", snapshot.Id));
                questions = snapshot.ToDictionary();
                foreach (KeyValuePair<string, object> pair in questions)
                {
                    Debug.Log(String.Format("{0}: {1}", pair.Key, pair.Value));
                    if (pair.Key == "SP")
                    {
                        spm1.text = pair.Value.ToString();
                    }
                    else if (pair.Key == "BSV") 
                    { 
                    
                    }
                    else
                    {

                        int rnd = UnityEngine.Random.Range(1, 4);
                        for (int i = 0; i < 3; i++)
                        {

                            GameObject.Find("Answr" + rnd.ToString()).GetComponentInChildren<Text>().text = pair.Value.ToString();

                        }
                        Debug.Log(String.Format("Document {0} does not exist!", snapshot.Id));
                    }
                }
            }
        });
    }

}


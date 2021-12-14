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
    //Denne klasse opretter sp�rgsm�l i databasen og henter dem s� de bliver vist i random r�kkef�lge
    public Text spm1;
    public int quiznr;
    public int rightAnswer;
    public Button buttonText;
    private static QuestionController instance = null;
    Dictionary<string, object> questions = new Dictionary<string, object>();

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
        //Husk at fylde de rigtige sp�rgsm�l i

        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;

        CollectionReference quizRef = db.Collection("A");
        quizRef.Document("1").SetAsync(new Dictionary<string, object>(){
        { "SP", "hvem har lagt navn til �en?" },
        { "1", "Frederik" },
        { "9", "Christian" },
        { "2", "Viggo" },
    }).ContinueWithOnMainThread(task =>
        quizRef.Document("2").SetAsync(new Dictionary<string, object>(){
        { "SP", "hvad hedder tårnet?" },
        { "9", "Store tårn" },
        { "2", "Lille tårn" },
        { "1", "Christianstårn" },
        })
        ).ContinueWithOnMainThread(task =>
            quizRef.Document("3").SetAsync(new Dictionary<string, object>(){
        { "SP", "hvilke dyr er populære på øen?" },
        { "1", "Frøer" },
        { "9", "Måger" },
        { "2", "Pingviner" },
            })
        ).ContinueWithOnMainThread(task =>
            quizRef.Document("4").SetAsync(new Dictionary<string, object>(){
        { "SP", "Hvor stor er øen?" },
        { "9", "1000 kvm" },
        { "1", "10000 kvm" },
        { "2", "1000000 kvm" },
            })
        ).ContinueWithOnMainThread(task =>
            quizRef.Document("5").SetAsync(new Dictionary<string, object>(){
        { "SP", "hvem bestemmer på øen?" },
        { "9", "Ølederen" },
        { "1", "Dem alle" },
        { "2", "Et råd" },
            })
        );
        quiznr = 1;
        StartQuiz(quiznr.ToString());
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Score(string number)
    {
        if(number == rightAnswer.ToString())
        {
            QuizController.scoreNumber++;
        }
        quiznr++;
        StartQuiz(quiznr.ToString());

    }

    public void StartQuiz(string quizNumber)
    {
        string quizLetter = SceneController.quizLetter;
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;

        DocumentReference docRef = db.Collection(quizLetter).Document(quizNumber);
        docRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            DocumentSnapshot snapshot = task.Result;
            if (snapshot.Exists)
            {
                Debug.Log(String.Format("Document data for {0} document:", snapshot.Id));
                questions = snapshot.ToDictionary();


                int count = 1;
                
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

                        GameObject.Find("Answr" + count.ToString()).GetComponentInChildren<Text>().text = pair.Value.ToString();
                        if(pair.Key == "9")
                        {
                            rightAnswer = count;
                            Debug.Log("rigtigt svar: " + rightAnswer);
                        }
                        count++;

                        Debug.Log(String.Format("Document {0} does not exist!", snapshot.Id));
                    }
                }
            }
        });
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;
using System;

public class ButtonController : MonoBehaviour
{
    public static Button nordturen;
    public static Sprite sprite;
    public static int count;
    public static bool instanceWaiter;
    
    // Start is called before the first frame update
    void Start()
    {

        count = 0;
        StartCoroutine(NordturenKnap());
        StartCoroutine(KirketurenKnap());
        StartCoroutine(SydturenKnap());

    }

    // Update is called once per frame
    void Update()
    {

    }
    //Disse metoder bruges til at vise billeder fra den pågældende tur, så brugeren har mulighed for at se hvad de kommer forbi på vejen
    IEnumerator NordturenKnap()
    {
        yield return new WaitForSecondsRealtime(3);
        Debug.Log(count);
        if (count >= 6)
        {
            count = 0;
        }
        count++;
        sprite = Resources.Load<Sprite>("nordturen/" + count.ToString());
        nordturen = GameObject.Find("nordturen").GetComponent<Button>();
        nordturen.image.sprite = sprite;
        StartCoroutine(NordturenKnap());
    }
    IEnumerator KirketurenKnap()
    {
        yield return new WaitForSecondsRealtime(3);
        Debug.Log(count);
        if (count >= 6)
        {
            count = 0;
        }
        count++;
        sprite = Resources.Load<Sprite>("kirketuren/" + count.ToString());
        nordturen = GameObject.Find("kirketuren").GetComponent<Button>();
        nordturen.image.sprite = sprite;
        StartCoroutine(KirketurenKnap());
    }
    IEnumerator SydturenKnap()
    {
        yield return new WaitForSecondsRealtime(3);
        Debug.Log(count);
        if (count >= 6)
        {
            count = 0;
        }
        count++;
        sprite = Resources.Load<Sprite>("sydturen/" + count.ToString());
        nordturen = GameObject.Find("sydturen").GetComponent<Button>();
        nordturen.image.sprite = sprite;
        StartCoroutine(SydturenKnap());
    }


}

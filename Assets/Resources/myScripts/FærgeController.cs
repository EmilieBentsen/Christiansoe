using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;
using System;
using System.Net;





public class FærgeController : MonoBehaviour
{
    // Start is called before the first frame update
    //Denne klasse, beregner hvor lang tid der er til færgen går
    public Text færge;
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        DateTime current = DateTime.Now;
        DateTime schedule = new DateTime(current.Year, current.Month, current.Day, 14, 0, 0, 0);

        if (current > schedule)
        {
            schedule = schedule.AddDays(1);
        }

        TimeSpan difference = schedule - current;

        færge.text = string.Format("{0}:{1}:{2}", difference.Hours, difference.Minutes, difference.Seconds);

        /*WebClient client = new WebClient();
        string content = client.DownloadString("https://www.christiansoefarten.dk/sejlplaner/?m=1");
        Debug.Log(content);*/
    }


}

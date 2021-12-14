using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AudioController : MonoBehaviour
{
    // Start is called before the first frame update
    
    //knapper og lister til lydpunkter, lydpunkter består af et stednavn, en lon og lat til stedet og navnet på den lydfil som afspillesspilles
    public Button audio, pause;
    public AudioSource sound;
    public List<LydPunkt> lydpunkterGrøn = new List<LydPunkt>();
    public List<LydPunkt> lydpunkterRød = new List<LydPunkt>();
    public List<LydPunkt> lydpunkterBlå = new List<LydPunkt>();

    void Start()
    {
        //Her instatntieres lydpunkterne
        lydpunkterGrøn.AddRange(new List<LydPunkt>
        {
            new LydPunkt("gyldenløves bastion", 55.72053, 12.56013, "tekstspor"),
            new LydPunkt("Rantzaus bastion", 0, 0, "sydturen"),
            new LydPunkt("Verdens ende", 0, 0, "kirketuren"),
            new LydPunkt("Hertugindens bastion", 0, 0, "vælgEnRute"),
        });

        lydpunkterRød.AddRange(new List<LydPunkt>
        {
            new LydPunkt("Store tårn", 0, 0, "tekstspor"),
            new LydPunkt("Kirken", 0, 0, "sydturen"),
            new LydPunkt("Skolen", 0, 0, "kirketuren"),
            new LydPunkt("Kirkegården", 0, 0, "vælgEnRute"),
        });

        lydpunkterBlå.AddRange(new List<LydPunkt>
        {
            new LydPunkt("Juuls bastion", 0, 0, "tekstspor"),
            new LydPunkt("Kongens bastion", 0, 0, "sydturen"),
            new LydPunkt("Dronningens bastion", 0, 0, "kirketuren"),
            new LydPunkt("Bjelkes bastion", 0, 0, "vælgEnRute"),
        });

    }

    // Update is called once per frame
    void Update()
    {
        //Her startes det valgte lydpunkt med et statisk keyword fra SceneController klasser, der er 3 ture rød, blå og grøn
        StartLydPunkt(SceneController.keyword);

    }

        
    //Denne metode sætter gang i det lydpunkt der er tættest på en på ruten, når brugeren er under 30 meter fra punktet, lydpunktet kan sættes på pause og genoptages
    public void StartLydPunkt(string color)
    {

        LydPunkt myPos = GetMyPosition();

        switch (color)
        {
            case "grøn":
              foreach (LydPunkt lydPunkt in lydpunkterGrøn)
              {

                int distance = lydPunkt.GetDistance(myPos.latitude, myPos.longitude);

                if (distance < 30)
                {
                    AddSoundButton(lydPunkt);
                }
              }
                break;
            case "rød":
                foreach (LydPunkt lydPunkt in lydpunkterRød)
                {

                    int distance = lydPunkt.GetDistance(myPos.latitude, myPos.longitude);

                    if (distance < 30)
                    {
                        AddSoundButton(lydPunkt);
                    }
                }
                break;
            case "blå":
                foreach (LydPunkt lydPunkt in lydpunkterBlå)
                {

                    int distance = lydPunkt.GetDistance(myPos.latitude, myPos.longitude);

                    if (distance < 30)
                    {
                        AddSoundButton(lydPunkt);
                    }
                }
                break;
        }

    }

    //Denne metode opretter et lydpunkt med kundens kordinator, ved at hente kundens koordinator fra GPS klassen, der har adgang til kundens location på telefonen
    public LydPunkt GetMyPosition()
    {
        float lat = GPS.latitude;
        float lon = GPS.longitude;
        decimal latDec = new decimal(lat);
        double latDou = (double)latDec;
        decimal lonDec = new decimal(lon);
        double lonDou = (double)lonDec;

        LydPunkt myPos = new LydPunkt("myPos", latDou, lonDou, "none");
        return myPos;
    }

    //Denne metode indsætter ikoner til at afspille og pause det nærtliggende lydpunkt
    public void AddSoundButton(LydPunkt lydpunkt)
    {
        var sprite = Resources.Load<Sprite>("icons/volume");
        audio = GameObject.Find("audio").GetComponent<Button>();
        audio.image.color = Color.white;
        audio.image.sprite = sprite;

        sound = GameObject.Find("lydPunkt").GetComponent<AudioSource>();
        sound.clip = Resources.Load<AudioClip>("audio/" + lydpunkt.audio);

        var sprite2 = Resources.Load<Sprite>("icons/pause");
        pause = GameObject.Find("pause").GetComponent<Button>();
        pause.image.color = Color.white;
        pause.image.sprite = sprite2;
    }


}
//Dette er en lydpunkts klasse, der bruges til at oprette lydpunkt objekter, lydpunktet har constructor og properties
public class LydPunkt
{

    public LydPunkt(string na, double lat, double lon, string aud)
    {
        name = na;
        latitude = lat;
        longitude = lon;
        audio = aud;
    }

    public string name { get; set; }
    public double latitude { get; set; }
    public double longitude { get; set; }
    public string audio { get; set; }
    public string color { get; set; }


    //denne metode bruges til at beregne distancen til lydpunktet i meter
    public int GetDistance(double lat, double lon)
    {
        int distance = (int)Math.Floor(Calculate(lat, lon, latitude, longitude) * 1000);
        return distance;
    }

    //Denne metode beregner afstanden til lydpunktet i doubles
    public double Calculate(double lat1, double lon1, double lat2, double lon2)
    {
        var R = 6372.8; // In kilometers
        var dLat = ToRadians(lat2 - lat1);
        var dLon = ToRadians(lon2 - lon1);
        lat1 = ToRadians(lat1);
        lat2 = ToRadians(lat2);

        var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
        var c = 2 * Math.Asin(Math.Sqrt(a));
        return R * c;
    }

    //Denne metode berenger double til radianer
    public double ToRadians(double angle)
    {
        return Math.PI * angle / 180.0;
    }

}

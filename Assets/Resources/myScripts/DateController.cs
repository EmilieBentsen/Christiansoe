using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class DateController : MonoBehaviour
{
    // Start is called before the first frame update
    //Denne klasse, skriver dagens dato og tid i menuen i appen
    public Text dato;
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        dato.text = System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
    }
}

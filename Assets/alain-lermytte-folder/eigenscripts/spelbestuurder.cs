using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class spelbestuurder : MonoBehaviour
{
    public int punten = 0;
    public Text scoretekst;
    
    
    public void puntentoevoegen()
        
    {
        punten = punten + 1;
        scoretekst.text = "pinguins gevonden:  " + punten;
    }
           
    
    // Start is called before the first frame update
    void Start()
    {
        scoretekst.text = "pinguins gevonden:  " + punten;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class gamestates : MonoBehaviour
{
    public GameObject speler;
    public GameObject player;
    public GameObject levelscherm;
    public GameObject introscherm;
    public GameObject eindscherm;
    public GameObject finish;
    public spelbestuurder spelbestuurder;
    public Text eindscoretekst;
    public testraketbeweginen bewegingen;
    public FPSController movement;


    public enum Gamestates
    {
        introductiescherm,
        level,
        eindscherm
    }

    public Gamestates gamestate = Gamestates.introductiescherm;
    // Start is called before the first frame update
    void Start()
    {
        if (speler == null)
        {
            speler = GameObject.FindWithTag("Player");
            print("speler gevonden");
        }

        spelbestuurder = GameObject.FindWithTag("needed").GetComponent<spelbestuurder>();
        //bewegingen = GameObject.FindWithTag("Player").GetComponent<testraketbeweginen>();
    }

    // Update is called once per frame
    void Update()
    {

        // finishknop
        float klikken = Input.GetAxis("Cancel");
        //print(klikken);

        switch (gamestate)
        {
            
            case Gamestates.level:
                if (klikken == 1)
                {
                    gamestate = Gamestates.eindscherm;
                    levelscherm.SetActive(false);
                    eindscherm.SetActive(true);
                    print("thats all folks");
                }

                break;
            
        }
    }


    public void StartLevel()
    {
        gamestate = Gamestates.level;
        introscherm.SetActive(false);
        levelscherm.SetActive(true);
        eindscherm.SetActive(false);
        //bewegingen.enabled = true;
        player.SetActive(true);
    }
    public void eindigen()
    {
        gamestate = Gamestates.eindscherm;
        levelscherm.SetActive(false);
        eindscherm.SetActive(true);
        //bewegingen.enabled = false;
        player.SetActive(false);
        if (spelbestuurder.punten == 1)
        {
            eindscoretekst.text = "Gefeliciteerd\n Je vond :  " + spelbestuurder.punten + " pinguin";
        }
        else
        {
            eindscoretekst.text = "Gefeliciteerd\n Je vond :  " + spelbestuurder.punten + " pinguins";
        }
        
        print("squadulah we are off");
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class gamestates : MonoBehaviour
{
    public GameObject speler;
    public GameObject levelscherm;
    public GameObject eindscherm;
    public GameObject finish;


    public enum Gamestates
    {
        level,
        eindscherm
    }

    public Gamestates gamestate = Gamestates.level;
    // Start is called before the first frame update
    void Start()
    {
        if (speler == null)
        {
            speler = GameObject.FindWithTag("Player");
            print("speler gevonden");
        }
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
}

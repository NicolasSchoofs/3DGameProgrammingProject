using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.XR;

public class oprapen : MonoBehaviour
{

    public spelbestuurder manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindWithTag("needed").GetComponent<spelbestuurder>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            float vind = Input.GetAxis("Fire1");
            //print("knop ingedrukt");

            if (vind == 1)
            {
                print("knop ingedrukt in het zicht van een pinguin");
                manager.puntentoevoegen();
                Destroy(gameObject);
            }

        }
    }
}
